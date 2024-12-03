namespace Advent_of_Code_2024;

public class DataManipulator
{
    public static void ReadData(List<string> list, string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string? line = "";
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }
        }
    }
    
    public static void ConvertStringDataToIntData(List<string> strData, List<List<int>> intData, string splitSign)
    {
        foreach (var line in strData)
        {
            string[] strValues = line.Split(splitSign);
            List<int> tempIntList = [];
            
            foreach (var value in strValues)
            {
                tempIntList.Add(Int32.Parse(value));    
            }
            
            intData.Add(tempIntList);
        }
    }
}