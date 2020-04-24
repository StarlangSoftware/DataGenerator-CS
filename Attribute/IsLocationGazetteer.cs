using Classification.Attribute;
using NamedEntityRecognition;

namespace DataGenerator.Attribute
{
    public class IsLocationGazetteer : BinaryAttribute
    {
        public static readonly Gazetteer gazetteer = new Gazetteer("LOCATION", "gazetteer-location.txt");

        /**
    	 * <summary>Binary attribute for a given word. If the word is listed in the Location Gazetteer file, the attribute will    
    	 * have the value "true", otherwise "false".</summary>
    	 * <param name="surfaceForm">Surface form of the word.</param>
    	 */
        public IsLocationGazetteer(string surfaceForm) : base(gazetteer.Contains(surfaceForm))
        {
            
        }
    }
}