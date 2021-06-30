using System;
using Xunit;
using ToDoIt;
using ToDoIt.Model;

namespace ToDoIt.Tests
{
    public class PersonTests
    {
        [Fact]
        public void PersonIdCounterTest()
        {
            //Arrange
            string firstName = "Kent";
            string lastName = "Svensson";

            //Act
            int before = Person.Counter;
            new Person(firstName, lastName);//create person to make counter count up.
            int result = Person.Counter;

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void PersonIdTest()
        {
            //Arrange
            string firstName = "Kent";
            string lastName = "Svensson";
            string firstName2 = "Test";
            string lastName2 = "Testsson";

            //Act
            Person person1 = new Person(firstName, lastName);
            Person person2 = new Person(firstName2, lastName2);

            //Assert
            Assert.NotEqual(person1.PersonId, person2.PersonId);
        }

        [Fact]
        public void NameTest()
        {
            //Arrange
            string firstName = "Kent";
            string lastName = "Svensson";

            Person testPerson = new Person(firstName, lastName);

            //Assert
            Assert.Equal(firstName, testPerson.FirstName);
            Assert.Equal(lastName, testPerson.LastName);
        }
    }
}
