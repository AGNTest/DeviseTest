using LuccaDevises.Models;

namespace LuccaDevises
{
    public static class GraphBuilder
    {
        public static DeviseGraph GenerateGraph(this ParsedDeviseFile parsedFile)
        {
            DeviseGraph graph = new ();

            foreach (var currencyRate in parsedFile.CurrencyRates)
            {
                //On copie les valeurs dans les deux sens.
                AddValueInGraph(graph, currencyRate.Source, currencyRate.Target, currencyRate.CurrencyRate);
                AddValueInGraph(graph, currencyRate.Target, currencyRate.Source, Decimal.Round(1 / currencyRate.CurrencyRate, 4));
            }

            return graph;

        }

        private static void AddValueInGraph(DeviseGraph graph, string source, string target, decimal amount)
        {
            if (graph.Graph.ContainsKey(source))
            {
                graph.Graph[source].TryAdd(target, amount);
            }
            else
            {
                if (graph.Graph.TryAdd(source, new Dictionary<string, decimal>()))
                    graph.Graph[source].TryAdd(target, amount);
            }
        }
    }
}
