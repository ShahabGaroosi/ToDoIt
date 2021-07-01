using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;

namespace ToDoIt.Tests
{
    public class TodoItemsTests
    {
        [Fact]
        public void SizeTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";

            //Act
            int before = testTodoItems.Size();
            testTodoItems.CreateTodo(description);
            int result = testTodoItems.Size();

            //Assert
            Assert.True(before < result);
        }

        [Fact]
        public void FindAllTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";
            string description2 = "Test code2";

            //Act
            testTodoItems.CreateTodo(description);
            testTodoItems.CreateTodo(description2);
            Todo[] testTodos = testTodoItems.FindAll();
            int size = testTodoItems.Size();

            //Assert
            Assert.Equal(size, testTodos.Length);
        }

        [Fact]
        public void PersonIdTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";
            string description2 = "Test code2";

            //Act
            testTodoItems.CreateTodo(description);
            testTodoItems.CreateTodo(description2);
            Todo[] testTodos = testTodoItems.FindAll();

            //Assert
            Assert.NotEqual(testTodos[0].TodoId, testTodos[1].TodoId);
        }

        [Fact]
        public void FindByIdTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";
            string description2 = "Test code2";

            //Act
            testTodoItems.CreateTodo(description);
            testTodoItems.CreateTodo(description2);
            Todo[] testTodos = testTodoItems.FindAll();


            //Assert
            Assert.Equal(testTodos[^1], testTodoItems.FindById(testTodos[^1].TodoId));
        }

        [Fact]
        public void ClearTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";

            //Act
            testTodoItems.CreateTodo(description);
            testTodoItems.Clear();
            Todo[] testTodos = testTodoItems.FindAll();

            //Assert
            Assert.NotNull(testTodos);
            Assert.Empty(testTodos);
        }
    }
}
