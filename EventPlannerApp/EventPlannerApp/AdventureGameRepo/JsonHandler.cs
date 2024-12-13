using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Xml;

namespace AdventureGameRepo
{
    public class JsonHandler
    {
        // Method to read JSON data from a file and deserialize it into a list of objects
        public List<T> ReadJson<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found.");
                    return new List<T>();
                }

                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON data: {ex.Message}");
                return new List<T>();
            }
        }

        // Method to serialize a list of objects and write it to a JSON file
        public void WriteJson<T>(string filePath, List<T> data)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing JSON data: {ex.Message}");
            }
        }

        // Method to query JSON data using LINQ
        public List<T> QueryJsonData<T>(List<T> data, Func<T, bool> predicate)
        {
            try
            {
                return data.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying JSON data: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
