using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class PetService : IPetService
    {
        IPetRepository _petRepo;
        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public Pet DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            throw new NotImplementedException();
        }
    }
}
