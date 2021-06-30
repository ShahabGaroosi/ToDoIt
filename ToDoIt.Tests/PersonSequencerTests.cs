using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Tests
{
    public class PersonSequencerTests
    {
        [Fact]
        public void ConstructorTest()
        {
            //Arrange
            int personId = 0;

            //Act
            PersonSequencer testPersonSequencer = new PersonSequencer();

            //Assert
            Assert.Equal(personId, testPersonSequencer.PersonId);
        }
        [Fact]
        public void NextPersonIdTest()
        {
            //Arrange
            int personId = 2;

            //Act
            PersonSequencer testPersonSequencer = new PersonSequencer();
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();

            //Assert
            Assert.Equal(personId, testPersonSequencer.PersonId);
        }

        [Fact]
        public void ResetTest()
        {
            //Arrange
            int personId = 0;

            //Act
            PersonSequencer testPersonSequencer = new PersonSequencer();
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.reset();

            //Assert
            Assert.Equal(personId, testPersonSequencer.PersonId);
        }
    }
}
