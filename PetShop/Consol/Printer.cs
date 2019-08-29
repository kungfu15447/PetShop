using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Consol
{
    
    public class Printer : IPrinter
    {
        String[] itemList;
        IPetService _petserv;

        public Printer(IPetService petserv)
        {
            _petserv = petserv;
            itemList = new string[]
            {
                "Create pet",
                "Show list of pets",
                "Delete pet",
                "Update pet",
                "Exit"
            };
        }

        public void startUI()
        {
            Console.WriteLine("Welcome to PetShop");

            showMenu();

            int selection = parseSelection();

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        Pet pet = CreatePet();
                        Console.WriteLine("The pet {0} has been added", pet.name);
                        break;
                    case 2:
                        listAllPets();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
                showMenu();
                selection = parseSelection();
            }

            Console.WriteLine("Thank you for using PetShop");
            Console.WriteLine("Shutting down...");
            
        }

        private int parseThisInteger()
        {
            int parsing;
            while (!int.TryParse(Console.ReadLine(), out parsing))
            {
                Console.WriteLine("Please type a number");
            }
            return parsing;
        }

        private int parseSelection()
        {
            Console.Write("Please type a number: ");
            int selection = parseThisInteger();
            while (selection < 1 || selection > 5)
            {
                Console.WriteLine("Please choose a number thats between 1-5");
                selection = parseThisInteger();
            }
            return selection;
        }

        private void showMenu()
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < itemList.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, itemList[i]);
            }
        }

        private void listAllPets()
        {
            if (_petserv.GetPets().Count == 0)
            {
                Console.WriteLine("You have no pets to show");
            } else
            {
                foreach (Pet pet in _petserv.GetPets())
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Id: {0}", pet.id);
                    Console.WriteLine("Name: {0}", pet.name);
                    Console.WriteLine("Type: {0}", pet.type);
                    Console.WriteLine("Birth Date: {0}", pet.birthDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Sold Date: {0}", pet.soldDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Previous Owner: {0}", pet.previousOwner);
                    Console.WriteLine("Price: {0}", pet.price);
                    Console.WriteLine("----------------------");
                }
            }
        }

        private Pet CreatePet()
        {
            Console.Write("Please type the pets name: ");
            string name = Console.ReadLine();
            Console.Write("Please type the pets specie: ");
            PetTypes type = getPetType();
            Console.Write("Please type the pets birth date: ");
            DateTime birthDate = validateTime();
            Console.Write("Please type the pets sold date: ");
            DateTime soldDate = validateTime();
            Console.Write("Please type the pets color/colors: ");
            string color = Console.ReadLine();
            Console.Write("Please type the pets previous owner or \"none\": ");
            string previousOwner = Console.ReadLine();
            Console.WriteLine("Please insert the pets price: ");
            double price = parseThatDouble();

            Pet pet = new Pet
            {
                name = name,
                type = type,
                birthDate = birthDate,
                soldDate = soldDate,
                color = color,
                previousOwner = previousOwner,
                price = price
            };

            return _petserv.CreatePet(pet);
        }

        private PetTypes getPetType()
        {
            PetTypes type;
            while (Enum.TryParse(Console.ReadLine().ToLower(), false, out type))
            {               
                Console.WriteLine("This type of pet does not exist");
                printAllPetTypes();
            }
            return type;
        }

        private void printAllPetTypes()
        {
            Console.WriteLine("These are the types of pet that exist");
            string[] types = Enum.GetNames(typeof(PetTypes));
            foreach (string type in types)
            {
                Console.Write(type + " ");
            }
            Console.WriteLine();
        }

        private DateTime validateTime()
        {
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please type the date in the format dd/mm/yyyy");
            }
            return date;
        }

        private double parseThatDouble()
        {
            double doubleToParse;
            while (!double.TryParse(Console.ReadLine(), out doubleToParse))
            {
                Console.WriteLine("Please type a number");
                Console.Write("Number: ");
            }
            return doubleToParse;
        }

    }
}
