using DataGenerator.DatasetGenerator;
using DataGenerator.InstanceGenerator;
using NUnit.Framework;

namespace Test.DatasetGenerator
{
    public class DisambiguationDataSetGeneratorTest
    {
        [Test]
        public void TestGenerate() {
            var disambiguationDataSetGenerator = new DisambiguationDataSetGenerator("../../../trees/", ".dev", true, new FeaturedDisambiguationInstanceGenerator(1));
            var dataSet = disambiguationDataSetGenerator.Generate();
            Assert.AreEqual(88, dataSet.SampleSize());
            Assert.AreEqual(41, dataSet.ClassCount());
            Assert.AreEqual(4, dataSet.AttributeCount());
        }
    }
}