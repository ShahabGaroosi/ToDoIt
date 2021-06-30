using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Data
{
    public class PersonSequencer
    {
        private static int personId;

        public int PersonId
        {
            get { return personId; }
        }

        public static int nextPersonId()
        {
            return ++personId;
        }
        public static void reset()
        {
            personId = 0;
        }
    }
}
