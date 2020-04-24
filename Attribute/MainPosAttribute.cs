using Classification.Attribute;
using MorphologicalAnalysis;

namespace DataGenerator.Attribute
{
    public class MainPosAttribute : DiscreteAttribute
    {
        /**
         * <summary>Discrete attribute for a given word. Returns the last part of speech (main part of speech) of the word</summary>
         * <param name="parse">Morphological parse of the word.</param>
         */
        public MainPosAttribute(MorphologicalParse parse) : base(parse.GetPos())
        {
        }
    }
}