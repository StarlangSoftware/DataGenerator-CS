using Classification.Attribute;
using Corpus;

namespace DataGenerator.Attribute
{
    public class Predicate : DiscreteAttribute
    {
        /**
		 * <summary>Discrete attribute for a given word. Returns the nearest predicate word to the given word</summary>
		 * <param name="sentence">Sentence where current word is in.</param>
		 * <param name="index">Position of the current word in the sentence</param>
		 */
        public Predicate(Sentence sentence, int index) : base(
            ((AnnotatedSentence.AnnotatedSentence) sentence).GetPredicate(index))
        {
        }
    }
}