using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class LastIGContainsPossessiveAttribute : BinaryAttribute
    {
        /**
         * <summary>Binary attribute for a given word. If the last inflectional group of the word contains POSSESSIVE tag,
         * the attribute will be "true", otherwise "false".</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public LastIGContainsPossessiveAttribute(MorphologicalParse parse) : base(parse.LastIGContainsPossessive())
        {
            
        }
    }
}