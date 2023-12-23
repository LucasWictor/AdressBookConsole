using System.Collections.Generic;
using SharedCode.Models;

namespace InterfacesSharedCode.interfaces
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
