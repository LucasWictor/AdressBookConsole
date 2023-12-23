using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using SharedCode.Models;

namespace SharedCode
{
    public class FileService : IFileService
    {
        private readonly string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

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