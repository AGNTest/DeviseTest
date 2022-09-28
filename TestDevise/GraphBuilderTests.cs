using LuccaDevises;

namespace TestDevise
{
    [TestClass]
    public class GraphBuilderTests
    {
        [TestMethod]
        public void StandartTest()
        {
            var result = new LuccaDevises.Models.ParsedDeviseFile()
            {
                Source = "EUR",
                Target = "USD",
                SourceAmount = 1,
                CurrencyRates = new List<LuccaDevises.Models.ParsedCurrencyRate>()
                {
                    new LuccaDevises.Models.ParsedCurrencyRate(){ Source = "EUR", Target = "CAD", CurrencyRate = 1.3251m},
                    new LuccaDevises.Models.ParsedCurrencyRate(){ Source = "EUR", Target = "USD", CurrencyRate = 1.0000m},
                    new LuccaDevises.Models.ParsedCurrencyRate(){ Source = "EUR", Target = "YEN", CurrencyRate = 10.0000m},
                    new LuccaDevises.Models.ParsedCurrencyRate(){ Source = "CFA", Target = "EUR", CurrencyRate = 655.5000m},
                }
            }.GenerateGraph();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Graph.ContainsKey("EUR"));
            Assert.IsTrue(result.Graph.ContainsKey("CAD"));
            Assert.IsTrue(result.Graph.ContainsKey("USD"));
            Assert.IsTrue(result.Graph.ContainsKey("YEN"));
            Assert.IsTrue(result.Graph.ContainsKey("CFA"));
            Assert.IsTrue(result.Graph["EUR"].Count == 4);
            Assert.IsTrue(result.Graph["EUR"]["CAD"] == 1.3251m);
            Assert.IsTrue(result.Graph["EUR"]["CFA"] == Decimal.Round(1 / 655.5000m, 4));
            Assert.IsTrue(result.Graph["CFA"]["EUR"] == 655.5000m);
        }
    }
}
