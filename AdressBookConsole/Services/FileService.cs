using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace AdressBookConsole.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath;
        /// <summary>
        /// Constructor for FileService, specifying the file path.
        /// </summary>
        public FileService(string filePath)
        {
            _filePath = filePath;
        }
        /// <summary>
        /// Writes contact data to a file using JSON serialization.
        /// </summary>
        public void WriteToFile(string fileName, List<Contact> data)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data);
                File.WriteAllText(Path.Combine(_filePath, fileName), jsonData);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
        /// <summary>
        /// Reads contact data from a file using JSON deserialization.
        /// </summary>
        public List<Contact> ReadFromFile(string fileName)
        {
            try
            {
                if (File.Exists(Path.Combine(_filePath, fileName)))
                {
                    string jsonData = File.ReadAllText(Path.Combine(_filePath, fileName));
                    return JsonConvert.DeserializeObject<List<Contact>>(jsonData);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading from file: {ex.Message}");
            }
            return new List<Contact>();
        }
    }
}