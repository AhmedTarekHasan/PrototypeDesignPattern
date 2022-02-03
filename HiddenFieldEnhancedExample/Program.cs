using System;

namespace HiddenFieldEnhancedExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var ahmedTarek = new Person("Ahmed", "Tarek", " ");
            Console.WriteLine(ahmedTarek.FullName);

            var copy = ahmedTarek.Clone("Hasan", "Saleh", null);
            Console.WriteLine(copy.FullName);

            Console.ReadLine();
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

        public Person Clone()
        {
            return Clone(null, null, null);
        }

        public Person Clone(
            string firstNameOverride,
            string lastNameOverride,
            string separatorOverride)
        {
            return new Person(
                firstNameOverride ?? FirstName,
                lastNameOverride ?? LastName,
                separatorOverride ?? m_Separator);
        }
    }
}