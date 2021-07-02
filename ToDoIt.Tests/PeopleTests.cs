using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;

namespace ToDoIt.Tests
{
    public class PeopleTests
    {
        [Fact]
        public void CreateTest()
        {
            //Arrange
            People testPeople = new People();
            string firstName = "Test";
            string lastName = "Testsson";

            //Act
            Person testPerson = testPeople.CreatePerson(firstName, lastName);

            //Assert
            Assert.Equal(firstName, testPerson.FirstName);
            Assert.Equal(lastName, testPerson.LastName);
        }

        [Fact]
        public void SizeTest()
        {
            //Arrange
            People testPeople = new People();
            string firstName = "Test";
            string lastName = "Testsson";

            //Act
            int before = testPeople.Size();
            testPeople.CreatePerson(firstName, lastName);
            int result = testPeople.Size();

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void FindAllTest()
        {
            //Arrange
            People testPeople = new People();
            for (int i = 0; i < 5; i++)
            {
                testPeople.CreatePerson($"Test{i}", $"Testsson{i}");
            }

            //Act
            Person[] testPersons = testPeople.FindAll();
            int size = testPeople.Size();

            //Assert
            Assert.Equal(size, testPersons.Length);
        }

        [Fact]
        public void PersonIdTest()
        {
            //Arrange
            People testPeople = new People();
            Person[] testPersons = new Person[5];
            for (int i = 0; i < testPersons.Length; i++)
            {
                testPersons[i] = testPeople.CreatePerson($"Test{i}", $"Testsson{i}");
            }

            //Act
            //Assert
            Assert.NotEqual(testPersons[1].PersonId, testPersons[4].PersonId);
        }

        [Fact]
        public void FindByIdTest()
        {
            //Arrange
            People testPeople = new People();
            Person[] testPersons = new Person[5];
            for (int i = 0; i < testPersons.Length; i++)
            {
                testPersons[i] = testPeople.CreatePerson($"Test{i}", $"Testsson{i}");
            }

            //Act
            //Assert
            Assert.Equal(testPersons[2], testPeople.FindById(testPersons[2].PersonId));
        }

        [Fact]
        public void ClearTest()
        {
            //Arrange
            People testPeople = new People();
            for (int i = 0; i < 5; i++)
            {
                testPeople.CreatePerson($"Test{i}", $"Testsson{i}");
            }

            //Act
            testPeople.Clear();
            Person[] testPersons = testPeople.FindAll();

            //Assert
            Assert.NotNull(testPersons);
            Assert.Empty(testPersons);
        }
        [Fact]
        public void ExcludeByIdTest()
        {
            //Arrange
            People testPeople = new People();
            Person[] testPersons = new Person[5];
            for (int i = 0; i < testPersons.Length; i++)
            {
                testPersons[i] = testPeople.CreatePerson($"Test{i}", $"Testsson{i}");
            }
            int personId = testPersons[2].PersonId;

            //Act
            testPeople.ExcludeById(personId);

            //Assert
            Assert.Throws<ArgumentException>(() => testPeople.FindById(personId));
        }
    }
}
