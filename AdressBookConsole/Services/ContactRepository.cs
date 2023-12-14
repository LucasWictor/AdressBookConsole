using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;

namespace AdressBookConsole.Services
{
    public class ContactRepository : IContactRepository
    {
        private List<Contact> contacts;
        private readonly IFileService fileService;
        private readonly string filePath = @"C:\Projects\contacts.json"; 

        /// <summary>
        /// Constructor for ContactRepository, initializing with a file service and loading contacts from a file.
        /// </summary>
        public ContactRepository(IFileService fileService)
        {
            this.fileService = fileService;
            contacts = LoadContactsFromFile() ?? new List<Contact>();
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        /// <summary>
        /// Retrieves a contact from the provided email.
        /// </summary>
        public Contact GetContactByEmail(string email)
        {
            return contacts.FirstOrDefault(c => c.Email == email);
        }

        /// <summary>
        /// Adds a new contact and saves the updated contacts to a Json file.
        /// </summary>
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            SaveContactsToFile();
        }

        /// <summary>
        /// Removes a contact based on the provided email and saves the updated contacts to a Json file.
        /// </summary>
        public void RemoveContact(string email)
        {
            var contactToRemove = GetContactByEmail(email);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                SaveContactsToFile();
            }
        }

        /// <summary>
        /// Saves the current list of contacts to a Json file.
        /// </summary>
        public void SaveContactsToFile()
        {
            fileService.WriteToFile(filePath, contacts);
        }

        /// <summary>
        /// Loads contacts from Json during object initialization.
        /// </summary>
        private List<Contact> LoadContactsFromFile()
        {
            return fileService.ReadFromFile(filePath);
        }
    }
}