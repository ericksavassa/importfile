using ImportFile.Domain.Interfaces;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImportFile.Infrastructure.Repositories.Mongo
{
    public class ItemJsRepository : IItemJsRepository
    {
        public async Task Save<T>(T deserializedObject)
        {
            try
            {
                var jsonFileName = GetJsonFileName();
                string path = GetPath(jsonFileName);

                var options = new JsonSerializerOptions { WriteIndented = true };

                using FileStream createStream = File.Create(path);
                await JsonSerializer.SerializeAsync<T>(createStream, deserializedObject, options);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetJsonFileName()
        {
            return DateTime.UtcNow.ToString()
                .Replace("\\", "_")
                .Replace("/", "_")
                .Replace(" ", "_")
                .Replace(":", "_") +
                ".json";
        }

        private static string GetPath(string jsonFileName)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), jsonFileName);
        }
    }
}