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
    
    public static void PrintResult(List<List<List<double>>> resultList, List<int> verticesCount,
        List<double> probabilityValue, uint reps)
    {
        int colWidth = 12;

        using (StreamWriter writer = new StreamWriter("results_output.txt"))
        {
            Console.WriteLine("---------RESULTS----------");
            writer.WriteLine("---------RESULTS----------");

            for (int i = 0; i < verticesCount.Count; i++)
            {
                string separator = "+" + new string('-', colWidth);
                for (int k = 0; k < reps; k++)
                    separator += "+" + new string('-', colWidth);
                separator += "+";

                Console.WriteLine(separator);
                writer.WriteLine(separator);

                string vertexLabel = $"Vertex: {verticesCount[i]}";
                string vertexLine = "|" + "".PadRight(colWidth) + "|" + vertexLabel.PadRight(colWidth * (int)reps) + "    |";

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(vertexLine);
                Console.ResetColor();
                writer.WriteLine(vertexLine);

                Console.WriteLine(separator);
                writer.WriteLine(separator);

                string header = "|" + "Prob".PadLeft(colWidth);
                for (int k = 0; k < reps; k++)
                    header += "|" + $"Res{k + 1}".PadLeft(colWidth);
                header += "|";

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(header);
                Console.ResetColor();
                writer.WriteLine(header);

                Console.WriteLine(separator);
                writer.WriteLine(separator);

                for (int j = 0; j < probabilityValue.Count; j++)
                {
                    string probCol = "|" + probabilityValue[j].ToString("F2").PadLeft(colWidth);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(probCol);
                    Console.ResetColor();
                    writer.Write(probCol);

                    string row = "";
                    for (int k = 0; k < reps; k++)
                        row += "|" + resultList[i][j][k].ToString("F4").PadLeft(colWidth);
                    row += "|";

                    Console.WriteLine(row);
                    writer.WriteLine(row);

                    Console.WriteLine(separator);
                    writer.WriteLine(separator);
                }

                Console.WriteLine();
                writer.WriteLine();
            }
        }
    }

}