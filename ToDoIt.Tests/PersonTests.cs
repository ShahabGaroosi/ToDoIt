using System;
using Xunit;
using ToDoIt;
using ToDoIt.Model;

namespace ToDoIt.Tests
{
    public class PersonTests
    {
        [Fact]
        public void PersonIdTest()
        {
            //Arrange
            int personId = 23;
            string firstName = "Test";
            string lastName = "Testsson";

            //Act
            Person testPerson = new Person(personId, firstName, lastName);

            //Assert
            Assert.Equal(personId, testPerson.PersonId);
        }

        [Fact]
        public void NameTest()
        {
            //Arrange
            int personId = 23;
            string firstName = "Test";
            string lastName = "Testsson";

            Person testPerson = new Person(personId, firstName, lastName);

            //Assert
            Assert.Equal(firstName, testPerson.FirstName);
            Assert.Equal(lastName, testPerson.LastName);
        }
    }
}
