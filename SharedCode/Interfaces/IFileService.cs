using SharedCode.Models;
using System.Collections.Generic;

namespace SharedCode
{
    public interface IFileService
    {
        List<Contact> ReadFromFile(string fileName);
        void WriteToFile(string fileName, List<Contact> data);
    }
}