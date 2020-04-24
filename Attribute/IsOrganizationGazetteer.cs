using Classification.Attribute;
using NamedEntityRecognition;

namespace DataGenerator.Attribute
{
    public class IsOrganizationGazetteer : BinaryAttribute
    {
        public static readonly Gazetteer gazetteer = new Gazetteer("ORGANIZATION", "gazetteer-organization.txt");

        /**
    	 * <summary>Binary attribute for a given word. If the word is listed in the Organization Gazetteer file, the attribute will
    	 * have the value "true", otherwise "false".</summary>
    	 * <param name="surfaceForm">Surface form of the word.</param>
    	 */
        public IsOrganizationGazetteer(string surfaceForm) : base(gazetteer.Contains(surfaceForm))
        {
        }
    }
}