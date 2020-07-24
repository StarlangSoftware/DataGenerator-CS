using AnnotatedSentence;
using Classification.Instance;
using Corpus;
using NamedEntityRecognition;

namespace DataGenerator.InstanceGenerator
{
    public abstract class NerInstanceGenerator : SimpleWindowInstanceGenerator
    {
        /**
         * Generates a single classification instance of the NER problem for the given word of the given sentence. If the
         * word has not been labeled with NER tag yet, the method returns null.
         * @param sentence Input sentence.
         * @param wordIndex The index of the word in the sentence.
         * @return Classification instance.
         */
        public override Instance GenerateInstanceFromSentence(Sentence sentence, int wordIndex)
        {
            var word = (AnnotatedWord) sentence.GetWord(wordIndex);

            var classLabel = NamedEntityTypeStatic.GetNamedEntityType(word.GetNamedEntityType());
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