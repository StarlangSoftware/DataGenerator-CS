using System.Collections.Generic;
using AnnotatedSentence;
using AnnotatedTree;
using Classification.Instance;
using DataGenerator.InstanceGenerator;

namespace DataGenerator.DatasetGenerator
{
    public class ChunkingDataSetGenerator : DataSetGenerator
    {
        private readonly ChunkType _chunkType;

        /**
         * <summary> Constructor for the ChunkingDataSetGenerator which takes input the data directory, the pattern for the training files
         * included, chunkType, and an instanceGenerator. The constructor calls the super class, where the punctuation symbols
         * are included. The dataset generator generates the dataset for the given  chunk type.</summary>
         * <param name="directory">Directory where the treebank files reside.</param>
         * <param name="pattern">Pattern of the tree files to be included in the treebank. Use "." for all files.</param>
         * <param name="chunkType">THe chunkType for which the chunking dataset is generated.</param>
         * <param name="shallowParseInstanceGenerator">The instance generator used to generate the dataset.</param>
         */
        public ChunkingDataSetGenerator(string directory, string pattern, ChunkType chunkType,
            ShallowParseInstanceGenerator shallowParseInstanceGenerator) : base(directory, pattern, true, shallowParseInstanceGenerator)
        {
            
            this._chunkType = chunkType;
        }

        /**
         * <summary> Overriden the method that generates a set of instances (an instance from each word in the tree) from
         * a single tree.</summary>
         * <param name="parseTree">Parsetree for which a set of instances will be created</param>
         * <returns>An array of instances.</returns>
         */
        protected new List<Instance> GenerateInstanceListFromTree(ParseTreeDrawable parseTree)
        {
            var instanceList = new List<Instance>();
            if (!parseTree.LayerAll(ViewLayerType.INFLECTIONAL_GROUP))
                return instanceList;
            if (!parseTree.IsFullSentence())
                return instanceList;
            parseTree.ExtractVerbal();
            parseTree.SetShallowParseLayer(_chunkType);
            return base.GenerateInstanceListFromTree(parseTree);
        }
    }
}