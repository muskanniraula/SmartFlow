using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartFlow.Services
{
    public class GenericService<T> where T : class
    {
        protected static List<T> GetAll(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return [];
            }

            var json = File.ReadAllText(filePath);

            var result = JsonSerializer.Deserialize<List<T>>(json);

            return result ?? [];
        }

        /// <summary>
        /// Defines a method to save all the list of items into a serialized json string
        /// </summary>
        /// <param name="entity">List of items</param>
        /// <param name="directoryPath">Path of the directory storage</param>
        /// <param name="filePath">Path of the file to be stored</param>
        protected static void SaveAll(List<T> entity, string filePath)
        {

            var json = JsonSerializer.Serialize(entity);

            File.WriteAllText(filePath, json);
        }
    }
}