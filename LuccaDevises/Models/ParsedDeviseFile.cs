namespace LuccaDevises.Models
{
    public class ParsedDeviseFile
    {
        public string Source { get; set; } = String.Empty;
        public string Target { get; set; } = String.Empty;
        public int SourceAmount { get; set; } = 0;

        public List<ParsedCurrencyRate> CurrencyRates { get; set; } = new List<ParsedCurrencyRate>();
    }
}
