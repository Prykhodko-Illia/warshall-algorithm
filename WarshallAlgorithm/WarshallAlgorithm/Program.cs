namespace WarshallAlgorithm;

class Program
{
    public static void Main(string[] args)
    {
        var matrix = Graph.GenerateAdjacencyMatrix(12, 0.2);
        Printer.PrintMatrix(matrix);
        
        var list = Graph.ConvertToAdjacencyList(matrix);
        Printer.PrintList(list);
        
        var matrix2 = Graph.ConvertToAdjacencyMatrix(list);
        Printer.PrintMatrix(matrix2);
    }
}

