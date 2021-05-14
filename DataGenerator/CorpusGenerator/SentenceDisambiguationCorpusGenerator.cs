using AnnotatedSentence;
using MorphologicalAnalysis;

namespace DataGenerator.CorpusGenerator
{
    public class SentenceDisambiguationCorpusGenerator
    {
        private readonly AnnotatedCorpus _annotatedCorpus;

        /**
         * <summary> Constructor for the DisambiguationCorpusGenerator which takes input the data directory and the
         * pattern for the training files included. The constructor loads the corpus from the given directory including
         * the given files having the given pattern.</summary>
         *
         * <param name="directory">Directory where the corpus files reside.</param>
         * <param name="pattern">Pattern of the tree files to be included in the corpus. Use "." for all files.</param>
         */
        public SentenceDisambiguationCorpusGenerator(string directory, string pattern)
        {
            _annotatedCorpus = new AnnotatedCorpus(directory, pattern);
        }

        /**
         * <summary> Creates a morphological disambiguation corpus from the corpus.</summary>
         *
         * <returns>Created disambiguation corpus.</returns>
         */
        public DisambiguationCorpus Generate()
        {
            var corpus = new DisambiguationCorpus();
            for (var i = 0; i < _annotatedCorpus.SentenceCount(); i++)
            {
                var sentence = _annotatedCorpus.GetSentence(i);
                var disambiguationSentence = new AnnotatedSentence.AnnotatedSentence("");
                for (var j = 0; j < sentence.WordCount(); j++)
                {
                    disambiguationSentence.AddWord(new DisambiguatedWord(sentence.GetWord(j).GetName(),
                        ((AnnotatedWord) sentence.GetWord(j)).GetParse()));
                }

                corpus.AddSentence(disambiguationSentence);
            }

            return corpus;
        }
    }
}