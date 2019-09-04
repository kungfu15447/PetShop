using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Implementation
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }
        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.AddOwner(owner);
        }

        public Owner DeleteOwner(Owner owner)
        {
            return _ownerRepo.DeleteOwner(owner);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadOwners().ToList();
        }

        public Owner GetOwner(int id)
        {
            return _ownerRepo.ReadOwner(id);
        }

        public Owner UpdateOwner(Owner toBeUpdated, Owner updatedOwner)
        {
            return _ownerRepo.UpdateOwner(toBeUpdated, updatedOwner);
        }
    }
}
