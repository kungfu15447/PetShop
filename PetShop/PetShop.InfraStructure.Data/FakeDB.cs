using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class FakeDB
    {
        public static int id = 1;
        public static IEnumerable<Pet> petList;

        public static void initData()
        {
            Pet pet = new Pet
            {
                id = id++,
                name = "Rex",
                type = PetTypes.Dog,
                birthDate = new DateTime(2017, 4, 20),
                soldDate = new DateTime(2017, 6, 25),
                color = "Brownish",
                previousOwner = "None",
                price = 275
            };


            Pet pet2 = new Pet
            {
                id = id++,
                name = "Spoofy",
                type = PetTypes.Cat,
                birthDate = new DateTime(2018, 3, 10),
                soldDate = new DateTime(2018, 3, 30),
                color = "White and black",
                previousOwner = "None",
                price = 550
            };

            Pet pet3 = new Pet
            {
                id = id++,
                name = "Goop",
                type = PetTypes.BeardedDragon,
                birthDate = new DateTime(2016, 10, 18),
                soldDate = new DateTime(2017, 2, 15),
                color = "Orange and a little brown",
                previousOwner = "Karl Larsen",
                price = 350
            };

            petList = new List<Pet> { pet, pet2, pet3 };
            
        }
    }
}
