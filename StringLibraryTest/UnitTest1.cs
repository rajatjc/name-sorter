using NUnit.Framework;
using System.Collections.Generic;

namespace NameSorterAppTests
{
    [TestFixture]
    public class NameSorterAppTests
    {
        [Test]
        public void SortNames_ValidNames_SortedNames()
        {
            // Arrange
            List<string> names = new List<string>
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez",
                "London Lindsey",
                "Beau Tristan Bentley",
                "Leo Gardner",
                "Hunter Uriah Mathew Clarke",
                "Mikayla Lopez",
                "Frankie Conner Ritter"
            };

            List<string> expectedSortedNames = new List<string>
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke",
                "Leo Gardner",
                "Vaughn Lewis",
                "London Lindsey",
                "Mikayla Lopez",
                "Janet Parsons",
                "Frankie Conner Ritter",
                "Shelby Nathan Yoder"
            };

            NameSorterApp nameSorter = new NameSorterApp("", ""); // Pass empty file names for testing purposes

            // Act
            List<string> sortedNames = nameSorter.SortNames(names);

            // Assert
            CollectionAssert.AreEqual(expectedSortedNames, sortedNames);
        }
    }
}
