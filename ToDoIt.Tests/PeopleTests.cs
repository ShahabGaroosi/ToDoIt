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
            string firstName = "Test";
            string lastName = "Testsson";
            string firstName2 = "Test2";
            string lastName2 = "Testsson2";

            //Act
            testPeople.CreatePerson(firstName, lastName);
            testPeople.CreatePerson(firstName2, lastName2);
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
            string firstName = "Test";
            string lastName = "Testsson";
            string firstName2 = "Test2";
            string lastName2 = "Testsson2";

            //Act
            Person testPerson = testPeople.CreatePerson(firstName, lastName);
            Person testPerson2 = testPeople.CreatePerson(firstName2, lastName2);

            //Assert
            Assert.NotEqual(testPerson.PersonId, testPerson2.PersonId);
        }

        [Fact]
        public void FindByIdTest()
        {
            //Arrange
            People testPeople = new People();
            string firstName = "Test";
            string lastName = "Testsson";

            //Act
            Person testPerson = testPeople.CreatePerson(firstName, lastName);


            //Assert
            Assert.Equal(testPerson, testPeople.FindById(testPerson.PersonId));
        }

        [Fact]
        public void ClearTest()
        {
            //Arrange
            People testPeople = new People();
            string firstName = "Test";
            string lastName = "Testsson";

            //Act
            testPeople.CreatePerson(firstName, lastName);
            testPeople.Clear();
            Person[] testPersons = testPeople.FindAll();

            //Assert
            Assert.NotNull(testPersons);
            Assert.Empty(testPersons);
        }
    }
}
