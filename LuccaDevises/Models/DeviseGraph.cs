namespace LuccaDevises.Models
{
    public class DeviseGraph
    {
        public Dictionary<string, Dictionary<string, decimal>> Graph { get; set; } = new Dictionary<string, Dictionary<string, decimal>>();
    }
}
