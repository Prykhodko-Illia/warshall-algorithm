namespace WarshallAlgorithm;

public class Graph
{
    public static int[,] GenerateAdjacencyMatrix(int n, double p)
    {
        Random random = new Random();
        
        int[,] matrix = new int[n, n];
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 1) continue;
                
                if (i == j) matrix[i, j] = 0;
                else if (random.NextDouble() < p)
                {
                    matrix[i, j] = 1;
                    matrix[j, i] = 1;
                }
            }
        }
        return matrix;
    }

    public static List<int>[] ConvertToAdjacencyList(int[,] adjacencyMatrix)
    {
        var adjacencyList = new List<int>[adjacencyMatrix.GetLength(0)];
        
        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            adjacencyList[i] = new List<int>();
            
            for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                if (adjacencyMatrix[i, j] == 1)
                {
                    adjacencyList[i].Add(j + 1);
                }
            }
        }
        return adjacencyList;
    }

    public static int[,] ConvertToAdjacencyMatrix(List<int>[] adjacencyList)
    {
        var adjacencyMatrix = new int[adjacencyList.Length, adjacencyList.Length];

        for (int i = 0; i < adjacencyList.Length; i++)
        {
            for (int j = 0; j < adjacencyList[i].Count; j++)
            {
                adjacencyMatrix[i, (adjacencyList[i][j] - 1)] = 1;
            }
        }
        return adjacencyMatrix;
    }

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
}