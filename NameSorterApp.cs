using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class NameSorterApp
{
    private readonly string inputFileName;
    private readonly string outputFileName;

    public NameSorterApp(string inputFileName, string outputFileName)
    {
        this.inputFileName = inputFileName;
        this.outputFileName = outputFileName;
    }

    public void SortAndSaveNamesToFile()
    {
        List<string> names = ReadNamesFromFile();
        List<string> sortedNames = SortNames(names);
        PrintSortedNames(sortedNames);
        SaveSortedNamesToFile(sortedNames);
    }

    private List<string> ReadNamesFromFile()
    {
        List<string> names = new List<string>();

        try
        {
            using (StreamReader reader = new StreamReader(inputFileName))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    names.Add(line);
                }
            }
        }
        catch (IOException e)
        {
            throw new IOException($"Failed to read the names file: {inputFileName}", e);
        }

        if (names.Count == 0)
        {
            throw new ArgumentException($"The names file is empty: {inputFileName}");
        }

        return names;
    }


    private List<string> SortNames(List<string> names)
    {
        List<string> sortedNames = new List<string>();

        List<List<string>> listOfLists = new List<List<string>>();

        foreach (string name in names)
        {
            string[] nameParts = name.Split(' ');
            List<string> nameList = new List<string>();
            for (int i = nameParts.Length - 1; i >= 0; i--)
            {
                nameList.Add(nameParts[i]);
            }
            listOfLists.Add(nameList);
        }

        listOfLists.Sort(new NameComparator());

        foreach (List<string> nameList in listOfLists)
        {
            nameList.Reverse();
            string fullName = string.Join(" ", nameList);
            sortedNames.Add(fullName);
        }

        return sortedNames;
    }
    private class NameComparator : IComparer<List<string>>
    {
        public int Compare(List<string>? names1, List<string>? names2)
        {
            if (names1 is null || names2 is null)
            {
                throw new ArgumentNullException();
            }

            int minLength = Math.Min(names1.Count, names2.Count);

            for (int i = 0; i < minLength; i++)
            {
                int result = names1[i].CompareTo(names2[i]);
                if (result != 0)
                {
                    return result;
                }
            }

            return names1.Count.CompareTo(names2.Count);
        }
    }


    private void PrintSortedNames(List<string> sortedNames)
    {
        foreach (string sortedName in sortedNames)
        {
            Console.WriteLine(sortedName);
        }
    }

    private void SaveSortedNamesToFile(List<string> sortedNames)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                foreach (string sortedName in sortedNames)
                {
                    writer.WriteLine(sortedName);
                }
            }
        }
        catch (IOException e)
        {
            throw new IOException($"Failed to write the sorted names to the file: {outputFileName}", e);
        }
    }

    public static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("Please provide the input file name.");
            return;
        }

        string inputFileName = args[0];
        string outputFileName = "sorted-names-list.txt";

        NameSorterApp nameSorter = new NameSorterApp(inputFileName, outputFileName);

        try
        {
            nameSorter.SortAndSaveNamesToFile();
        }
        catch (IOException e)
        {
            Console.Error.WriteLine($"Error occurred: {e.Message}");
        }
    }
}
