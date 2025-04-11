using System.Diagnostics;

namespace WarshallAlgorithm;

class Program
{
    public static void Main(string[] args)
    {
        // var matrix = Graph.GenerateAdjacencyMatrix(12, 0.02);
        // Printer.PrintMatrix(matrix);
        //
        // var list = Graph.ConvertToAdjacencyList(matrix);
        // Printer.PrintList(list);
        //
        // var matrix2 = Graph.ConvertToAdjacencyMatrix(list);
        // Printer.PrintMatrix(matrix2);
        //
        // var reachMatrix = Graph.WarshallAlgorithm(matrix2);
        // Printer.PrintMatrix(reachMatrix);

        // List<int> vertices = new List<int> { 1, 10, 25, 50, 100, 150, 200, 300, 400, 500};
        List<int> vertices = new List<int> { 1, 10, 23, 50, 100, 150};
        List<double> probabilities = new List<double>{0.05, 0.1, 0.2, 0.4, 0.5, 0.75, 1};
        var results = WarshallAlgoritmTimeMeasure(vertices, probabilities);
        
        Printer.PrintResult(results, vertices, probabilities);
    }
    public static List<List<double>> WarshallAlgoritmTimeMeasure(List<int> verticesCount, List<double> probabilityValue)
    {
        var resultList = new List<List<double>>();

        foreach (int v in verticesCount)
        {
            var temporary = new List<double>();
                
            foreach (double p in probabilityValue)
            {
                var matrix = Graph.GenerateAdjacencyMatrix(v, p);
                Stopwatch stopwatch = new Stopwatch();
                    
                stopwatch.Start();
                matrix = Graph.WarshallAlgorithm(matrix);
                stopwatch.Stop();
                    
                temporary.Add(Math.Round(stopwatch.Elapsed.TotalMilliseconds, 4));
                    
                Console.WriteLine($"Success ({v}, {p}): {stopwatch.Elapsed.TotalMilliseconds}");
            }
                
            resultList.Add(temporary);
            Console.WriteLine($"Success {v}!");
            Console.WriteLine("...");
        }
            
        return resultList;
    }
}

