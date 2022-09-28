using LuccaDevises;
try
{
    if (args.Length != 1)
        throw new ArgumentException("Le nombre d'argument attendu : 1");

    var parsedFile = FileReader.ParseFile(args[0]);

    var graph = parsedFile.GenerateGraph();

    var path = graph.ShortestPath(parsedFile.Source, parsedFile.Target);

    var result = graph.ComputeChange(path, parsedFile.SourceAmount);

    Console.WriteLine(result);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
