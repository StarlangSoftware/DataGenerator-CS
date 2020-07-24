using DataGenerator.DatasetGenerator;
using DataGenerator.InstanceGenerator;
using NUnit.Framework;

namespace Test.DatasetGenerator
{
    public class NerDataSetGeneratorTest
    {
        [Test]
        public void TestGenerate() {
            var disambiguationDataSetGenerator = new NerDataSetGenerator("../../../trees/", ".dev", new FeaturedNerInstanceGenerator(1));
            var dataSet = disambiguationDataSetGenerator.Generate();
            Assert.AreEqual(88, dataSet.SampleSize());
            Assert.AreEqual(3, dataSet.ClassCount());
            Assert.AreEqual(75, dataSet.AttributeCount());
        }
    }
}