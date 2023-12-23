using SharedCode.Models;


namespace InterfacesSharedCode.interfaces
{
    public interface IFileService
    {
        List<Contact> ReadFromFile(string fileName);
        void WriteToFile(string fileName, List<Contact> data);
    }
}