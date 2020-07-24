using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class RootPosAttribute : DiscreteAttribute
    {
        /**
         * Discrete attribute for a given word. Returns the part of speech of the root word
         * @param parse Morphological parse of the word.
         */
        public RootPosAttribute(MorphologicalParse parse) : base(parse.GetRootPos())
        {
        }
    }
}