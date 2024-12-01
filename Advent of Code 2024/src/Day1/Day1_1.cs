using System.Runtime.InteropServices;

namespace Advent_of_Code_2024.Day1;

public class Day1_1
{
    public void Run()
    {
        List<string> strLeftTable = [];
        List<string> strRightTable = [];
        List<int> distances = [];
        
        AddDataToLists(strLeftTable, strRightTable);

        int[] leftTable = new int[strLeftTable.Count];
        int[] rightTable = new int[strRightTable.Count];

        for (int i = 0; i < strLeftTable.Count; i++)
        {
            leftTable[i] = Int32.Parse(strLeftTable[i]);
            rightTable[i] = Int32.Parse(strRightTable[i]);
        }
        
        Array.Sort(leftTable);
        Array.Sort(rightTable);


        for (int i = 0; i < leftTable.Length; i++)
        {
            distances.Add(Math.Abs(leftTable[i] - rightTable[i]));
        }

        int distance = distances.Sum();
        Console.WriteLine(distance);
    }

    private static void AddDataToLists(List<string> strLeftTable, List<string> strRightTable)
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\mwisn\\Desktop\\Programy\\Rider Projects\\Advent of Code 2024\\Advent of Code 2024\\src\\Day1\\exercise 1.txt"))
        {
            string? line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] temp = line.Split("   ");
                strLeftTable.Add(temp[0]);
                strRightTable.Add(temp[1]);
            }
        }
    }
}