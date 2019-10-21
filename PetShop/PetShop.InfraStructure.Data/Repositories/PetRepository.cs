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
        public int Count()
        {
            throw new NotImplementedException();
        }

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
                if (petowner.PetId == pet.id)
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

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            List<Pet> petList = FakeDB.petList.ToList();
            foreach (Pet pet in petList)
            {
                addOwnersToPet(pet);
            }
            return FakeDB.petList;
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            List<Pet> pets = FakeDB.petList.ToList();
            foreach(Pet pet in pets)
            {
                if (pet.id == petToUpdate.id)
                {
                    pet.name = petToUpdate.name;
                    pet.type = petToUpdate.type;
                    pet.birthDate = petToUpdate.birthDate;
                    pet.soldDate = petToUpdate.soldDate;
                    pet.color = petToUpdate.color;
                    pet.price = petToUpdate.price;
                }
            }
            FakeDB.petList = pets;
            return petToUpdate;
        }

        private void addOwnersToPet(Pet pet)
        {
            //pet.owners = new List<Owner>();
            foreach (PetOwner petowner in FakeDB.petOwnerList.ToList())
            {
                if (petowner.PetId == pet.id)
                {
                    Owner owner = FakeDB.ownerList.FirstOrDefault(O => O.id == petowner.OwnerId);
                    if (owner != null)
                    {
                        //pet.owners.Add(owner);
                    }
                }
            }
        }
    }
}
