using Classification.Attribute;
using Dictionary.Dictionary;

namespace DataGenerator.Attribute
{
    public class IsMoneyAttribute : BinaryAttribute
    {
        /**
         * <summary>Binary attribute for a given word. If the word is "dolar", "euro", "sterlin", etc., the attribute will have the
         * value "true", otherwise "false".</summary>
         * <param name="surfaceForm">Surface form of the word.</param>
         */
        public IsMoneyAttribute(string surfaceForm) : base(Word.IsMoney(surfaceForm))
        {
        }
    }
}