using DataGenerator.DatasetGenerator;
using DataGenerator.InstanceGenerator;
using MorphologicalAnalysis;
using NUnit.Framework;

namespace Test.DatasetGenerator
{
    public class SemanticDataSetGeneratorTest
    {
        [Test]
        public void TestGenerate() {
            var fsmMorphologicalAnalyzer = new FsmMorphologicalAnalyzer();
            var turkish = new WordNet.WordNet();
            var semanticDataSetGenerator = new SemanticDataSetGenerator("../../../trees/", ".dev", new FeaturedSemanticInstanceGenerator(fsmMorphologicalAnalyzer, turkish, 1));
            var dataSet = semanticDataSetGenerator.Generate();
            Assert.AreEqual(52, dataSet.SampleSize());
            Assert.AreEqual(35, dataSet.ClassCount());
            Assert.AreEqual(66, dataSet.AttributeCount());
        }
    }
}