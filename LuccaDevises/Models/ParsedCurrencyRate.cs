namespace LuccaDevises.Models
{
    public class ParsedCurrencyRate
    {
        public string Source { get; set; } = String.Empty;
        public string Target { get; set; } = String.Empty;
        public decimal CurrencyRate { get; set; } = 0;
    }
}
