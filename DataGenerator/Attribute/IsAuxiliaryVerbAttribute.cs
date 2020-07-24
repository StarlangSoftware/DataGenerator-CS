using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class IsAuxiliaryVerbAttribute : BinaryAttribute
    {
        /**
         * <summary> Binary attribute for a given word. If the word is an auxiliary verb, the attribute will have
         * the value "true", otherwise "false".</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public IsAuxiliaryVerbAttribute(MorphologicalParse parse) : base(parse.IsAuxiliary() && parse.IsVerb())
        {
        }
    }
}