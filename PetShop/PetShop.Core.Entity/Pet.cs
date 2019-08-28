using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        int id { get; set; }
        string name { get; set; }
        enum type { Dog, Cat, Snake, BeardedDragon, Elephant, Goat}
        DateTime birthDate { get; set; }
        DateTime soldDate { get; set; }
        string color { get; set; }
        string previousOwner { get; set; }
        double price { get; set; }


    }
}
