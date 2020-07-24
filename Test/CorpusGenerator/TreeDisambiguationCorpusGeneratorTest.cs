using DataGenerator.CorpusGenerator;
using NUnit.Framework;

namespace Test.CorpusGenerator
{
    public class TreeDisambiguationCorpusGeneratorTest
    {
        [Test]
        public void TestGenerate()
        {
            var treeDisambiguationCorpusGenerator = new TreeDisambiguationCorpusGenerator("../../../trees/", ".dev");
            var disambiguationCorpus = treeDisambiguationCorpusGenerator.Generate();
            Assert.AreEqual(10, disambiguationCorpus.SentenceCount());
            Assert.AreEqual(88, disambiguationCorpus.NumberOfWords());
            Assert.AreEqual(13, disambiguationCorpus.MaxSentenceLength());
        }

    }
}