using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Model;

namespace ToDoIt.Data
{
    public class People
    {
        private static Person[] persons = new Person[0];
        
        public int Size()
        {
            return persons.Length;
        }
        public Person[] FindAll()
        {
            return persons;
        }
        public Person FindById(int personId)
        {
            foreach (Person person in persons)
            {
                if (person.PersonId == personId)
                {
                    return person;
                }
            }
            throw new ArgumentException($"Person does not exist with personId: {personId}.");
        }
        public Person CreatePerson(string firstName, string lastName)
        {
            Person person = new Person(PersonSequencer.nextPersonId(), firstName, lastName);
            Array.Resize(ref persons, persons.Length + 1);
            persons[^1] = person;
            return person;
        }
        public void Clear()
        {
            persons = new Person[0];
            PersonSequencer.reset();
        }
        public void ExcludeById(int personId)
        {
            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i].PersonId == personId)
                {
                    if ((i > 0) && (i < persons.Length - 1))
                    {
                        Array.Copy(persons, i + 1, persons, i, persons.Length - 1 - i);
                    }
                    Array.Resize(ref persons, persons.Length - 1);
                    break;
                }
            }
        }
    }
}
