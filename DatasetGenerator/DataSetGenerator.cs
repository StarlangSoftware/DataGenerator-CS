using System.Collections.Generic;
using AnnotatedTree;
using Classification.DataSet;
using Classification.Instance;

namespace DataGenerator.DatasetGenerator
{
    public class DataSetGenerator
    {
        private readonly TreeBankDrawable _treeBank;
        protected InstanceGenerator.InstanceGenerator instanceGenerator;

        /**
         * <summary> Constructor for the DataSetGenerator which takes input the data directory, the pattern for the training files
         * included, includePunctuation, and an instanceGenerator. The constructor loads the treeBank from the given directory
         * including the given files having the given pattern. If punctuations are not included, they are removed from
         * the data.</summary>
         * <param name="directory">Directory where the treeBank files reside.</param>
         * <param name="pattern">Pattern of the tree files to be included in the treeBank. Use "." for all files.</param>
         * <param name="includePunctuation">If true, punctuation symbols are also included in the dataset, false otherwise.</param>
         * <param name="instanceGenerator">The instance generator used to generate the dataSet.</param>
         */
        public DataSetGenerator(string directory, string pattern, bool includePunctuation,
            InstanceGenerator.InstanceGenerator instanceGenerator)
        {
            _treeBank = new TreeBankDrawable(directory, pattern);
            this.instanceGenerator = instanceGenerator;
            if (!includePunctuation)
                _treeBank.StripPunctuation();
        }

        /**
         * <summary> The method generates a set of instances (an instance from each word in the tree) from a single tree. The method
         * calls the instanceGenerator for each word in the sentence.</summary>
         * <param name="parseTree">ParseTree for which a set of instances will be created</param>
         * <returns>An array of instances.</returns>
         */
        protected List<Instance> GenerateInstanceListFromTree(ParseTreeDrawable parseTree)
        {
            var instanceList = new List<Instance>();
            var annotatedSentence = parseTree.GenerateAnnotatedSentence();
            for (var i = 0; i < annotatedSentence.WordCount(); i++)
            {
                var generatedInstance = instanceGenerator.GenerateInstanceFromSentence(annotatedSentence, i);
                if (generatedInstance != null)
                {
                    instanceList.Add(generatedInstance);
                }
            }

            return instanceList;
        }

        /**
         * <summary> Mutator for the instanceGenerator attribute.</summary>
         * <param name="instanceGenerator">Input instanceGenerator</param>
         */
        public void SetInstanceGenerator(InstanceGenerator.InstanceGenerator instanceGenerator)
        {
            this.instanceGenerator = instanceGenerator;
        }

        /**
         * <summary> Creates a dataSet from the treeBank. Calls generateInstanceListFromTree for each parse tree in the treeBank.</summary>
         * <returns>Created dataSet.</returns>
         */
        public DataSet Generate()
        {
            var dataSet = new DataSet();
            for (var i = 0; i < _treeBank.Size(); i++)
            {
                var parseTree = _treeBank.Get(i);
                dataSet.AddInstanceList(GenerateInstanceListFromTree(parseTree));
            }

            return dataSet;
        }
    }
}