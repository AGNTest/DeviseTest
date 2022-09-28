using LuccaDevises.Models;

namespace LuccaDevises
{
    public static class GraphPathfinding
    {
        public static IEnumerable<string> ShortestPath(this DeviseGraph graph, string startDevise, string endDevise)
        {
            if (!graph.Graph.ContainsKey(startDevise))
            {
                throw new Exception($"Devise {startDevise} non trouvée");
            }
            
            List<string> path = new();
            Stack<string> current = new();

            RecursivePath(path, endDevise, current, graph, startDevise, new Dictionary<string, int>(), 0);


            return path;
        }

        private static void RecursivePath(List<string> winner, string endDevise, Stack<string> current, DeviseGraph graph, string currentDevise, Dictionary<string, int> alreadyFind, int deep)
        {

            current.Push(currentDevise);
            //Si la devise n'a jamais été parcourue, alors on la marque
            if (!alreadyFind.ContainsKey(currentDevise))
                alreadyFind.Add(currentDevise, deep);
            //Si la devise a été trouvée à une profondeur moindre, alors sort (remonte au parent)
            if (alreadyFind[currentDevise] < deep)
            {
                current.Pop();
                return;
            }

            alreadyFind[currentDevise] = deep;
            //Si la devise est la cible, alors sort (remonte au parent)
            if (currentDevise == endDevise)
            {
                //Si c'est la première fois ou que le chemin est plus court pour arriver à la devise cible, on conserve le chemin.
                if (winner.Count == 0 || winner.Count > current.Count)
                {
                    CopyValues(winner, current);
                }
                current.Pop();
                return;
            }
            //Sinon, on parcourt les enfants.
            foreach (var child in graph.Graph[currentDevise])
            {
                RecursivePath(winner, endDevise, current, graph, child.Key, alreadyFind, deep + 1);
            }
            current.Pop();
        }


        private static void CopyValues(List<string> receiver, Stack<string> origin)
        {
            receiver.Clear();
            var listOrigin = origin.Reverse().ToList();
            for (int i = 0; i < listOrigin.Count; i++)
            {
                receiver.Add(listOrigin[i]);
            }
        }
    }
}
