using DataGenerator.DatasetGenerator;
using DataGenerator.InstanceGenerator;
using MorphologicalAnalysis;
using NUnit.Framework;

namespace Test.DatasetGenerator
{
    public class AnnotatedDataSetGeneratorTest
    {
        [Test]
        public void TestNERGenerate()
        {
            var annotatedDataSetGenerator =
                new AnnotatedDataSetGenerator("../../../sentences/", ".dev", new FeaturedNerInstanceGenerator(1));
            var dataSet = annotatedDataSetGenerator.Generate();
            Assert.AreEqual(101, dataSet.SampleSize());
            Assert.AreEqual(3, dataSet.ClassCount());
            Assert.AreEqual(75, dataSet.AttributeCount());
        }

        [Test]
        public void TestSemanticGenerate()
        {
            var fsmMorphologicalAnalyzer = new FsmMorphologicalAnalyzer();
            var turkish = new WordNet.WordNet();
            var annotatedDataSetGenerator = new AnnotatedDataSetGenerator("../../../sentences/", ".dev",
                new FeaturedSemanticInstanceGenerator(fsmMorphologicalAnalyzer, turkish, 1));
            var dataSet = annotatedDataSetGenerator.Generate();
            Assert.AreEqual(54, dataSet.SampleSize());
            Assert.AreEqual(35, dataSet.ClassCount());
            Assert.AreEqual(66, dataSet.AttributeCount());
        }

        [Test]
        public void TestShallowParseGenerate()
        {
            var annotatedDataSetGenerator =
                new AnnotatedDataSetGenerator("../../../sentences/", ".dev", new FeaturedShallowParseInstanceGenerator(1));
            var dataSet = annotatedDataSetGenerator.Generate();
            Assert.AreEqual(96, dataSet.SampleSize());
            Assert.AreEqual(6, dataSet.ClassCount());
            Assert.AreEqual(66, dataSet.AttributeCount());
        }

        [Test]
        public void TestDisambiguationGenerate()
        {
            var annotatedDataSetGenerator =
                new AnnotatedDataSetGenerator("../../../sentences/", ".dev", new FeaturedDisambiguationInstanceGenerator(1));
            var dataSet = annotatedDataSetGenerator.Generate();
            Assert.AreEqual(101, dataSet.SampleSize());
            Assert.AreEqual(43, dataSet.ClassCount());
            Assert.AreEqual(4, dataSet.AttributeCount());
        }
    }
}