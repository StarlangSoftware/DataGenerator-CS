using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class LastIGContainsTagGenitiveAttribute : LastIGContainsTagAttribute
    {
        /**
		 * <summary>Binary attribute for a given word. If the last inflectional group of the word contains GENITIVE tag,
		 * the attribute will be "true", otherwise "false".</summary>
		 * <param name="parse">Morphological parse of the word.</param>
		 */
        public LastIGContainsTagGenitiveAttribute(MorphologicalParse parse) : base(parse, MorphologicalTag.GENITIVE)
        {
        }
    }
}