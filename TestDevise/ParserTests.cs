using LuccaDevises;

namespace TestDevise
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void TestHeader()
        {
            var result = FileReader.ParseFile($"{GlobalVariableTest.PathFiles}\\RatesChanges1.txt");
            Assert.IsNotNull(result);
            Assert.IsTrue(result?.Source?.Equals("EUR"));
            Assert.IsTrue(result?.SourceAmount == 15);
            Assert.IsTrue(result?.Target?.Equals("USD"));
        }

        [TestMethod]
        public void TestRates()
        {
            var result = FileReader.ParseFile($"{GlobalVariableTest.PathFiles}\\RatesChanges1.txt");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.CurrencyRates.Count == 3);
            Assert.IsTrue(result.CurrencyRates[0].Source == "EUR");
            Assert.IsTrue(result.CurrencyRates[0].Target == "USD");
            Assert.IsTrue(result.CurrencyRates[0].CurrencyRate == 4.6521m);
            Assert.IsTrue(result.CurrencyRates[1].Source == "CFA");
            Assert.IsTrue(result.CurrencyRates[1].Target == "USD");
            Assert.IsTrue(result.CurrencyRates[1].CurrencyRate == 2.0001m);
            Assert.IsTrue(result.CurrencyRates[2].Source == "USC");
            Assert.IsTrue(result.CurrencyRates[2].Target == "EUR");
            Assert.IsTrue(result.CurrencyRates[2].CurrencyRate == 0.3000m);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestException1()
        {
            var result = FileReader.ParseFile($"{GlobalVariableTest.PathFiles}\\Inexistant.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestException2()
        {
            var result = FileReader.ParseFile($"{GlobalVariableTest.PathFiles}\\InvalidFile.txt");
        }

    }
}