using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            pet.id = FakeDB.id++;
            List<Pet> pets = FakeDB.petList.ToList();
            pets.Add(pet);
            FakeDB.petList = pets;
            return pet;
        }

        public Pet DeletePet(Pet pet)
        {
            List<Pet> pets = FakeDB.petList.ToList();
            pets.Remove(pet); 
            FakeDB.petList = pets;
            return pet;
        }

        public Pet readPet(int id)
        {
            List<Pet> pets = FakeDB.petList.ToList();
            foreach(Pet pet in pets)
            {
                if (id == pet.id)
                {
                    return pet;
                }
            }
            return null;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.petList;
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            List<Pet> pets = FakeDB.petList.ToList();
            foreach(Pet pet in pets)
            {
                if (pet.id == petToUpdate.id)
                {
                    pet.name = updatedPet.name;
                    pet.type = updatedPet.type;
                    pet.birthDate = updatedPet.birthDate;
                    pet.soldDate = updatedPet.soldDate;
                    pet.color = updatedPet.color;
                    pet.previousOwner = updatedPet.previousOwner;
                    pet.price = updatedPet.price;
                }
            }
            FakeDB.petList = pets;
            return updatedPet;
        }
    }
}
