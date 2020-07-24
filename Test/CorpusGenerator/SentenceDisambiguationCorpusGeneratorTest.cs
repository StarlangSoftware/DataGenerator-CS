using DataGenerator.CorpusGenerator;
using NUnit.Framework;

namespace Test.CorpusGenerator
{
    public class SentenceDisambiguationCorpusGeneratorTest
    {
        [Test]
        public void TestGenerate()
        {
            var sentenceDisambiguationCorpusGenerator = new SentenceDisambiguationCorpusGenerator("../../../sentences/", ".dev");
            var disambiguationCorpus = sentenceDisambiguationCorpusGenerator.Generate();
            Assert.AreEqual(10, disambiguationCorpus.SentenceCount());
            Assert.AreEqual(101, disambiguationCorpus.NumberOfWords());
            Assert.AreEqual(14, disambiguationCorpus.MaxSentenceLength());
        }
    }
}