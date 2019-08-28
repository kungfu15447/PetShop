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
        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }
    }
}
