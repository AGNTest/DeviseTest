using LuccaDevises;
using LuccaDevises.Models;

namespace TestDevise
{
    [TestClass]
    public class GraphPathFindingTests
    {
        [TestMethod]
        public void SmallCase()
        {
            DeviseGraph graph = new();
            graph.Graph = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {
                    "EUR", new Dictionary<string, decimal>(){ { "YEN", 0.0m} }
                },
                {
                    "YEN", new Dictionary<string, decimal>(){ { "USD", 0.0m} }
                },
                {
                    "USD", new Dictionary<string, decimal>(){ { "YEN", 0.0m} }
                }
            };

            var path = graph.ShortestPath("EUR", "USD");
            Assert.IsNotNull(path);
            Assert.IsTrue(path.Count() == 3);
            Assert.IsTrue(path.ElementAt(0) == "EUR");
            Assert.IsTrue(path.ElementAt(1) == "YEN");
            Assert.IsTrue(path.ElementAt(2) == "USD");

        }

        [TestMethod]
        public void TwoWayCase()
        {
            DeviseGraph graph = new();
            graph.Graph = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {
                    "EUR", new Dictionary<string, decimal>(){ { "YEN", 0.0m }, { "USD", 0.0m } }
                },
                {
                    "YEN", new Dictionary<string, decimal>(){ { "USD", 0.0m} }
                },
                {
                    "USD", new Dictionary<string, decimal>(){ { "EUR", 0.0m}, { "YEN", 0.0m} }
                }
            };

            var path = graph.ShortestPath("EUR", "USD");
            Assert.IsNotNull(path);
            Assert.IsTrue(path.Count() == 2);
            Assert.IsTrue(path.ElementAt(0) == "EUR");
            Assert.IsTrue(path.ElementAt(1) == "USD");

        }

        [TestMethod]
        public void TwoWayDeepCase()
        {
            DeviseGraph graph = new();
            graph.Graph = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {
                    "EUR", new Dictionary<string, decimal>(){ { "YEN", 0.0m } }
                },
                {
                    "YEN", new Dictionary<string, decimal>(){ { "CFA", 0.0m } , { "CHF", 0.0m } }
                },
                {
                    "CFA",  new Dictionary<string, decimal>(){ { "YEN", 0.0m } , { "CHF", 0.0m } }
                },
                                {
                    "CHF",  new Dictionary<string, decimal>(){ { "YEN", 0.0m } , { "CFA", 0.0m }, {"USD",0.0m } }
                },
                {
                    "USD", new Dictionary<string, decimal>(){ { "CHF", 0.0m} }
                }
            };

            var path = graph.ShortestPath("EUR", "USD");
            Assert.IsNotNull(path);
            Assert.IsTrue(path.Count() == 4);
            Assert.IsTrue(path.ElementAt(0) == "EUR");
            Assert.IsTrue(path.ElementAt(1) == "YEN");
            Assert.IsTrue(path.ElementAt(2) == "CHF");
            Assert.IsTrue(path.ElementAt(3) == "USD");

        }
    }
}
