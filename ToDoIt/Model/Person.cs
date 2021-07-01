using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Model
{
    public class Person
    {
        static int idCounter = 0;
        public static int Counter { get { return idCounter; } }
        private readonly int personId;
        private string firstName, lastName;

        public Person(int personId, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.personId = personId;
        }
        public int PersonId
        {
            get { return personId; }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null or empty is not allowed.");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Null or empty is not allowed.");
                }
                lastName = value;
            }
        }
    }
}
