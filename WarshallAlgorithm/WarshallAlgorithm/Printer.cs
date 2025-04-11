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

    // public static void PrintResult(List<List<double>> resultList, List<int> verticesCount, List<double> probabilityValue)
    // {   
    //     Console.Write("       ");
    //     foreach (var p in probabilityValue)
    //     {
    //         Console.Write(p + " | ");
    //     }
    //     Console.WriteLine();
    //     Console.WriteLine();
    //     
    //     for (int i = 0; i < resultList.Count; i++)
    //     {
    //         Console.Write(verticesCount[i] + ":     ");
    //         
    //         for (int j = 0; j < resultList[i].Count; j++)
    //         {
    //             Console.Write(resultList[i][j] + " ");
    //         }
    //         Console.WriteLine();
    //     }
    // }
    public static void PrintResult(List<List<double>> resultList, List<int> verticesCount, List<double> probabilityValue)
    {
        const int columnWidth = 10;
        string colDivider = "|";
        string rowDivider = "+";

        int totalColumns = probabilityValue.Count + 1;
        string horizontalLine = "";

        for (int i = 0; i < totalColumns; i++)
        {
            horizontalLine += rowDivider + new string('-', columnWidth);
        }
        horizontalLine += rowDivider;

        Console.WriteLine(horizontalLine);
        Console.Write($"{colDivider}{new string(' ', columnWidth)}");
        
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        foreach (var p in probabilityValue)
        {
            Console.Write($"{colDivider}{p, columnWidth:F3}");
        }
        Console.ResetColor();
        
        Console.WriteLine(colDivider);
        Console.WriteLine(horizontalLine);

        for (int i = 0; i < resultList.Count; i++)
        {   
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{colDivider}{verticesCount[i], columnWidth}");
            Console.ResetColor();
            
            for (int j = 0; j < resultList[i].Count; j++)
            {
                Console.Write($"{colDivider}{resultList[i][j], columnWidth:F3}");
            }
            Console.WriteLine(colDivider);
            Console.WriteLine(horizontalLine);
        }
    }

}