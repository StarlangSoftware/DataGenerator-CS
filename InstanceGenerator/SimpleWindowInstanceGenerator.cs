using Classification.Instance;
using Corpus;

namespace DataGenerator.InstanceGenerator
{
    public abstract class SimpleWindowInstanceGenerator : InstanceGenerator
    {
        protected abstract void AddAttributesForWords(Instance current, Sentence sentence, int wordIndex);

        protected abstract void AddAttributesForEmptyWords(Instance current, string emptyWord);

        /**
         * addAttributes adds all attributes of the previous words, the current word, and next words of the given word
         * to the given instance. If the previous or next words does not exists, the method calls
         * addAttributesForEmptyWords method. If the word does not exists in the dictionary or the required annotation layer
         * does not exists in the annotated word, the method throws InstanceNotGenerated. The window size determines the
         * number of previous and next words.
         * @param current Current classification instance to which attributes will be added.
         * @param sentence Input sentence.
         * @param wordIndex The index of the word in the sentence.
         */
        protected void AddAttributes(Instance current, Sentence sentence, int wordIndex)
        {
            for (var i = 0; i < windowSize; i++)
            {
                if (wordIndex - windowSize + i >= 0)
                {
                    AddAttributesForWords(current, sentence, wordIndex - windowSize + i);
                }
                else
                {
                    AddAttributesForEmptyWords(current, "<s>");
                }
            }

            AddAttributesForWords(current, sentence, wordIndex);
            for (var i = 0; i < windowSize; i++)
            {
                if (wordIndex + i + 1 < sentence.WordCount())
                {
                    AddAttributesForWords(current, sentence, wordIndex + i + 1);
                }
                else
                {
                    AddAttributesForEmptyWords(current, "</s>");
                }
            }
        }
    }
}