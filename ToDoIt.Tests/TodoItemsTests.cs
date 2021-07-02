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
            TodoItems testTodoItems = ArrangeTest();

            //Act
            Todo[] testTodos = testTodoItems.FindAll();
            int size = testTodoItems.Size();

            //Assert
            Assert.Equal(size, testTodos.Length);
        }

        [Fact]
        public void TodoIdTest()
        {
            //Arrange
            TodoItems testTodoItems = ArrangeTest();

            //Act
            Todo[] testTodos = testTodoItems.FindAll();

            //Assert
            Assert.NotEqual(testTodos[1].TodoId, testTodos[4].TodoId);
        }

        [Fact]
        public void FindByIdTest()
        {
            //Arrange
            TodoItems testTodoItems = ArrangeTest();

            //Act
            Todo testTodo = testTodoItems.FindAll()[1];


            //Assert
            Assert.Equal(testTodo, testTodoItems.FindById(testTodo.TodoId));
        }

        [Fact]
        public void ClearTest()
        {
            //Arrange
            TodoItems testTodoItems = ArrangeTest();

            //Act
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
            TodoItems testTodoItems = ArrangeTest();

            //Act
            Todo[] testTodoDone = testTodoItems.FindByDoneStatus(true);
            Todo[] testTodoNotDone = testTodoItems.FindByDoneStatus(false);

            //Assert
            Assert.True(2 <= testTodoDone.Length);
            foreach (Todo todo in testTodoDone)
            {
                Assert.True(todo.Done);
            }
            Assert.True(3 <= testTodoNotDone.Length);
            foreach (Todo todo in testTodoNotDone)
            {
                Assert.False(todo.Done);
            }
        }

        [Fact]
        public void FindByAssigneeIdTest()
        {
            //Arrange
            TodoItems testTodoItems = ArrangeTest();
            Todo testTodo0 = testTodoItems.FindAll()[1];

            //Act
            Todo[] testTodo1 = testTodoItems.FindByAssignee(testTodo0.Assigne.PersonId);

            //Assert
            Assert.Single(testTodo1);
            Assert.Equal(testTodo0, testTodo1[0]);
        }

        [Fact]
        public void FindByAssigneeTest()
        {
            //Arrange
            TodoItems testTodoItems = ArrangeTest();
            Todo testTodo0 = testTodoItems.FindAll()[1];

            //Act
            Todo[] testTodo1 = testTodoItems.FindByAssignee(testTodo0.Assigne);

            //Assert
            Assert.Single(testTodo1);
            Assert.Equal(testTodo0, testTodo1[0]);
        }

        [Fact]
        public void FindUnassignedTodoItemsTest()
        {
            //Arrange
            TodoItems testTodoItems = ArrangeTest();
            //Act
            Todo[] testTodo2 = testTodoItems.FindUnassignedTodoItems();

            //Assert
            Assert.True(3 <= testTodo2.Length);
            foreach (Todo todo in testTodo2)
            {
                Assert.Null(todo.Assigne);
            }
        }

        [Fact]
        public void ExcludeByIdTest()
        {
            //Arrange
            TodoItems testTodoItems = ArrangeTest();
            int todoId = testTodoItems.FindAll()[2].TodoId;

            //Act
            testTodoItems.ExcludeById(todoId);

            //Assert
            Assert.Throws<ArgumentException>(() => testTodoItems.FindById(todoId));
        }

        public TodoItems ArrangeTest()
        {
            //Arrange
            People testPeople = new People();
            TodoItems testTodoItems = new TodoItems();
            Todo[] testTodo = new Todo[5];
            for (int i = 0; i < testTodo.Length; i++)
            {
                testTodo[i] = testTodoItems.CreateTodo($"Test code{i}");
            }
            testTodo[1].Assigne = testPeople.CreatePerson("Test1", "Testsson1");
            testTodo[4].Assigne = testPeople.CreatePerson("Test4", "Testsson4");
            testTodo[1].Done = true;
            testTodo[4].Done = true;
            return testTodoItems;
        }
    }
}
