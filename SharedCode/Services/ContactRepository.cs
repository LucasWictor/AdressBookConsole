using SharedCode.Models;
using System.Collections.Generic;
using System.Linq;

namespace SharedCode
{
    public class ContactRepository : IContactRepository
    {
        private List<Contact> contacts;
        private readonly IFileService fileService;
        private readonly string filePath = @"C:\Projects\contacts.json";

        public ContactRepository(IFileService fileService)
        {
            this.fileService = fileService;
            contacts = LoadContactsFromFile() ?? new List<Contact>();
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
            fileService.WriteToFile(filePath, contacts);
        }

        private List<Contact> LoadContactsFromFile()
        {
            return fileService.ReadFromFile(filePath);
        }
    }
}