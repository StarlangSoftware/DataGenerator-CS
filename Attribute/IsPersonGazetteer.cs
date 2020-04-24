using Classification.Attribute;
using NamedEntityRecognition;

namespace DataGenerator.Attribute
{
    public class IsPersonGazetteer : BinaryAttribute
    {
        public static readonly Gazetteer gazetteer = new Gazetteer("PERSON", "gazetteer-person.txt");

        /**
		 * <summary>Binary attribute for a given word. If the word is listed in the Person Gazetteer file, the attribute will
		 * have the value "true", otherwise "false".</summary>
		 * <param name="surfaceForm">Surface form of the word.</param>
		 */
        public IsPersonGazetteer(string surfaceForm) : base(gazetteer.Contains(surfaceForm))
        {
            
        }
    }
}