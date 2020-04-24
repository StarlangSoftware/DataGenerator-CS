using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class IsRealAttribute : BinaryAttribute
    {
        /**
         * <summary>Binary attribute for a given word. If the word is represents a real number (if the morphological parse contains
         * tag REAL), the attribute will have the value "true", otherwise "false".</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public IsRealAttribute(MorphologicalParse parse) : base(parse.IsReal())
        {
            
        }
    }
}