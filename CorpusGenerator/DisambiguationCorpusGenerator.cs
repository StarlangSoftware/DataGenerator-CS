using AnnotatedSentence;
using AnnotatedTree;
using Corpus;
using MorphologicalDisambiguation;

namespace DataGenerator.CorpusGenerator
{
    public class DisambiguationCorpusGenerator
    {
        private readonly TreeBankDrawable _treeBank;

        /**
         * <summary> Constructor for the DisambiguationCorpusGenerator which takes input the data directory and the pattern for the
         * training files included. The constructor loads the treebank from the given directory including the given files
         * having the given pattern.</summary>
         *
         * <param name="directory">Directory where the treebank files reside.</param>
         * <param name="pattern">Pattern of the tree files to be included in the treebank. Use "." for all files.</param>
         */
        public DisambiguationCorpusGenerator(string directory, string pattern)
        {
            _treeBank = new TreeBankDrawable(directory, pattern);
        }

        /**
         * <summary> Creates a morphological disambiguation corpus from the treeBank. Calls generateAnnotatedSentence for each parse
         * tree in the treebank.</summary>
         *
         * <returns>Created disambiguation corpus.</returns>
         */
        public DisambiguationCorpus Generate()
        {
            var corpus = new DisambiguationCorpus();
            for (var i = 0; i < _treeBank.Size(); i++)
            {
                var parseTree = _treeBank.Get(i);
                if (parseTree.LayerAll(ViewLayerType.INFLECTIONAL_GROUP))
                {
                    Sentence sentence = parseTree.GenerateAnnotatedSentence();
                    corpus.AddSentence(sentence);
                }
            }

            return corpus;
        }
    }
}