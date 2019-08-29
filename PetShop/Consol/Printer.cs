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
                "Show list of pets by type",
                "Show list of pets ordered by price",
                "Show the five cheapest pets",
                "Exit"
            };
        }

        #region Menu stuff
        public void startUI()
        {
            Console.WriteLine("Welcome to PetShop");

            showMenu();

            int selection = parseSelection();

            while (selection != itemList.Length)
            {
                Pet pet;
                switch (selection)
                {
                    case 1:
                        pet = CreatePet();
                        Console.WriteLine("The pet {0} has been added", pet.name);
                        break;
                    case 2:
                        PrintPets(_petserv.GetPets());
                        break;
                    case 3:
                        pet = DeletePet();
                        if (pet == null)
                        {
                            Console.WriteLine("Could not find a pet with that Id. No pet deleted");
                        } else
                        {
                            Console.WriteLine("The pet {0} has ben succesfully deleted", pet.name);
                        }
                        break;
                    case 4:
                        pet = UpdatePet();
                        if (pet == null)
                        {
                            Console.WriteLine("Could not find a pet with that Id. No pet got updated");
                        } else
                        {
                            Console.WriteLine("The pet has been updated to {0} succesfully", pet.name);
                        }
                        break;
                    case 5:
                        PrintPetsByType();
                        break;
                    case 6:
                        PrintPets(_petserv.GetPetsByOrderedPrice());
                        break;
                    case 7:
                        PrintPets(_petserv.GetFiveCheapestPets());
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

        private void showMenu()
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < itemList.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, itemList[i]);
            }
        }
        #endregion

        #region CRUD
        private void PrintPets(List<Pet> pets)
        {
            if (pets.Count == 0)
            {
                Console.WriteLine("You have no pets to show");
            } else
            {
                foreach (Pet pet in pets)
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
            Pet pet = createAPetObject();
            return _petserv.CreatePet(pet);
        }

        private Pet createAPetObject()
        {
            Console.Write("Please type the pets name: ");
            string name = validateString();
            Console.Write("Please insert the pets type: ");
            PetTypes type = getPetType();
            Console.Write("Please type the pets birth date: ");
            DateTime birthDate = validateTime();
            Console.Write("Please type the pets sold date: ");
            DateTime soldDate = validateTime();
            Console.Write("Please type the pets color/colors: ");
            string color = validateString();
            Console.Write("Please type the pets previous owner or \"none\": ");
            string previousOwner = validateString();
            Console.Write("Please insert the pets price: ");
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

            return pet;
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

        private Pet DeletePet()
        {
            Console.Write("Type the id of the pet you want to delete: ");
            int petId = parseThisInteger();
            Pet pet = _petserv.GetPet(petId);
            if (pet != null)
            {
                return _petserv.DeletePet(pet);
            }
            else
            {
                return null;
            }
        }

        private Pet UpdatePet()
        {
            Console.Write("Type the id of the pet you want to update: ");
            int petId = parseThisInteger();
            Pet petToUpdate = _petserv.GetPet(petId);
            if (petToUpdate != null)
            {
                Console.WriteLine("Please type the new informations for this pet to update it:");
                Pet updatedPet = createAPetObject();
                return _petserv.UpdatePet(petToUpdate, updatedPet);
            } else
            {
                return null;
            }
        }

        private void PrintPetsByType()
        {
            printAllPetTypes();
            Console.Write("Please enter the type of pets you want to be shown: ");
            PetTypes type = getPetType();
            List<Pet> petsByType = _petserv.GetPetsByType(type);
            if (petsByType.Count == 0)
            {
                Console.WriteLine("There are no pets by that type to be shown");
            } else
            {
                PrintPets(petsByType);
            }
        }
        #endregion

        #region Validation Or Parsing Code
        private string validateString()
        {
            string toBeValidated = Console.ReadLine();
            bool isValidated = false;
            while(!isValidated)
            {
                bool isEmpty = false;
                bool isNumber = false;
                if (String.IsNullOrEmpty(toBeValidated))
                {
                    isEmpty = true;
                }
                else
                {
                    foreach (Char cha in toBeValidated.ToCharArray(0, toBeValidated.Length))
                    {
                        if (char.IsDigit(cha))
                        {
                            isNumber = true;
                            break;
                        }
                    }
                }
                if (isEmpty)
                {
                    Console.WriteLine("You have to type something");
                    Console.Write("Please try again: ");
                    toBeValidated = Console.ReadLine();
                } else if (isNumber)
                {
                    Console.WriteLine("Your input cannot contain a number");
                    Console.Write("Please try again: ");
                    toBeValidated = Console.ReadLine();
                } else
                {
                    isValidated = true;
                }

            }
            return toBeValidated;
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

        private DateTime validateTime()
        {
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please use the format dd/mm/yyyy or dd-mm-yyyy");
                Console.Write("Type a new date: ");
            }
            return date;
        }

        private int parseThisInteger()
        {
            int parsing;
            while (!int.TryParse(Console.ReadLine(), out parsing))
            {
                Console.WriteLine("Please type a number");
                Console.Write("Number: ");
            }
            return parsing;
        }

        private int parseSelection()
        {
            Console.Write("Please type a number: ");
            int selection = parseThisInteger();
            while (selection < 1 || selection > itemList.Length)
            {
                Console.WriteLine("Please choose a number thats between 1-{0}", itemList.Length);
                Console.Write("Number: ");
                selection = parseThisInteger();
            }
            return selection;
        }

        private PetTypes getPetType()
        {
            PetTypes type;
            while (!Enum.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("This type of pet does not exist");
                printAllPetTypes();
            }
            return type;
        }
        #endregion

    }
}
