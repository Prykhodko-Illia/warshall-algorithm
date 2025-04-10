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
}