using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using System.Net;

namespace AdressBookConsole.Services
{
    public class MenuService : IMenuService
    {
        private readonly IContactRepository _contactRepository;

        /// <summary>
        /// Constructor to initialize MenuService with a contact repository.
        /// </summary>

        public MenuService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// Displays the main menu and handles user choices.
        /// </summary>
        public void ShowMainMenu()
        {
            while (true)
            { Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Choose an option:\n");
                Console.WriteLine("1. Add a contact");
                Console.WriteLine("2. Remove a contact");
                Console.WriteLine("3. View all contacts");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        RemoveContact();
                        break;
                    case "3":
                        ViewAllContacts();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        /// <summary>
        /// Adds a new contact with user-inputted information.
        /// </summary>
        private void AddContact()
        {

            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            Console.Write("Enter the phone number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter the address : ");
            string address = Console.ReadLine();

            // Adding contact to the repository
            _contactRepository.AddContact(new Contact { FirstName = name, Email = email, PhoneNumber = phone, Address = address });

            Console.WriteLine("Contact added successfully!");
        }
        /// <summary>
        /// Removes a contact based on the user-inputted email.
        /// </summary>
        private void RemoveContact()
        {
            Console.Write("Enter the email of the contact to remove: ");
            string email = Console.ReadLine();
            // Removing contact from the repository
            _contactRepository.RemoveContact(email);

            Console.WriteLine("Contact removed successfully!");
        }
        /// <summary>
        /// Displays all contacts or a message if there are none.
        /// </summary>
        private void ViewAllContacts()
        {
           
            var contacts = _contactRepository.GetAllContacts();

            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("There are no contacts available.");
            }
        }
    }
}