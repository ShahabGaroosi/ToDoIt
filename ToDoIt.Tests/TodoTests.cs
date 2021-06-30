using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Model;

namespace ToDoIt.Tests
{
    public class TodoTests
    {
        [Fact]
        public void TodoIdTest()
        {
            //Arrange
            int todoId = 23;
            string description = "Test code";

            //Act
            Todo testTodo = new Todo(todoId, description);

            //Assert
            Assert.Equal(todoId, testTodo.TodoId);
        }
        [Fact]
        public void DescriptionTest()
        {
            //Arrange
            int todoId = 23;
            string description = "Test code";

            //Act
            Todo testTodo = new Todo(todoId, description);

            //Assert
            Assert.Equal(description, testTodo.Description);
        }
    }
}
