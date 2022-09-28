using LuccaDevises;

namespace TestDevise
{
    [TestClass]
    public class CompleteTests
    {
        [TestMethod]
        public void FromExempleTest()
        {

            var parsedFile = FileReader.ParseFile($"{GlobalVariableTest.PathFiles}\\FromAnnonce.txt");

            var graph = parsedFile.GenerateGraph();

#pragma warning disable CS8604 // Existence possible d'un argument de r�f�rence null pour le param�tre 'endDevise' dans 'IEnumerable<string> GraphPathfinding.ShortestPath(DeviseGraph graph, string startDevise, string endDevise)'.
#pragma warning disable CS8604 // Existence possible d'un argument de r�f�rence null pour le param�tre 'startDevise' dans 'IEnumerable<string> GraphPathfinding.ShortestPath(DeviseGraph graph, string startDevise, string endDevise)'.
            var path = graph.ShortestPath(parsedFile.Source, parsedFile.Target);
#pragma warning restore CS8604 // Existence possible d'un argument de r�f�rence null pour le param�tre 'startDevise' dans 'IEnumerable<string> GraphPathfinding.ShortestPath(DeviseGraph graph, string startDevise, string endDevise)'.
#pragma warning restore CS8604 // Existence possible d'un argument de r�f�rence null pour le param�tre 'endDevise' dans 'IEnumerable<string> GraphPathfinding.ShortestPath(DeviseGraph graph, string startDevise, string endDevise)'.

            var result = graph.ComputeChange(path, parsedFile.SourceAmount);

            Assert.AreEqual(59033, result);
        }
    }
}