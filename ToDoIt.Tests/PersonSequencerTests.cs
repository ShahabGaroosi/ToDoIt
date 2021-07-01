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
        public void NextPersonIdTest()
        {
            //Arrange
            PersonSequencer testPersonSequencer = new PersonSequencer();

            //Act
            int before = testPersonSequencer.PersonId;
            PersonSequencer.nextPersonId();
            int result = testPersonSequencer.PersonId;

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void ResetTest()
        {
            //Arrange
            PersonSequencer testPersonSequencer = new PersonSequencer();
            int personId = 0;

            //Act
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.reset();

            //Assert
            Assert.Equal(personId, testPersonSequencer.PersonId);
        }
    }
}
