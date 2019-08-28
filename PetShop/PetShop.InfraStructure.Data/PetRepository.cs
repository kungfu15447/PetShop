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
            List<Pet> pets = FakeDB.petList.ToList();
            pets.Add(pet);
            return pet;
        }

        public Pet DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.petList;
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            throw new NotImplementedException();
        }
    }
}
