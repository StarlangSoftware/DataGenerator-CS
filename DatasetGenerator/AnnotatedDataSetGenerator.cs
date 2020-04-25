using AnnotatedSentence;
using Classification.DataSet;

namespace DataGenerator.DatasetGenerator
{
    public class AnnotatedDataSetGenerator
    {
        private readonly AnnotatedCorpus _corpus;
        protected InstanceGenerator.InstanceGenerator instanceGenerator;

        /**
         * <summary> Constructor for the AnnotatedDataSetGenerator which takes input the data directory, the pattern for the
         * training files included, and an instanceGenerator. The constructor loads the sentence corpus from the given
         * directory including the given files having the given pattern.</summary>
         * <param name="directory">Directory where the corpus files reside.</param>
         * <param name="pattern">Pattern of the tree files to be included in the treebank. Use "." for all files.</param>
         * <param name="instanceGenerator">The instance generator used to generate the dataset.</param>
         */
        public AnnotatedDataSetGenerator(string directory, string pattern,
            InstanceGenerator.InstanceGenerator instanceGenerator)
        {
            _corpus = new AnnotatedCorpus(directory, pattern);
            this.instanceGenerator = instanceGenerator;
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
         * <summary> Creates a dataset from the corpus. Calls generateInstanceFromSentence for each parse sentence in the corpus.
         * @return Created dataset.</summary>
         */
        public DataSet Generate()
        {
            var dataSet = new DataSet();
            for (var i = 0; i < _corpus.SentenceCount(); i++)
            {
                var sentence = (AnnotatedSentence.AnnotatedSentence) _corpus.GetSentence(i);
                for (var j = 0; j < sentence.WordCount(); j++)
                {
                    var generatedInstance = instanceGenerator.GenerateInstanceFromSentence(sentence, j);
                    if (generatedInstance != null)
                    {
                        dataSet.AddInstance(generatedInstance);
                    }
                }
            }

            return dataSet;
        }
    }
}