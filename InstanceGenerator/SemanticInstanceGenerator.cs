using System.Collections.Generic;
using AnnotatedSentence;
using Classification.Instance;
using Corpus;
using MorphologicalAnalysis;

namespace DataGenerator.InstanceGenerator
{
    public abstract class SemanticInstanceGenerator : SimpleWindowInstanceGenerator
    {
        private readonly FsmMorphologicalAnalyzer _fsm;
        private readonly WordNet.WordNet _wordNet;

        /**
         * <summary>Constructor for the semantic instance generator. Takes morphological analyzer and wordnet as input to set the
         * corresponding variables.</summary>
         * <param name="fsm">Morphological analyzer to be used.</param>
         * <param name="wordNet">Wordnet to be used.</param>
         */
        public SemanticInstanceGenerator(FsmMorphologicalAnalyzer fsm, WordNet.WordNet wordNet)
        {
            this._fsm = fsm;
            this._wordNet = wordNet;
        }

        /**
         * <summary>Generates a single classification instance of the WSD problem for the given word of the given sentence. If the
         * word has not been labeled with sense tag yet, the method returns null. In the WSD problem, the system also
         * generates and stores all possible sense labels for the current instance. In this case, a classification
         * instance will not have all labels in the dataset, but some subset of it.</summary>
         * <param name="sentence">Input sentence.</param>
         * <param name="wordIndex">The index of the word in the sentence.</param>
         * <returns>Classification instance.</returns>
         */
        public override Instance GenerateInstanceFromSentence(Sentence sentence, int wordIndex)
        {
            var possibleSynSets =
                ((AnnotatedSentence.AnnotatedSentence) sentence).ConstructSynSets(_wordNet, _fsm, wordIndex);
            var word = (AnnotatedWord) sentence.GetWord(wordIndex);
            var classLabel = word.GetSemantic();
            if (classLabel == null || possibleSynSets.Count == 0)
            {
                return null;
            }

            var current = new CompositeInstance(classLabel);
            var possibleClassLabels = new List<string>();
            foreach (var synSet in possibleSynSets)
            {
                possibleClassLabels.Add(synSet.GetId());
            }

            current.SetPossibleClassLabels(possibleClassLabels);
            AddAttributes(current, sentence, wordIndex);
            return current;
        }
    }
}