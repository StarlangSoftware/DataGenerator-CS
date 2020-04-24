using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class LastIGContainsTagAttribute : BinaryAttribute
    {
        /**
		 * <summary>Binary attribute for a given word. If the last inflectional group of the word contains tag,
		 * the attribute will be "true", otherwise "false".</summary>
		 * <param name="parse">Morphological parse of the word.</param>
		 * <param name="tag">Tag that is checked in the last inflectional group.</param>
		 */
        public LastIGContainsTagAttribute(MorphologicalParse parse, MorphologicalTag tag) : base(parse.LastIGContainsTag(tag))
        {
            
        }
    }
}