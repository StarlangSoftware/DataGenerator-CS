using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class IsDateAttribute : BinaryAttribute
    {
        /**
		 * <summary>Binary attribute for a given word. If the word represents a date (if the morphological parse contains
		 * tag DATE), the attribute will have the value "true", otherwise "false".</summary>
		 * <param name="parse">Morphological parse of the word.</param>
		 */
        public IsDateAttribute(MorphologicalParse parse) : base(parse.IsDate())
        {
            
        }
    }
}