using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class IsNumberAttribute : BinaryAttribute
    {
        /**
         * <summary>Binary attribute for a given word. If the word is represents a number (if the morphological parse contains
         * tag REAL or CARDINAL), the attribute will have the value "true", otherwise "false".</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public IsNumberAttribute(MorphologicalParse parse) : base(parse.IsNumber())
        {
        }
    }
}