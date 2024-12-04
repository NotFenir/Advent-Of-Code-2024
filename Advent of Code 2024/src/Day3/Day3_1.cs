namespace Advent_of_Code_2024.Day3;

public class Day3_1
{
    public void Run()
    {
        string path = "..\\..\\..\\src\\Day3\\data.txt";
        List<string> data = [];
        DataManipulator.ReadData(data, path);
        int result = GetSum(data);
        
        Console.WriteLine(result);
    }

    private int GetSum(List<string> data)
    {
        string startString = "mul(";
        int sum = 0;
        
        foreach (var line in data)
        {
            string tempString = line;
            
            while (tempString.Contains(startString))
            {
                (tempString, var value) = iterationStep(tempString, startString);
                sum += value;
            }
        }

        return sum;
    }

    private (string, int) iterationStep(string tempString, string startString)
    {
        int start = tempString.IndexOf(startString, 0) + startString.Length;
        var (comaIndex, isComaFound) = FindSpecificSignIndex(",", tempString, start);
        var (closedBracketIndex, isClosedBracketFound) = FindSpecificSignIndex(")", tempString, comaIndex + 1);

        if (!(isClosedBracketFound && isComaFound))
        {
            return (tempString.Substring(start), 0);
        }

        int firstValue = int.Parse(tempString.Substring(start, comaIndex - start));
        int secondValue = int.Parse(tempString.Substring(comaIndex + 1, closedBracketIndex - comaIndex - 1));

        return (tempString.Substring(closedBracketIndex), firstValue * secondValue);
    }

    private static (int, bool) FindSpecificSignIndex(string sign, string tempString, int startIndex)
    {
        bool isSignFounded = false;
        int singIndex = 0;
        
        for (int i = 0; i < 4; i++)
        {
            if (tempString[startIndex + i].ToString() == sign)
            {
                singIndex = startIndex + i;
                isSignFounded = true;
                break;
            }
        }

        return (singIndex, isSignFounded);
    }
}