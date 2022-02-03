using System;

namespace HiddenFieldExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var ahmedTarek = new Person("Ahmed", "Tarek", " ");
            Console.WriteLine(ahmedTarek.FullName);

            var copy = new Person(ahmedTarek.FirstName, ahmedTarek.LastName, "???");
            Console.WriteLine(copy.FullName);
        }
    }

    public class Person
    {
        private readonly string m_Separator;

        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => $"{FirstName}{m_Separator}{LastName}";

        public Person(string firstName, string lastName, string separator)
        {
            FirstName = firstName;
            LastName = lastName;
            m_Separator = separator;
        }
    }
}