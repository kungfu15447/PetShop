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
            List<PetOwner> petOwners = FakeDB.petOwnerList.ToList();
            foreach(PetOwner petowner in petOwners)
            {
                if (petowner.PId == pet.id)
                {
                    petOwners.Remove(petowner);
                }
            }
            FakeDB.petOwnerList = petOwners;
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
                    addOwnersToPet(pet);
                    return pet;
                }
            }
            return null;
        }

        public IEnumerable<Pet> ReadPets()
        {
            List<Pet> petList = FakeDB.petList.ToList();
            foreach (Pet pet in petList)
            {
                addOwnersToPet(pet);
            }
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

        private void addOwnersToPet(Pet pet)
        {
            pet.owners = new List<Owner>();
            foreach (PetOwner petowner in FakeDB.petOwnerList.ToList())
            {
                if (petowner.PId == pet.id)
                {
                    Owner owner = FakeDB.ownerList.FirstOrDefault(O => O.id == petowner.OId);
                    if (owner != null)
                    {
                        pet.owners.Add(owner);
                    }
                }
            }
        }
    }
}
