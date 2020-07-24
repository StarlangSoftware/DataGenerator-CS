using Classification.Attribute;
using Dictionary.Dictionary;

namespace DataGenerator.Attribute
{
    public class IsOrganizationAttribute : BinaryAttribute
    {
        /**
		 * <summary>Binary attribute for a given word. If the word is "corp.", "inc." or "co.", the attribute will have the
		 * value "true", otherwise "false".</summary>
		 * <param name="surfaceForm">Surface form of the word.</param>
		 */
        public IsOrganizationAttribute(string surfaceForm) : base(Word.IsOrganization(surfaceForm))
        {
            
        }
    }
}