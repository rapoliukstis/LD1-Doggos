using System;
using System.Collections.Generic;
using System.IO;


namespace Lab1.Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(allDogs);

            Console.WriteLine("Is viso sunu: {0}", allDogs.Count);
            Console.WriteLine("Patinu: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
            Console.WriteLine("Pateliu: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
            Console.WriteLine();
            Dog oldest = TaskUtils.FindOldestDog(allDogs); 
            Console.WriteLine("Seniausias suo");
            Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldest.Name, oldest.Breed, oldest.CalculateAge()); 
            List<string> breeds = TaskUtils.FindBreeds(allDogs);
            Console.WriteLine("Sunu veisles:");
            InOutUtils.PrintBreeds(breeds);
            Console.WriteLine();
            Console.WriteLine("Kokios veisles sunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dog> filteredByBreed = TaskUtils. FilterByBreed(allDogs, selectedBreed);
            InOutUtils.PrintDogs(filteredByBreed);
            List<Dog>filtered = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, filteredByBreed);
            Dog oldestbybreed = TaskUtils.FindOldestDogByBreed(filtered);
            Console.WriteLine("Seniausias sios veisles suo :");
            Console.WriteLine("Vardas : {0}, Veisle: {1}, Amzius: {2}", oldestbybreed.Name, oldestbybreed.Breed, oldestbybreed.CalculateAge());
            
        }

    }
}
