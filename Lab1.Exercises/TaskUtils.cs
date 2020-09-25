using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Exercises
{
    class TaskUtils
    {
        public static int CountByGender(List<Dog> dogs, Gender gender)
        {
            int count =0;
            foreach (Dog dog in dogs)
            {
                if  (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public static Dog FindOldestDog(List<Dog> dogs)
        {
            Dog oldest = dogs[0];
            for (int i = 1; i < dogs.Count; i++)
            {
                if(DateTime.Compare(oldest.BirthDate, dogs[i].BirthDate)>0)
                {
                    oldest = dogs[i];
                }
            }
            return oldest;
        }
        public static List<string> FindBreeds(List<Dog> dogs)
        {
            List<string> breeds = new List<string>();
            foreach (Dog dog in dogs)
            {
                string breed = dog.Breed;
                if(!breeds.Contains(breed))
                {
                    breeds.Add(breed);
                }
            }
            return breeds;
        }
        public static List<Dog> FilterByBreed(List<Dog> dogs, string selectedbreed)
        {
            List<Dog> filtered = new List<Dog>();
            foreach(Dog dog in dogs)
            {
                if(dog.Breed.Equals(selectedbreed))
                {
                    filtered.Add(dog);
                }
            }
            return filtered;
        }
        public static Dog FindOldestDogByBreed(List<Dog> filtered)
        {

            Dog oldestbybreed = filtered[0];
            for (int i = 1; i < filtered.Count; i++)
            {
                if (DateTime.Compare(oldestbybreed.BirthDate, filtered[i].BirthDate) > 0)
                {
                    oldestbybreed = filtered[i];
                }
            }
            return oldestbybreed;
        }
        public string MostPopularBreed (List<Dog>dogs)
        {

            List<Dog>breedsCount = new List<Dog>();
            int[] CountBreeds = new int[dogs.Count];
            string mostPopularBreed;
            
            for (int i = 0; i < dogs.Count; i++)
            {
                int l = 0;
                if (i == 0)
                    breedsCount.Add(dogs[i]);
                for (int ii = 0; ii < breedsCount.Count; ii++)
                {
                    if (dogs[i].Breed == breedsCount[ii].Breed)
                        CountBreeds[ii]++;
                    l++;
                }
                if(l==0)
                    breedsCount.Add(dogs[i]);
            }
            int populiariausia = CountBreeds[0];
            mostPopularBreed = breedsCount[0].Breed;

            for (int i = 1; i < breedsCount.Count; i++)
            {
                if (CountBreeds[i] > populiariausia)
                    mostPopularBreed = breedsCount[i].Breed;
            }
            return mostPopularBreed;              //parasyti isvedima
        }
    }
}
