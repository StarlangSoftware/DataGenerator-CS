using Classification.Instance;
using Corpus;

namespace DataGenerator.InstanceGenerator
{
    public abstract class InstanceGenerator
    {
        protected int windowSize;

        public abstract Instance GenerateInstanceFromSentence(Sentence sentence, int wordIndex);
        
    }
}