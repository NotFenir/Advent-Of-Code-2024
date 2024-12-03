namespace Advent_of_Code_2024.Day1;

public class Day1_2
{
    public void Run()
    {
        List<string> strLeftColumn = [];
        List<string> strRightColumn = [];
        IEnumerable<int> leftColumn;
        IEnumerable<int> rightColumn;
        List<int> datasToCalculate = [];
        
        AddDataToLists(strLeftColumn, strRightColumn);
        
        leftColumn = strLeftColumn.Select(int.Parse).ToArray();
        rightColumn = strRightColumn.Select(int.Parse).ToArray();
        

        
        foreach (int number in leftColumn)
        {
            int numberOfSimilarNumbers = rightColumn.Count(x => x == number);
            datasToCalculate.Add(numberOfSimilarNumbers * number);    
        }

        Console.WriteLine(datasToCalculate.Sum());
        
        

    }

    private static void AddDataToLists(List<string> strLeftTable, List<string> strRightTable)
    {
        using (StreamReader reader = new StreamReader("..\\..\\..\\src\\Day1\\exercise 1.txt"))
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