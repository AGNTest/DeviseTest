using LuccaDevises.Models;

namespace LuccaDevises
{
    public static class ComputeChanges
    {
        public static int ComputeChange(this DeviseGraph graph, IEnumerable<string> path, int valueToConvert)
        {
            var listPath = path.ToList();
            decimal decimalValueToConvert = valueToConvert;
            for (int i = 0; i < listPath.Count - 1; i++)
            {
                decimalValueToConvert = Decimal.Round(decimalValueToConvert * graph.Graph[listPath[i]][listPath[i + 1]], 4);
            }
            return Decimal.ToInt32(Math.Round(decimalValueToConvert));
        }
    }
}
