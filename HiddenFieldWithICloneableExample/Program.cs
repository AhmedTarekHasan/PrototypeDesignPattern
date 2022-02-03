using System;

namespace HiddenFieldWithICloneableExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ahmedTarek = new Person("Ahmed", "Tarek", " ");
            Console.WriteLine(ahmedTarek.FullName);

            var copy = ahmedTarek.Clone() as Person;
            copy.FirstName = "Hasan";
            copy.LastName = "Saleh";
            Console.WriteLine(copy.FullName);

            Console.ReadLine();
        }
    }

    public class Person : ICloneable
    {
        private readonly string m_Separator;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName}{m_Separator}{LastName}";

        public Person(string firstName, string lastName, string separator)
        {
            FirstName = firstName;
            LastName = lastName;
            m_Separator = separator;
        }

        public object Clone()
        {
            return new Person(FirstName, LastName, m_Separator);
        }
    }
}