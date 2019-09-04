using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/Pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetPet(id);
        }

        // POST api/pet
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
               return _petService.CreatePet(pet);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/pet/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet updatedPet)
        {
            Pet petToUpdate = _petService.GetPet(id);
            _petService.UpdatePet(petToUpdate, updatedPet);
        }

        // DELETE api/pet/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Pet pet = _petService.GetPet(id);
            _petService.DeletePet(pet);
        }
    }
}