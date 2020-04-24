using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class CaseAttribute : DiscreteAttribute
    {
        /**
         * <summary> Discrete attribute for a given word. If the last inflectional group of the word contains case information, the
         * attribute will have that case value. Otherwise the attribute will have the value null.</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public CaseAttribute(MorphologicalParse parse) : base(parse.LastIGContainsCase())
        {
        }
    }
}