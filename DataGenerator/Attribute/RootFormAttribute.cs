using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class RootFormAttribute : DiscreteAttribute
    {
        /**
         * <summary>Discrete attribute for a given word. Returns the the root word</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public RootFormAttribute(MorphologicalParse parse) : base(parse.GetWord().GetName())
        {
        }
    }
}