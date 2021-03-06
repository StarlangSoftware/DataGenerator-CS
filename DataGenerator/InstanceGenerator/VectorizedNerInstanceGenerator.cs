using System;
using AnnotatedSentence;
using Classification.Instance;
using Corpus;
using Dictionary.Dictionary;

namespace DataGenerator.InstanceGenerator
{
    public class VectorizedNerInstanceGenerator : NerInstanceGenerator
    {
        private readonly VectorizedDictionary _dictionary;
        private readonly WordFormat _format;

        /**
         * <summary>Constructor of VectorizedNerInstanceGenerator which takes input a {@link VectorizedDictionary}, a window size
         * and a word format and sets corresponding attributes with these inputs.</summary>
         * <param name="dictionary">Dictionary in the vector form. Each word is stored in vector form in this dictionary.</param>
         * <param name="windowSize">Number of previous (next) words to be considered in adding attributes.</param>
         * <param name="format">Word vector format.</param>
         */
        public VectorizedNerInstanceGenerator(VectorizedDictionary dictionary, int windowSize, WordFormat format)
        {
            this._dictionary = dictionary;
            this.windowSize = windowSize;
            this._format = format;
        }

        /**
         * <summary>Abstract function for adding vectorized attributes to the named entity recognition problem. The number of
         * attributes in this function should be equal to the number of attributes in the function addAttributesForEmptyWords.</summary>
         * <param name="current">Current classification instance</param>
         * <param name="sentence">Input sentence.</param>
         * <param name="wordIndex">The index of the word in the sentence.</param>
         */
        protected override void AddAttributesForWords(Instance current, Sentence sentence, int wordIndex)
        {
            var word = (AnnotatedWord) sentence.GetWord(wordIndex);
            var vectorizedWord = (VectorizedWord) _dictionary.GetWord(word.GetFormattedString(_format));
            if (vectorizedWord != null)
            {
                current.AddVectorAttribute(vectorizedWord.GetVector());
            }
        }

        /**
         * <summary>Abstract function for adding attributes for empty words to the named entity recognition problem. The number of
         * attributes in this function should be equal to the number of attributes in the function</summary>
         * addAttributesForWords.
         * <param name="current">Current classification instance</param>
         * <param name="emptyWord">String form to place for empty words.</param>
         */
        protected override void AddAttributesForEmptyWords(Instance current, String emptyWord)
        {
            var vectorizedWord = (VectorizedWord) _dictionary.GetWord(emptyWord);
            if (vectorizedWord != null)
            {
                current.AddVectorAttribute(vectorizedWord.GetVector());
            }
        }
    }
}