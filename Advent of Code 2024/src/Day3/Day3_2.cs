using System.Text.RegularExpressions;

namespace Advent_of_Code_2024.Day3;

public class Day3_2
{
    private bool _isMultiplyAvailable = true;
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
        _isMultiplyAvailable = true;
        
        foreach (var line in data)
        {
            string tempString = line;
            
            while (tempString.Contains(startString))
            {
                (tempString, var value) = iterationStep(tempString);
                sum += value;
            }
        }

        return sum;
    }
    
    private (string, int) iterationStep(string line)
    {
        string startString = "mul";
        int start = line.IndexOf(startString, 0) + startString.Length;
        var (openingBracketIndex, isOpeningBracketFound) = FindSpecificSignIndex("(", line, start);
        var (comaIndex, isComaFound) = FindSpecificSignIndex(",", line, openingBracketIndex + 1);
        var (closedBracketIndex, isClosedBracketFound) = FindSpecificSignIndex(")", line, comaIndex + 1);

        CheckIsMultiplyAvailable(line, start);

        if (!(isClosedBracketFound && isComaFound && isOpeningBracketFound) || !_isMultiplyAvailable)
        {
            return (line.Substring(start), 0);
        }

        int firstValue = int.Parse(line.Substring(openingBracketIndex + 1, comaIndex - openingBracketIndex - 1));
        int secondValue = int.Parse(line.Substring(comaIndex + 1, closedBracketIndex - comaIndex - 1));

        return (line.Substring(closedBracketIndex), firstValue * secondValue);
    }

    private void CheckIsMultiplyAvailable(string line, int start)
    {
        var doIndex = Regex.Matches(line, Regex.Escape("do()"))
            .Select(x => x.Index)
            .Where(x => start - x > 0)
            .DefaultIfEmpty(-1)
            .MinBy(x => start - x);

        var dontIndex = Regex.Matches(line, Regex.Escape("don't()"))
            .Select(x => x.Index)
            .Where(x => start - x > 0)
            .DefaultIfEmpty(-1)
            .MinBy(x => start - x);

        if (!(doIndex < 0 && dontIndex < 0))
        {
            _isMultiplyAvailable = start - dontIndex > start - doIndex;
        }

    }

    private static (int, bool) FindSpecificSignIndex(string sign, string tempString, int startIndex)
    {
        bool isSignFounded = false;
        int signIndex = 0;
        
        for (int i = 0; i < 4; i++)
        {
            try
            {
                if (tempString[startIndex + i].ToString() == sign)
                {
                    signIndex = startIndex + i;
                    isSignFounded = true;
                    break;
                }
            }
            catch (Exception e)
            {
                break;
            }
            
        }

        return (signIndex, isSignFounded);
    }
}