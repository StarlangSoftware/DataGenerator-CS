using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class IsFractionAttribute : BinaryAttribute
    {
        /**
         * <summary>Binary attribute for a given word. If the word is represents a fraction (if the morphological parse contains
         * tag FRACTION), the attribute will have the value "true", otherwise "false".</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public IsFractionAttribute(MorphologicalParse parse) : base(parse.IsFraction())
        {
        }
    }
}