using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdressBookConsole.Services
{
    public class ContactRepository : IContactRepository
    {
        private List<Contact> contacts;
        private readonly IFileService fileService;

        public ContactRepository(IFileService fileService)
        {
            this.fileService = fileService;
            LoadContactsFromFile();
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public Contact GetContactByEmail(string email)
        {
            return contacts.FirstOrDefault(c => c.Email == email);
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            SaveContactsToFile();
        }

        public void RemoveContact(string email)
        {
            var contactToRemove = GetContactByEmail(email);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                SaveContactsToFile();
            }
        }

        public void SaveContactsToFile()
        {
            fileService.WriteToFile(@"C:\Projects\contacts.json", contacts);
        }

        private void LoadContactsFromFile()
        {
            contacts = fileService.ReadFromFile(@"C:\Projects\contacts.json") ?? new List<Contact>();
        }
    }
}