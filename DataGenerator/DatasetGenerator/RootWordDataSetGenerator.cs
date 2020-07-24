using DataGenerator.InstanceGenerator;

namespace DataGenerator.DatasetGenerator
{
    public class RootWordDataSetGenerator : DataSetGenerator
    {
        /**
         * <summary> Constructor for the RootWordDataSetGenerator which takes input the data directory, the pattern for the training files
         * included, includepunctuation, and an instanceGenerator. The constructor calls its super class with these inputs.</summary>
         * <param name="directory">Directory where the treebank files reside.</param>
         * <param name="pattern">Pattern of the tree files to be included in the treebank. Use "." for all files.</param>
         * <param name="includePunctuation">If true, punctuation symbols are also included in the dataset, false otherwise.</param>
         * <param name="rootWordInstanceGenerator">The instance generator used to generate the dataset.</param>
         */
        public RootWordDataSetGenerator(string directory, string pattern, bool includePunctuation,
            RootWordInstanceGenerator rootWordInstanceGenerator) : base(directory, pattern, includePunctuation,
            rootWordInstanceGenerator)
        {
        }
    }
}