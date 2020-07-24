using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class LastIGContainsTagAccusativeAttribute : LastIGContainsTagAttribute
    {
        /**
		 * <summary>Binary attribute for a given word. If the last inflectional group of the word contains ACCUSATIVE tag,	
		 * the attribute will be "true", otherwise "false".</summary>
		 * <param name="parse">Morphological parse of the word.</param>
		 */
        public LastIGContainsTagAccusativeAttribute(MorphologicalParse parse) : base(parse, MorphologicalTag.ACCUSATIVE)
        {
            
        }
    }
}