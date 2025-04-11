using System.Diagnostics;

namespace WarshallAlgorithm;

public class Algorithm
{
    public static int[,] WarshallAlgorithm(int[,] adjacencyMatrix)
    {
        int len = adjacencyMatrix.GetLength(0);
        int[,] result = new int[len, len];

        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                result[i, j] = adjacencyMatrix[i, j];
            }
        }
        
        for (int k = 0; k < len; k++)
        {
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    result[i, j] = (result[i, j] | (result[i, k] & result[k, j]));
                }
            }
        }

        for (int i = 0; i < len; i++)
        {
            result[i, i] = 1;
        }
        
        return result;
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
                    matrix = WarshallAlgorithm(matrix);
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