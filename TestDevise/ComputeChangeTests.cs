using LuccaDevises;
using LuccaDevises.Models;

namespace TestDevise
{
    [TestClass]
    public class ComputeChangesTests
    {
        [TestMethod]
        public void TwoDevises()
        {
            DeviseGraph graph = new();
            graph.Graph = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {
                    "EUR", new Dictionary<string, decimal>(){ { "USD", 1.002m} }
                },
                {
                    "USD", new Dictionary<string, decimal>(){ { "EUR", 0.0m} }
                }
            };

            List<string> list = new()
            {
                "EUR",
                "USD"
            };

            var change = graph.ComputeChange(list, 10);
            Assert.IsNotNull(change);
            Assert.AreEqual(10, change);

        }

        [TestMethod]
        public void ThreeDevises()
        {
            DeviseGraph graph = new();
            graph.Graph = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {
                    "EUR", new Dictionary<string, decimal>(){ { "CHF", 1.802m} }
                },
                {
                    "CHF", new Dictionary<string, decimal>(){ { "USD", 1.556m} }
                },
                {
                    "USD", new Dictionary<string, decimal>()
                }
            };

            List<string> list = new()
            {
                "EUR",
                "CHF",
                "USD"
            };


            var change = graph.ComputeChange(list, 10);
            Assert.IsNotNull(change);
            Assert.AreEqual(28, change);

        }

        [TestMethod]
        public void FourDevises()
        {
            DeviseGraph graph = new();
            graph.Graph = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {
                    "EUR", new Dictionary<string, decimal>(){ { "CHF", 1.8022m} }
                },
                {
                    "CHF", new Dictionary<string, decimal>(){ { "CFA", 1.5561m} }
                },
                                {
                    "CFA", new Dictionary<string, decimal>(){ { "USD", 0.2637m} }
                },
                {
                    "USD", new Dictionary<string, decimal>()
                }
            };


            List<string> list = new()
            {
                "EUR",
                "CHF",
                "CFA",
                "USD"
            };


            var change = graph.ComputeChange(list, 10);
            Assert.IsNotNull(change);
            Assert.AreEqual(7, change);

        }
    }
}
