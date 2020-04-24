using Classification.Attribute;
using Dictionary.Dictionary;

namespace DataGenerator.Attribute
{
    public class IsHonorificAttribute : BinaryAttribute
    {
        /**
    	 * <summary>Binary attribute for a given word. If the word is "bay" or "bayan", the attribute will have the value "true",
    	 * otherwise "false".</summary>
    	 * <param name="surfaceForm">Surface form of the word.</param>
    	 */
        public IsHonorificAttribute(string surfaceForm) : base(Word.IsHonorific(surfaceForm))
        {
            
        }
    }
}