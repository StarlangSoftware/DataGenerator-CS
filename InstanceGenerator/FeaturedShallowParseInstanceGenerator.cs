using System;
using AnnotatedSentence;
using Classification.Attribute;
using Classification.Instance;
using Corpus;
using DataGenerator.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.InstanceGenerator
{
    public class FeaturedShallowParseInstanceGenerator : ShallowParseInstanceGenerator
    {
        /**
         * <summary>Constructor method. Gets input window size and sets the corresponding variable.</summary>
         * <param name="windowSize">Number of previous (next) words to be considered in adding attributes.</param>
         */
        public FeaturedShallowParseInstanceGenerator(int windowSize)
        {
            this.windowSize = windowSize;
        }

        /**
         * <summary>Abstract function for adding attributes to the shallow parsing problem. Depending on your design
         * you can add as many attributes as possible. The number of attributes in this function should be equal to the
         * number of attributes in the function addAttributesForEmptyWords.</summary>
         * <param name="current">Current classification instance</param>
         * <param name="sentence">Input sentence.</param>
         * <param name="wordIndex">The index of the word in the sentence.</param>
         */
        protected override void AddAttributesForWords(Instance current, Sentence sentence, int wordIndex)
        {
            var word = (AnnotatedWord) sentence.GetWord(wordIndex);

            MorphologicalParse parse = word.GetParse();

            current.AddAttribute(new IsAdjectiveAttribute(parse));
            current.AddAttribute(new IsAuxiliaryVerbAttribute(parse));
            current.AddAttribute(new IsCapitalAttribute(word.GetName()));
            current.AddAttribute(new IsDateAttribute(parse));
            current.AddAttribute(new IsFractionAttribute(parse));

            current.AddAttribute(new IsHonorificAttribute(word.GetName()));
            current.AddAttribute(new IsMoneyAttribute(word.GetName()));
            current.AddAttribute(new IsNumberAttribute(parse));
            current.AddAttribute(new IsOrganizationAttribute(word.GetName()));

            current.AddAttribute(new IsProperNounAttribute(parse));
            current.AddAttribute(new IsRealAttribute(parse));
            current.AddAttribute(new IsTimeAttribute(word.GetName()));

            current.AddAttribute(new LastIGContainsPossessiveAttribute(parse));
            current.AddAttribute(new LastIGContainsTagAblativeAttribute(parse));
            current.AddAttribute(new LastIGContainsTagAccusativeAttribute(parse));
            current.AddAttribute(new LastIGContainsTagGenitiveAttribute(parse));
            current.AddAttribute(new LastIGContainsTagInstrumentalAttribute(parse));

            current.AddAttribute(new MainPosAttribute(parse));
            current.AddAttribute(new Predicate(sentence, wordIndex));
            current.AddAttribute(new RootPosAttribute(parse));
            current.AddAttribute(new RootFormAttribute(parse));
            current.AddAttribute(new CaseAttribute(parse));
        }

        /**
         * <summary>Abstract function for adding attributes for empty words to the shallow parsing problem. The number of
         * attributes in this function should be equal to the number of attributes in the function
         * addAttributesForPreviousWords.</summary>
         * <param name="current">Current classification instance</param>
         * <param name="emptyWord">String form to place for empty words.</param>
         */
        protected override void AddAttributesForEmptyWords(Instance current, String emptyWord)
        {
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new BinaryAttribute(false));
            current.AddAttribute(new DiscreteAttribute("NULL"));
            current.AddAttribute(new DiscreteAttribute("NULL"));
            current.AddAttribute(new DiscreteAttribute("NULL"));
            current.AddAttribute(new DiscreteAttribute("NULL"));
            current.AddAttribute(new DiscreteAttribute("NULL"));
        }
    }
}