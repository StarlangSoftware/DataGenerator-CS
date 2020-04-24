using AnnotatedSentence;
using Classification.Instance;
using Corpus;

namespace DataGenerator.InstanceGenerator
{
    public abstract class ShallowParseInstanceGenerator : SimpleWindowInstanceGenerator
    {
        /**
         * <summary>Generates a single classification instance of the Shallow Parse problem for the given word of the given sentence.
         * If the  word has not been labeled with shallow parse tag yet, the method returns null.</summary>
         * <param name="sentence">Input sentence.</param>
         * <param name="wordIndex">The index of the word in the sentence.</param>
         * <returns>Classification instance.</returns>
         */
        public override Instance GenerateInstanceFromSentence(Sentence sentence, int wordIndex)
        {
            var word = (AnnotatedWord) sentence.GetWord(wordIndex);

            var classLabel = word.GetShallowParse();
            if (classLabel == null)
            {
                return null;
            }

            var current = new Instance(classLabel);

            AddAttributes(current, sentence, wordIndex);
            return current;
        }
    }
}