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
        // Read names from the input file
        List<string> names = ReadNamesFromFile();

        // Sort the names
        List<string> sortedNames = SortNames(names);

        // Print sorted names to the console
        PrintSortedNames(sortedNames);

        // Save sorted names to the output file
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

        // Split names into parts, reverse the parts, and store them in a list of lists
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

        // Sort the list of lists using the NameComparator
        listOfLists.Sort(new NameComparator());

        // Reverse the name parts in each list, join them into full names, and add them to the sorted names list
        foreach (List<string> nameList in listOfLists)
        {
            nameList.Reverse();
            string fullName = string.Join(" ", nameList);
            sortedNames.Add(fullName);
        }

        return sortedNames;
    }

    // Custom comparator for comparing two lists of strings (name parts)
    private class NameComparator : IComparer<List<string>>
    {
        public int Compare(List<string>? names1, List<string>? names2)
        {
            if (names1 is null || names2 is null)
            {
                throw new ArgumentNullException();
            }

            int minLength = Math.Min(names1.Count, names2.Count);

            // Compare name parts element by element
            for (int i = 0; i < minLength; i++)
            {
                int result = names1[i].CompareTo(names2[i]);
                if (result != 0)
                {
                    return result;
                }
            }

            // If all name parts are equal, compare based on the number of name parts
            return names1.Count.CompareTo(names2.Count);
        }
    }

    private void PrintSortedNames(List<string> sortedNames)
    {
        // Print each sorted name to the console
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
                // Write each sorted name to the output file
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

        // Create a new instance of NameSorterApp
        NameSorterApp nameSorter = new NameSorterApp(inputFileName, outputFileName);

        try
        {
            // Sort and save names to file
            nameSorter.SortAndSaveNamesToFile();
        }
        catch (IOException e)
        {
            Console.Error.WriteLine($"Error occurred: {e.Message}");
        }
    }
}
