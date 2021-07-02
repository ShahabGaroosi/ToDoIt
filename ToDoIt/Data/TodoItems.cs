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
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            return FindTodoItems(todo => (todo.Done == doneStatus));
        }
        public Todo[] FindByAssignee(int personId)
        {
            return FindTodoItems(todo => (todo.Assigne != null)&&(todo.Assigne.PersonId == personId));
        }
        public Todo[] FindByAssignee(Person assigne)
        {
            return FindTodoItems(todo => (todo.Assigne == assigne));
        }
        public Todo[] FindUnassignedTodoItems()
        {
            return FindTodoItems(todo => (todo.Assigne == null));
        }
        public Todo[] FindTodoItems(Func<Todo,bool> fun)
        {
            List<Todo> list = new List<Todo>();
            foreach (Todo todo in todos)
            {
                if (fun(todo))
                {
                    list.Add(todo);
                }
            }
            return list.ToArray();
        }
        public void ExcludeById(int todoId)
        {
            for (int i = 0; i < todos.Length; i++)
            {
                if(todos[i].TodoId == todoId)
                {
                    if ((i > 0) && (i < todos.Length - 1))
                    {
                        Array.Copy(todos, i + 1, todos, i, todos.Length - 1 - i);
                    }
                    Array.Resize(ref todos, todos.Length - 1);
                    break;
                }
            }
        }
    }
}
