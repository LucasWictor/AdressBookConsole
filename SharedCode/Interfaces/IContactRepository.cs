using SharedCode.Models;
using System.Collections.Generic;

namespace SharedCode
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact GetContactByEmail(string email);
        void AddContact(Contact contact);
        void RemoveContact(string email);
        void SaveContactsToFile();
    }
}