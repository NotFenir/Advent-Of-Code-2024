﻿namespace Advent_of_Code_2024.Day2;

public class Day2_1
{
    public void Run()
    {
        var path = "..\\..\\..\\src\\Day2\\data.txt";
        List<List<int>> data = [];
        List<string> stringData = [];

        DataManipulator.ReadData(stringData, path);
        DataManipulator.ConvertStringDataToIntData(stringData, data, " ");
        
        var safeReports = GetNumberOfSafeReports(data);
        Console.WriteLine(safeReports);

    }

    private int GetNumberOfSafeReports(List<List<int>> data)
    {
        int counterOfGoodLines = 0;
        
        foreach (var (line, i) in data.Select((val, i) => (val, i)))
        {
            var diffs = GetDiffs(line);
            
            bool isFirstConditionCorrect = IsIncreasingOrDecreasing(diffs);
            bool isSecondConditionCorrect = HasCorrectSteps(diffs);

            Console.WriteLine($"1: {isFirstConditionCorrect}\t2:{isSecondConditionCorrect}\n\n");

            if (isFirstConditionCorrect && isSecondConditionCorrect)
            {
                counterOfGoodLines++;
            }
        }

        return counterOfGoodLines;
    }

    private bool HasCorrectSteps(List<int> diffs)
    {
        int[] correctDiffs = [1, 2, 3];
        return diffs.All(x => correctDiffs.Contains(Math.Abs(x)));
    }

    private bool IsIncreasingOrDecreasing(List<int> diffs)
    {
        bool isIncreasing = diffs.All(x => x > 0);
        bool isDecreasing = diffs.All(x => x < 0);

        return isIncreasing || isDecreasing;
    }

    private List<int> GetDiffs(List<int> data)
    {
        List<int> diffs = [];
        for (int i = 1; i < data.Count; i++)
        {
            diffs.Add(data[i] - data[i-1]);
        }

        return diffs;
    }
}