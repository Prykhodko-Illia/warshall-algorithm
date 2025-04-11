namespace WarshallAlgorithm;

public class Printer
{
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("——————————————————————————————————————————————");
    }

    public static void PrintList(List<int>[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write($"{i + 1}: ");

            for (int j = 0; j < list[i].Count; j++)
            {
                Console.Write(list[i][j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("——————————————————————————————————————————————");
    }

    public static void PrintResult(List<List<List<double>>> resultList, List<int> vertices,
        List<double> probabilityValue, uint reps)
    {
        Console.WriteLine();
        for (int i = 0; i < vertices.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Vertex: {vertices[i]}");
            Console.ResetColor();
            
            Console.WriteLine();
            for (int j = 0; j < probabilityValue.Count; j++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Probability: {probabilityValue[j]}");
                Console.ResetColor();
                
                for (int k = 0; k < reps; k++)
                {
                    Console.Write(resultList[i][j][k] + " ");
                }
                List<double> list = resultList[i][j];
                double avg = Math.Round((list.Sum() - list.Min() - list.Max()) / (reps - 2), 4);
                
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("\n" + $"avg: {avg}");
                Console.ResetColor();
                
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————");
        }
    }
}