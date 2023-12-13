using AdressBookConsole.Models;

namespace AdressBookConsole.Interfaces
{
    public interface IFileService
    {
        List<Contact> ReadFromFile(string fileName);
        void WriteToFile(string fileName, List<Contact> data);
    }
}