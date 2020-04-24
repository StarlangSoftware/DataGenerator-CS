using AnnotatedSentence;
using Classification.Attribute;
using Classification.Instance;
using Corpus;
using DataGenerator.Attribute;

namespace DataGenerator.InstanceGenerator
{
    public class FeaturedDisambiguationInstanceGenerator : DisambiguationInstanceGenerator
    {
        /**
         * <summary>Constructor method. Gets input window size and sets the corresponding variable.</summary>
         * <param name="windowSize">Number of previous (next) words to be considered in adding attributes.</param>
         */
        public FeaturedDisambiguationInstanceGenerator(int windowSize)
        {
            this.windowSize = windowSize;
        }

        /**
         * <summary>Abstract function for adding attributes to the morphological disambiguation problem. Depending on your design
         * you can add as many attributes as possible. The number of attributes in this function should be equal to the
         * number of attributes in the function addAttributesForEmptyWords.</summary>
         * <param name="current">Current classification instance</param>
         * <param name="sentence">Input sentence.</param>
         * <param name="wordIndex">The index of the word in the sentence.</param>
         */
        protected override void AddAttributesForPreviousWords(Instance current, Sentence sentence, int wordIndex)
        {
            var word = (AnnotatedWord) sentence.GetWord(wordIndex);
            var parse = word.GetParse();
            current.AddAttribute(new MainPosAttribute(parse));
            current.AddAttribute(new IsCapitalAttribute(word.GetName()));
        }

        /**
         * <summary>Abstract function for adding attributes for empty words to the morphological disambiguation problem. The number of
         * attributes in this function should be equal to the number of attributes in the function
         * addAttributesForPreviousWords.</summary>
         * <param name="current">Current classification instance</param>
         * <param name="emptyWord">String form to place for empty words.</param>
         */
        protected override void AddAttributesForEmptyWords(Instance current, string emptyWord)
        {
            current.AddAttribute(new DiscreteAttribute("NULL"));
            current.AddAttribute(new BinaryAttribute(false));
        }
    }
}