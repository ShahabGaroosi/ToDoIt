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
        public void CreateTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";

            //Act
            Todo testTodo = testTodoItems.CreateTodo(description);

            //Assert
            Assert.Equal(description, testTodo.Description);
        }

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
        public void TodoIdTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";
            string description2 = "Test code2";

            //Act
            Todo testTodo = testTodoItems.CreateTodo(description);
            Todo testTodo2 = testTodoItems.CreateTodo(description2);

            //Assert
            Assert.NotEqual(testTodo.TodoId, testTodo2.TodoId);
        }

        [Fact]
        public void FindByIdTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            string description = "Test code";

            //Act
            Todo testTodos = testTodoItems.CreateTodo(description);


            //Assert
            Assert.Equal(testTodos, testTodoItems.FindById(testTodos.TodoId));
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
