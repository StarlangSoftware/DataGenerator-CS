using Classification.Attribute;
using Dictionary.Dictionary;

namespace DataGenerator.Attribute
{
    public class IsTimeAttribute : BinaryAttribute
    {
        /**
		 * <summary>Binary attribute for a given word. If the word represents a time form, the attribute will have the
		 * value "true", otherwise "false".</summary>
		 * <param name="surfaceForm">Surface form of the word.</param>
		 */
        public IsTimeAttribute(string surfaceForm) : base(Word.IsTime(surfaceForm))
        {
            
        }
    }
}