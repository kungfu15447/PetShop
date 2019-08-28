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
    }
}
