using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Advent_of_Code_2024.Day4;

public class Day4_1
{
    public void Run()
    {
        var path = "..\\..\\..\\src\\Day4\\data.txt";
        List<string> data = [];
        DataManipulator.ReadData(data, path);

        int countResult = GetResult(data);
        Console.WriteLine($"result: {countResult}");
    }

    private int GetResult(List<string> data)
    {
        int result = 0;
        
        result += GetNumberOfMatchesFromLists(data, FlatVerticallyIntoList);
        result += GetNumberOfMatchesFromLists(data, FlatHorizontallyIntoList);
        result += GetNumberOfMatchesFromLists(data, FlatDiagonalIntoList);
        result += GetNumberOfMatchesFromLists(data, FlatReserveDiagonalIntoList);

        return result;
    }

    private int GetNumberOfMatchesFromLists(List<string> data, Func<List<string>, List<string>> func)
    {
        int result = 0;
        string firstPattern = "XMAS";
        string secondPattern = "SAMX";
        List<string> strings = func(data);

        foreach (var str in strings)
        {
            result += Regex.Matches(str, firstPattern).Count;
            result += Regex.Matches(str, secondPattern).Count;
        }

        return result;
    }

    private List<string> FlatReserveDiagonalIntoList(List<string> data)
    {
        List<string> results = [];
        int columnsNumber = data[0].Length;
        int rowsNumber = data.Count;

        for (int i = 0; i < rowsNumber; i++)
        {
            string tempString = "";

            for (int j = 0; j < columnsNumber; j++)
            {
                if (i + j >= rowsNumber)
                {
                    break;
                }
                
                tempString += data[i + j][columnsNumber - 1 - j];
            }
            results.Add(tempString);
        }

        for (int j = 1; j < columnsNumber; j++)
        {
            string tempString = "";
            for (int i = 0; i < rowsNumber; i++)
            {
                if (columnsNumber - 1 - j - i < 0)
                {
                    break;
                }

                tempString += data[i][columnsNumber - 1 - j - i];
            }

            results.Add(tempString);
        }

        return results;
    }

    private List<string> FlatDiagonalIntoList(List<string> data)
    {
        List<string> results = [];
        int columnsNumber = data[0].Length;
        int rowsNumber = data.Count;
    
        for (int i = 0; i < columnsNumber; i++)
        {
            string tempString = "";
            for (int j = 0; j < rowsNumber; j++)
            {
                if (i + j >= columnsNumber)
                {
                    break;
                }
        
                tempString += data[i + j][j];
            }
            results.Add(tempString);
        }
    
        for (int j = 1; j < rowsNumber; j++)
        {
            string tempString = "";
            for (int i = 0; i < columnsNumber; i++)
            {
                if (i + j >= rowsNumber)
                {
                    break;
                }
    
                tempString += data[i][i + j];
            }
            results.Add(tempString);
        }
    
        return results;
    }

    private List<string> FlatHorizontallyIntoList(List<string> data)
    {
        return data;
    }
    
    private List<string> FlatVerticallyIntoList(List<string> data)
    {
        List<string> results = [];

        for (int i = 0; i < data[0].Length; i++)
        {
            string tempString = "";
            foreach (var str in data)
            {
                tempString += str[i];
            }
            results.Add(tempString);
        }

        return results;
    }
}