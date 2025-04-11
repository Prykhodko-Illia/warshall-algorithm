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

        List<int> vertices = new List<int> { 1, 10, 25, 50, 100, 150, 200, 300, 400, 500};
        const uint reps = 20;
        // List<int> vertices = new List<int> { 1, 10, 23, 50, 100};
        List<double> probabilities = new List<double>{0.05, 0.1, 0.2, 0.4, 0.5, 0.75, 1};
        var results = WarshallAlgoritmTimeMeasure(vertices, probabilities, reps);
        
        Printer.PrintResult(results, vertices, probabilities, reps);
    }
    public static List<List<List<double>>> WarshallAlgoritmTimeMeasure(List<int> verticesCount, List<double> probabilityValue, uint reps)
    {
        var resultList = new List<List<List<double>>>();

        foreach (int v in verticesCount)
        {
            List<List<double>> temporary1 = new List<List<double>>();   
            
            foreach (double p in probabilityValue)
            {
                var temporary2 = new List<double>();
                
                for (int i = 0; i < reps; i++)
                {
                    var matrix = Graph.GenerateAdjacencyMatrix(v, p);
                    Stopwatch stopwatch = new Stopwatch();
                    
                    stopwatch.Start();
                    matrix = Graph.WarshallAlgorithm(matrix);
                    stopwatch.Stop();
                    
                    temporary2.Add(Math.Round(stopwatch.Elapsed.TotalMilliseconds, 4));
                    
                    Console.WriteLine($"Success ({v}, {p}), rep({i + 1}): {stopwatch.Elapsed.TotalMilliseconds}");
                }
                temporary1.Add(temporary2);

                Console.WriteLine($"Success ({v}, {p})");
                Console.WriteLine("...");
            }
            resultList.Add(temporary1);
            
            Console.WriteLine($"Success {v}!");
            Console.WriteLine("...");
        }
            
        return resultList;
    }
}

