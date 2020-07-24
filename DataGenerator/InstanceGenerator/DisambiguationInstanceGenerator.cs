using System;
using AnnotatedSentence;
using Classification.Instance;
using Corpus;

namespace DataGenerator.InstanceGenerator
{
    public abstract class DisambiguationInstanceGenerator : InstanceGenerator
    {
        protected abstract void AddAttributesForPreviousWords(Instance current, Sentence sentence, int wordIndex);
        protected abstract void AddAttributesForEmptyWords(Instance current, string emptyWord);

        /**
         * <summary>Generates a single classification instance of the morphological disambiguation problem for the given word of the
         * given sentence. If the word does not have a morphological parse, the method throws InstanceNotGenerated.</summary>
         * <param name="sentence">Input sentence.</param>
         * <param name="wordIndex">The index of the word in the sentence.</param>
         * <returns>Classification instance.</returns>
         */
        public override Instance GenerateInstanceFromSentence(Sentence sentence, int wordIndex)
        {
            var word = (AnnotatedWord) sentence.GetWord(wordIndex);

            var current = new Instance(word.GetParse().GetTransitionList());
            for (var i = 0; i < windowSize; i++)
            {
                if (wordIndex - windowSize + i >= 0)
                {
                    AddAttributesForPreviousWords(current, sentence, wordIndex - windowSize + i);
                }
                else
                {
                    AddAttributesForEmptyWords(current, "<s>");
                }
            }

            AddAttributesForPreviousWords(current, sentence, wordIndex);
            return current;
        }
    }
}