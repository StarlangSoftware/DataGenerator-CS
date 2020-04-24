using Classification.Attribute;

namespace DataGenerator.Attribute
{
    public class SurfaceFormAttribute : DiscreteAttribute
    {
        /**
         * <summary>Discrete attribute for a given word. Returns the surface form.</summary>
         * <param name="surfaceForm">Surface form of the word.</param>
         */
        public SurfaceFormAttribute(string surfaceForm) : base(surfaceForm)
        {
            
        }
    }
}