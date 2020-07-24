using Classification.Attribute;

namespace DataGenerator.Attribute
{
    public class IsCapitalAttribute : BinaryAttribute
    {
        /**
         * <summary> Binary attribute for a given word. If the starting letter of the word is capital, the attribute will have
         * the value "true", otherwise "false".</summary>
         * <param name="surfaceForm">Surface form of the word.</param>
         */
        public IsCapitalAttribute(string surfaceForm) : base(char.IsUpper(surfaceForm[0]))
        {
        }
    }
}