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

        [Fact]
        public void FindByDoneStatusTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            Todo[] testTodo = new Todo[5];
            for (int i = 0; i < 5; i++)
            {
                testTodo[i] = testTodoItems.CreateTodo($"Test code{i}");
            }
            testTodo[1].Done = true;
            testTodo[4].Done = true;

            //Act
            Todo[] testTodo2 = testTodoItems.FindByDoneStatus(true);

            //Assert
            Assert.True(2 <= testTodo2.Length);
            foreach (Todo todo in testTodo2)
            {
                Assert.True(todo.Done);
            }
        }

        [Fact]
        public void FindByAssigneeIdTest()
        {
            //Arrange
            People persons = new People();
            TodoItems testTodoItems = new TodoItems();
            Todo[] testTodo = new Todo[5];
            for (int i = 0; i < 5; i++)
            {
                testTodo[i] = testTodoItems.CreateTodo($"Test code{i}");
                testTodo[i].Assigne = persons.CreatePerson("Test", "Testsson");
            }
            int personId = testTodo[3].Assigne.PersonId;

            //Act
            Todo[] testTodo2 = testTodoItems.FindByAssignee(personId);

            //Assert
            Assert.Single(testTodo2);
            Assert.Equal(testTodo[3], testTodo2[0]);
        }

        [Fact]
        public void FindByAssigneeTest()
        {
            //Arrange
            People persons = new People();
            TodoItems testTodoItems = new TodoItems();
            Todo[] testTodo = new Todo[5];
            for (int i = 0; i < 5; i++)
            {
                testTodo[i] = testTodoItems.CreateTodo($"Test code{i}");
                testTodo[i].Assigne = persons.CreatePerson("Test", "Testsson");
            }
            Person person = testTodo[3].Assigne;

            //Act
            Todo[] testTodo2 = testTodoItems.FindByAssignee(person);

            //Assert
            Assert.Single(testTodo2);
            Assert.Equal(testTodo[3], testTodo2[0]);
        }

        [Fact]
        public void FindUnassignedTodoItemsTest()
        {
            //Arrange
            TodoItems testTodoItems = new TodoItems();
            Todo[] testTodo = new Todo[5];
            for (int i = 0; i < 5; i++)
            {
                testTodo[i] = testTodoItems.CreateTodo($"Test code{i}");
            }
            testTodo[1].Done = true;
            testTodo[4].Done = true;

            //Act
            Todo[] testTodo2 = testTodoItems.FindByDoneStatus(false);

            //Assert
            Assert.True(3 <= testTodo2.Length);
            foreach (Todo todo in testTodo2)
            {
                Assert.False(todo.Done);
            }
        }
    }
}
