using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class IsAdjectiveAttribute : BinaryAttribute
    {
        /**
         * <summary> Binary attribute for a given word. If the word is an adjective, the attribute will have
         * the value "true", otherwise "false".</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public IsAdjectiveAttribute(MorphologicalParse parse) : base(parse.IsAdjective())
        {
        }
    }
}