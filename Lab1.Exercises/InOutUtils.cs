using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab1.Exercises
{
    static class InOutUtils
    {
        public static List<Dog> ReadDogs(string fileName)
        {
            List<Dog> dogs = new List<Dog>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                int id = int.Parse(values[0]);
                string name = values[1];
                string breed = values[2];
                DateTime birthDate = DateTime.Parse(values[3]);
                Gender gender;
                Enum.TryParse(values[4], out gender);
                Dog dog = new Dog(id, name, breed, birthDate, gender);
                dogs.Add(dog);
            }
            return dogs;
        }
        public static void PrintDogs(List<Dog> dogs)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            foreach (Dog dog in dogs)
            {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
                            }
            Console.WriteLine(new string('-', 74));


        }
        public static void PrintBreeds(List<string> breeds)
        {
            foreach(string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }
        public static void PrintDogsToCSVFile(string fileName, List<Dog> dogs)
        {
            string[] lines = new string[dogs.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4}", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            for (int i= 0; i < dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}", dogs[i].ID, dogs[i].Name, dogs[i].Breed, dogs[i].BirthDate, dogs[i].Gender);

            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        
    }
}
