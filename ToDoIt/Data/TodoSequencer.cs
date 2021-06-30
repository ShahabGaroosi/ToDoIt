using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId;

        public int TodoId
        {
            get { return todoId; }
        }

        public static int nextTodoId()
        {
            return ++todoId;
        }
        public static void reset()
        {
            todoId = 0;
        }
    }
}
