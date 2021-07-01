using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void NextTodoIdTest()
        {
            //Arrange
            TodoSequencer testTodoSequencer = new TodoSequencer();

            //Act
            int before = testTodoSequencer.TodoId;
            TodoSequencer.nextTodoId();
            int result = testTodoSequencer.TodoId;

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void ResetTest()
        {
            //Arrange
            int todoId = 0;

            //Act
            TodoSequencer testTodoSequencer = new TodoSequencer();
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            int before = testTodoSequencer.TodoId;
            TodoSequencer.reset();
            int result = testTodoSequencer.TodoId;

            //Assert
            Assert.True(before > result);
        }
    }
}
