using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class LastIGContainsTagAblativeAttribute : LastIGContainsTagAttribute
    {
        /**
         * <summary>Binary attribute for a given word. If the last inflectional group of the word contains ABLATIVE tag,
         * the attribute will be "true", otherwise "false".</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public LastIGContainsTagAblativeAttribute(MorphologicalParse parse) : base(parse, MorphologicalTag.ABLATIVE)
        {
        }
    }
}