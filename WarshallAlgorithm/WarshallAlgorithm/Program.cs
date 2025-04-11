
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
        // List<int> vertices = new List<int> { 1, 10, 25, 50};
        List<double> probabilities = new List<double>{0.05, 0.1, 0.2, 0.4, 0.5, 0.75, 1};
        var results = Algorithm.WarshallAlgoritmTimeMeasure(vertices, probabilities, reps);
        
        Printer.PrintResult(results, vertices, probabilities, reps);
    }
}

