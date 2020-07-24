using DataGenerator.InstanceGenerator;

namespace DataGenerator.DatasetGenerator
{
    public class SemanticDataSetGenerator : DataSetGenerator
    {
        /**
         * <summary> Constructor for the NerDataSetGenerator which takes input the data directory, the pattern for the training files
         * included, and an instanceGenerator. The constructor calls its super class with these inputs.</summary>
         * <param name="directory">Directory where the treebank files reside.</param>
         * <param name="pattern">Pattern of the tree files to be included in the treebank. Use "." for all files.</param>
         * <param name="semanticInstanceGenerator">The instance generator used to generate the dataset.</param>
         */
        public SemanticDataSetGenerator(string directory, string pattern,
            SemanticInstanceGenerator semanticInstanceGenerator) : base(directory, pattern, true,
            semanticInstanceGenerator)
        {
        }
    }
}