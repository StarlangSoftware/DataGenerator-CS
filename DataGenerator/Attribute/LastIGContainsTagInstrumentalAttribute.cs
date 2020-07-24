using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class LastIGContainsTagInstrumentalAttribute : LastIGContainsTagAttribute
    {
        /**
		 * <summary>Binary attribute for a given word. If the last inflectional group of the word contains INSTRUMENTAL tag,
		 * the attribute will be "true", otherwise "false".</summary>
		 * <param name="parse">Morphological parse of the word.</param>
		 */
        public LastIGContainsTagInstrumentalAttribute(MorphologicalParse parse) : base(parse,
            MorphologicalTag.INSTRUMENTAL)
        {
        }
    }
}