using SharedCode;
using SharedCode.Models;

namespace AddressBookConsole.Services
{
    public class MenuService : IMenuService
    {
        private readonly IContactRepository _contactRepository;

        public MenuService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
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

        private void AddContact()
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the email: ");
            string email = Console.ReadLine();

            Console.Write("Enter the phone number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter the address: ");
            string address = Console.ReadLine();

            _contactRepository.AddContact(new Contact { FirstName = name, Email = email, PhoneNumber = phone, Address = address });

            Console.WriteLine("Contact added successfully!");
        }

        private void RemoveContact()
        {
            Console.Write("Enter the email of the contact to remove: ");
            string email = Console.ReadLine();

            _contactRepository.RemoveContact(email);

            Console.WriteLine("Contact removed successfully!");
        }

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