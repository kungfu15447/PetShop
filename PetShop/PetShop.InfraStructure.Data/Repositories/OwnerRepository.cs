using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.InfraStructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner AddOwner(Owner owner)
        {
            owner.id = FakeDB.ownerID++;
            List<Owner> owners = FakeDB.ownerList.ToList();
            owners.Add(owner);
            FakeDB.ownerList = owners;
            return owner;
        }

        public Owner DeleteOwner(Owner owner)
        {
            List<Owner> owners = FakeDB.ownerList.ToList();
            owners.Remove(owner);
            FakeDB.ownerList = owners;
            return owner;
        }

        public Owner ReadOwner(int id)
        {
            List<Owner> owners = FakeDB.ownerList.ToList();
            foreach(Owner owner in owners)
            {
                if (owner.id == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public IEnumerable<Owner> ReadOwners(Filter filter)
        {
            List<Owner> owners = FakeDB.ownerList.ToList();
            foreach (Owner owner in owners)
            {
                AddPetsToOwner(owner);
            }
            return FakeDB.ownerList;
        }

        private void AddPetsToOwner(Owner owner)
        {
            //owner.pets = new List<Pet>();
            foreach (PetOwner petowner in FakeDB.petOwnerList.ToList())
            {
                if (petowner.OwnerId == owner.id)
                {
                    Pet pet = FakeDB.petList.FirstOrDefault(P => P.id == petowner.PetId);
                    if (pet != null)
                    {
                        //owner.pets.Add(pet);
                    }
                }
            }
        }

        public Owner UpdateOwner(Owner toBeUpdated, Owner updatedOwner)
        {
            List<Owner> owners = FakeDB.ownerList.ToList();
            foreach(Owner owner in owners)
            {
                if (owner.id == toBeUpdated.id)
                {
                    owner.firstName = updatedOwner.firstName;
                    owner.lastName = updatedOwner.lastName;
                    owner.address = updatedOwner.address;
                }
            }
            return updatedOwner;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
