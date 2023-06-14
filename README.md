# Name Sorter App

## Introduction
Name Sorter App is a Java application that reads a list of names from a text file, reverses each name, sorts them in ascending order, and saves the sorted names to a new text file. It provides a command-line interface to execute the sorting operation.

## Prerequisites
To run the Name Sorter App, ensure that you have the following software installed on your system:
- Java Development Kit (JDK) 8 or later
- Command-line interface (Terminal or Command Prompt)


## Usage using shell script
I have included a shell script to make it easier to run the given java program.
To run the Java program `NameSorterApp.java` using the provided shell script, follow these steps:

1. Save the shell script code to a file, for example, `run_name_sorter.sh`.

2. Open a terminal or command prompt and navigate to the directory where the shell script and the `NameSorterApp.java` file are located.

3. Make sure you have the necessary permissions to execute the shell script. If needed, you can give the execute permission by running the command:

```bash
chmod +x name-sorter.sh
```

4. Run the shell script by providing the input file name as an argument. For example, if your input file is named unsorted-names-list.txt, run the command:

 ```bash
./name-sorter.sh unsorted-names-list.txt
```

5. The script will compile the NameSorterApp.java file and then execute the Java program with the provided input file. The sorted names will be printed to the console.

If the compilation and execution are successful, you will see the sorted names displayed in the terminal or command prompt.

If there are any errors during compilation or execution, appropriate error messages will be displayed.

Note: Make sure you have Java Development Kit (JDK) installed on your system and the `javac` and `java` commands are accessible from the command line.


## Compilation using javac
To compile the Java file and create the executable class file, follow these steps:
1. Open a terminal or command prompt.
2. Navigate to the directory where the `NameSorterApp.java` file is located.
3. Run the following command to compile the Java file:
 ```
javac NameSorterApp.java
```
4. After successful compilation, an `NameSorterApp.class` file will be generated in the same directory.

## Usage using java cli
To use the Name Sorter App, follow these steps:

1. Prepare an input file containing a list of names. Each name should be on a separate line.
2. Open a terminal or command prompt.
3. Navigate to the directory where the `NameSorterApp.class` file is located.
4. Execute the following command to run the application:

```
java NameSorterApp <input_file_path>
```

Replace `<input_file_path>` with the path to your input file.
In this case according to the given description it should be `./unsorted-names-list.txt`.


## Functionality

### `sortAndSaveNamesToFile()`
This method is responsible for orchestrating the entire sorting and saving process. It reads the names from the input file, reverses and sorts them, prints the sorted names to the console, and saves them to the output file.

### `readNamesFromFile()`
This method reads the names from the input file and returns them as a list. It uses a `BufferedReader` to read each line from the file and adds it to the list of names.

### `sortNames(List<String> names)`

The `sortNames` function is responsible for sorting a list of names based on specific criteria. It takes a `List<String>` of names as input and returns a new list containing the sorted names.

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

The `sortNames` function follows this logic to sort the names based on the specified criteria.
### `NameComparator` Class

The `NameComparator` class is a custom comparator that implements the `Comparator<List<String>>` interface. It is used to compare two lists of name components based on specific criteria.

#### Sorting Logic

The `compare` method in the `NameComparator` class follows the following sorting logic:

1. Find the minimum length between the two name lists. This determines the maximum index to iterate over the name components.

2. Compare the name components at each index of the lists:
    - The `compareTo` method is used to compare the name components lexicographically, considering the ASCII values of characters.
    - If the name components at the current index are not equal (result != 0), the comparison result is returned.

3. If all the common name components are equal, compare the remaining name components based on their lengths:
    - The `Integer.compare` method is used to compare the sizes of the name lists.
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

### `printSortedNames(List<String> sortedNames)`
This method takes a list of sorted names as input and prints each name to the console.

### `saveSortedNamesToFile(List<String> sortedNames)`
This method takes a list of sorted names as input and saves each name to the output file. It uses a `BufferedWriter` to write each name to the file, with each name on a separate line.

### `reverseNameWithDelimiter(String name, String delimiter)`
This method takes a name and a delimiter as input and reverses the name by splitting it into words using the delimiter, reversing the order of the words, and joining them back using the delimiter. It returns the reversed name as a string.

## Unit Test

To ensure the correctness of the `NameSorterApp` class, the following tests have been implemented using JUnit [NameSorterAppTest](test/NameSortesAppTest.java):

### `testSortAndSaveNamesToFile()`

This test verifies the `sortAndSaveNamesToFile()` method of the `NameSorterApp` class. It performs the following steps:

1. **Arrange**: Sets up the input and output file names and creates an instance of the `NameSorterApp` class.
2. **Act**: Calls the `sortAndSaveNamesToFile()` method.
3. **Assert**: Compares the expected sorted names with the actual names read from the output file. If they match, the test passes; otherwise, it fails.

This test ensures that the `sortAndSaveNamesToFile()` method correctly sorts the names and saves them to the output file.

### `testSortAndSaveNamesToFile_InvalidInputFile()`

This test checks the handling of an invalid input file in the `sortAndSaveNamesToFile()` method. It performs the following steps:

1. **Arrange**: Sets up the non-existent input file name and the output file name. Creates an instance of the `NameSorterApp` class.
2. **Assert**: Verifies that an `IOException` is thrown when calling the `sortAndSaveNamesToFile()` method with the non-existent input file.

This test ensures that the `sortAndSaveNamesToFile()` method handles the case of an invalid input file gracefully by throwing an exception.

### `testMain()`

This test verifies the `main()` method of the `NameSorterApp` class. It performs the following steps:

1. **Arrange**: Sets up the command-line arguments with the input file name.
2. **Act**: Calls the `main()` method.
3. **Assert**: Add any specific assertions if required.

This test ensures that the `main()` method can be executed without any exceptions.

These tests cover different scenarios and help ensure the correctness and robustness of the `NameSorterApp` class.


## Conclusion
The Name Sorter App is a handy tool for sorting a list of names in ascending order by reversing them. By following the provided instructions, you can compile and run the application on your system. Enjoy sorting your names effortlessly!
