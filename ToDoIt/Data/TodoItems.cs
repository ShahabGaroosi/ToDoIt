using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Model;

namespace ToDoIt.Data
{
    public class TodoItems
    {
        private static Todo[] todos = new Todo[0];

        public int Size()
        {
            return todos.Length;
        }
        public Todo[] FindAll()
        {
            return todos;
        }
        public Todo FindById(int todoId)
        {
            foreach (Todo todo in todos)
            {
                if (todo.TodoId == todoId)
                {
                    return todo;
                }
            }
            throw new ArgumentException($"Person does not exist with personId: {todoId}.");
        }
        public Todo CreateTodo(string description)
        {
            Todo todo = new Todo(TodoSequencer.nextTodoId(), description);
            Array.Resize(ref todos, todos.Length + 1);
            todos[^1] = todo;
            return todo;
        }
        public void Clear()
        {
            todos = new Todo[0];
            TodoSequencer.reset();
        }
    }
}
