using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class FakeDB
    {
        public static int id = 1;
        public static int ownerID = 1;
        public static IEnumerable<Pet> petList;
        public static IEnumerable<Owner> ownerList;
        public static IEnumerable<PetOwner> petOwnerList;

        public static void initData()
        {
            Owner owner1 = new Owner
            {
                id = ownerID++,
                firstName = "Simon",
                lastName = "Kjær",
                address = "Stengårdsvej 12"
            };

            Owner owner2 = new Owner
            {
                id = ownerID++,
                firstName = "Levis",
                lastName = "Kjongaard",
                address = "Hjertingvej 5"
            };

            Owner owner3 = new Owner
            {
                id = ownerID++,
                firstName = "Jens",
                lastName = "Padelsen",
                address = "Gl. Prinsevej 25"
            };

            Pet pet = new Pet
            {
                id = id++,
                name = "Rex",
                type = PetTypes.Dog,
                birthDate = new DateTime(2017, 4, 20),
                soldDate = new DateTime(2017, 6, 25),
                color = "Brownish",
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
                price = 350
            };

            Pet pet4 = new Pet
            {
                id = id++,
                name = "Dox",
                type = PetTypes.Dog,
                birthDate = new DateTime(2016, 9, 18),
                soldDate = new DateTime(2017, 12, 15),
                color = "Brown",
                price = 675
            };

            Pet pet5 = new Pet
            {
                id = id++,
                name = "Foo",
                type = PetTypes.Cat,
                birthDate = new DateTime(2016, 10, 18),
                soldDate = new DateTime(2017, 2, 15),
                color = "A little red",
                price = 2200
            };

            Pet pet6 = new Pet
            {
                id = id++,
                name = "Kentuck",
                type = PetTypes.Goat,
                birthDate = new DateTime(2000, 8, 6),
                soldDate = new DateTime(2001, 3, 20),
                color = "White",
                price = 200
            };

            Pet pet7 = new Pet
            {
                id = id++,
                name = "Maximus",
                type = PetTypes.Dog,
                birthDate = new DateTime(2010, 12, 30),
                soldDate = new DateTime(2011, 2, 20),
                color = "Pure black",
                price = 700
            };

            Pet pet8 = new Pet
            {
                id = id++,
                name = "Goop",
                type = PetTypes.BeardedDragon,
                birthDate = new DateTime(2012, 10, 18),
                soldDate = new DateTime(2015, 2, 15),
                color = "Colourful",
                price = 3500
            };

            Pet pet9 = new Pet
            {
                id = id++,
                name = "Pog",
                type = PetTypes.Elephant,
                birthDate = new DateTime(2017, 10, 7),
                soldDate = new DateTime(2018, 4, 21),
                color = "Orange and a little brown",
                price = 5000
            };

            PetOwner relation1 = new PetOwner
            {
                PetId = 1,
                OwnerId = 1
            };

            PetOwner relation2 = new PetOwner
            {
                PetId = 1,
                OwnerId = 2,
            };
            PetOwner relation3 = new PetOwner
            {
                PetId = 1,
                OwnerId = 3,

            };
            PetOwner relation4 = new PetOwner
            {
                PetId = 2,
                OwnerId = 1,
            };
            PetOwner relation5 = new PetOwner
            {
                PetId = 6,
                OwnerId = 2
            };
            PetOwner relation6 = new PetOwner
            {
                PetId = 8,
                OwnerId = 3
            };
            petList = new List<Pet> { pet, pet2, pet3, pet4, pet5, pet6, pet7, pet8, pet9};
            ownerList = new List<Owner> { owner1, owner2, owner3};
            petOwnerList = new List<PetOwner> { relation1, relation2, relation3, relation4, relation5, relation6};
        }
    }
}
