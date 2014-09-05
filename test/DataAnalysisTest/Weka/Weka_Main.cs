using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMining.DataAnalysisTest.Weka
{
    class Weka_Main
    {
        // [ref] http://weka.wikispaces.com/IKVM+with+Weka+tutorial
        // [ref] http://www.ikvm.net/

        public static void run(string[] args)
        {
            Console.WriteLine("\tClassification Example --------------------------------------");
            runClassificationExample();
        }

        static void runClassificationExample()
        {
            try
            {
                weka.core.Instances instances = new weka.core.Instances(new java.io.FileReader("../data/iris.arff"));
                instances.setClassIndex(instances.numAttributes() - 1);

                weka.classifiers.Classifier classifier = new weka.classifiers.trees.J48();
                Console.WriteLine("Performing " + percentSplit_ + "% split evaluation.");

                // randomize the order of the instances in the dataset.
                weka.filters.Filter myRandom = new weka.filters.unsupervised.instance.Randomize();
                myRandom.setInputFormat(instances);
                instances = weka.filters.Filter.useFilter(instances, myRandom);

                int trainSize = instances.numInstances() * percentSplit_ / 100;
                int testSize = instances.numInstances() - trainSize;
                weka.core.Instances trainingSet = new weka.core.Instances(instances, 0, trainSize);

                classifier.buildClassifier(trainingSet);
                int numCorrect = 0;
                for (int i = trainSize; i < instances.numInstances(); ++i)
                {
                    weka.core.Instance currentInstance = instances.instance(i);
                    double predictedClass = classifier.classifyInstance(currentInstance);
                    if (instances.instance(i).classValue() == predictedClass)
                        ++numCorrect;
                }

                Console.WriteLine(numCorrect + " out of " + testSize + " correct (" + ((double)numCorrect / (double)testSize * 100.0) + "%)");
            }
            catch (java.lang.Exception ex)
            {
                ex.printStackTrace();
            }
        }

        const int percentSplit_ = 66;  // [%].
    }
}
