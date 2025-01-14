using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SmartFlow.Services
{
    public class GenericService<T> where T : class
    {
        protected static List<T> GetAll(string filePath)
        {
            // Check if file exists
            if (!File.Exists(filePath))
            {
                // Return an empty list if file doesn't exist
                return new List<T>();
            }

            // Read the file content
            var json = File.ReadAllText(filePath);

            // Deserialize the JSON content to a List<T>
            var result = JsonSerializer.Deserialize<List<T>>(json);

            // Return an empty list if the deserialization result is null
            return result ?? new List<T>();
        }

        /// <summary>
        /// Defines a method to save all the list of items into a serialized json string
        /// </summary>
        /// <param name="entity">List of items</param>
        /// <param name="filePath">Path of the file to be stored</param>
        protected static void SaveAll(List<T> entity, string filePath)
        {
            // Serialize the list into JSON string
            var json = JsonSerializer.Serialize(entity);

            // Ensure the directory exists before writing the file
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Write the serialized JSON to the file
            File.WriteAllText(filePath, json);
        }
    }
}
