# Name Sorter App

## Introduction
Name Sorter App is a .NET application that reads a list of names from a text file, reverses each name, sorts them in ascending order, and saves the sorted names to a new text file. It provides a command-line interface to execute the sorting operation.

## Prerequisites
To run the Name Sorter App, ensure that you have the following software installed on your system:
- .NET SDK 6.0 or later
- Command-line interface (Terminal or Command Prompt)

## Compilation using dotnet run

To compile and run the .NET application using the `dotnet run` command, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the directory where the `NameSorterApp.cs` file is located.
3. Run the following command to publish the application:

```
dotnet publish -c release -r <runtime_identifier> --self-contained
```

Replace `<runtime_identifier>` with the appropriate value for your target runtime. For example, if you are targeting Windows with an x64 architecture, the runtime identifier would be `win-x64`. This command will generate the executable files in the publish directory. In this case it will be `ubuntu.16.04-x64`.

4. Navigate to the publish directory:

```
cd bin/release/net6.0/ubuntu.16.04-x64/publish
```

5. Run the application using the following command:

```
./publish/name-sorter ./unsorted-names-list.txt
```

Replace `unsorted-names-list.txt` with the path to your input file containing the list of names.

By following these steps, the .NET application will be compiled, published, and executed, sorting the names and saving the sorted names to a new file.

I saved the publish folder in the main directory also you can go there can repeat the same steps.

## Functionality

### `SortAndSaveNamesToFile()`
This method is responsible for orchestrating the entire sorting and saving process. It reads the names from the input file, reverses and sorts them, prints the sorted names to the console, and saves them to the output file.

### `ReadNamesFromFile()`
This method reads the names from the input file and returns them as a list. It uses a `StreamReader` to read each line from the file and adds it to the list of names.

### `SortNames(List<string> names)`

The `SortNames` function is responsible for sorting a list of names based on specific criteria. It takes a `List<string>` of names as input and returns a new list containing the sorted names.

#### Sorting Logic

The sorting algorithm follows a specific order to sort the names. The criteria for sorting are as follows:

1. The names are split into individual components (first name, middle name, last name) using spaces as delimiters.
2. Each name component is stored in a separate list, and the order of components is reversed.
3. A list of lists is created, where each inner list contains the reversed name components of a single name.
4. The list of lists is sorted based on the following rules:
    - Names are compared by their first name first. If the first names are equal, the comparison moves to the second name, and so on.
    - The comparison is performed in lexicographic order, considering the ASCII values of characters.
5. After sorting, the sorted names are created by joining the reversed name components in the correct order.
6. The sorted names are returned as a new list.

#### Example

Suppose we have the following list of names:
- John Smith
- David Johnson
- Alice Johnson
- John Doe

The sorting process would proceed as follows:

1. Splitting the names into components and reversing the order:
    - [Smith, John]
    - [Johnson, David]
    - [Johnson, Alice]
    - [Doe, John]
2. Creating the list of lists:
    - [[Smith, John], [Johnson, David], [Johnson, Alice], [Doe, John]]
3. Sorting the list of lists:
    - After sorting, the list becomes: [[Doe, John], [Johnson, Alice], [Johnson, David], [Smith, John]]
4. Creating the sorted names:
   - Reversing the name components and joining them:
      - John Doe
      - Alice Johnson
      - David Johnson
      - John Smith
5. The final sorted list of names:
   - John Doe
   - Alice Johnson
   - David Johnson
   - John Smith

The `SortNames` function follows this logic to sort the names based on the specified criteria.

### `NameComparator` Class

The `NameComparator` class is a custom comparator that implements the `IComparer<List<string>>` interface. It is used to compare two lists of name components based on specific criteria.

#### Sorting Logic

The `Compare` method in the `NameComparator` class follows the following sorting logic:

1. Find the minimum length between the two name lists. This determines the maximum index to iterate over the name components.

2. Compare the name components at each index of the lists:
    - The `CompareTo` method is used to compare the name components lexicographically, considering the ASCII values of characters.
    - If the name components at the current index are not equal (result != 0), the comparison result is returned.

3. If all the common name components are equal, compare the remaining name components based on their lengths:
    - The `Count` property is used to compare the sizes of the name lists.
    - A negative value is returned if the first name list is smaller, a positive value if the second name list is smaller, and 0 if they have the same size.

#### Example

Suppose we have the following two name lists to compare:
- `names1`: [Smith, John]
- `names2`: [Johnson, David]

The comparison process would proceed as follows:

1. The minimum length between `names1` and `names2` is 2.

2. Comparing the name components at each index:
    - At index 0: "Smith" and "Johnson" are compared. Since "Smith" comes after "Johnson" in lexicographic order, a negative value is returned.

3. The final comparison result is the value returned at step 2, which is a negative value indicating that `names1` should come after `names2` in the sorted order.

The `NameComparator` class provides the sorting logic required to compare lists of name components for sorting purposes.

### `PrintSortedNames(List<string> sortedNames)`
This method takes a list of sorted names as input and prints each name to the console.

### `SaveSortedNamesToFile(List<string> sortedNames)`
This method takes a list of sorted names as input and saves each name to the output file. It uses a `StreamWriter` to write each name to the file, with each name on a separate line.

### `ReverseNameWithDelimiter(string name, string delimiter)`
This method takes a name and a delimiter as input and reverses the name by splitting it into words using the delimiter, reversing the order of the words, and joining them back using the delimiter. It returns the reversed name as a string.

### `Main(string[] args)`
The entry point of the application. It reads the input file name from the command-line arguments, creates an instance of `NameSorterApp`, and calls the `SortAndSaveNamesToFile` method to perform the sorting and saving process.



# Unit Tests

This project includes a comprehensive set of unit tests to verify the functionality and correctness of the `NameSorterApp` class. The tests are implemented using NUnit, a popular unit testing framework for C#.

## Running the Unit Tests

To run the unit tests, follow these steps:

1. Make sure you have the necessary dependencies installed. In this case, NUnit and the NUnit Test Adapter are required.
2. Open the solution in Visual Studio or your preferred IDE.
3. Build the solution to ensure all the necessary files are compiled.
4. Go to the [StringLibraryTest](StringLibraryTest) folder and run the command 

```
dotnet test
``` 

## Overview of Unit Tests

The unit tests cover various aspects of the `NameSorterApp` class to ensure its functionality is correct. Here is a brief overview of the available tests:

### `SortNames_ValidNames_SortedNames`

This test verifies that the `SortNames` method correctly sorts a list of valid names. It performs the following steps:

1. **Arrange**: Creates a list of names in a random order.
2. **Act**: Calls the `SortNames` method with the list of names.
3. **Assert**: Compares the expected sorted names with the actual sorted names returned by the method. If they match, the test passes; otherwise, it fails.

This test ensures that the `SortNames` method properly sorts the names according to the expected order.

## Contributing

If you find any issues or want to contribute to the unit tests, feel free to open an issue or submit a pull request. Your contributions are highly appreciated!


## Conclusion
The Name Sorter App is a handy tool for sorting a list of names in ascending order by reversing them. By following the provided instructions, you can compile and run the application on your system. Enjoy sorting your names effortlessly!
