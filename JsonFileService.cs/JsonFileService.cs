using System.Text.Json;
using PruebaApi.Models;


namespace PruebaApi.Services
{
    public class JsonFileService
    {
        private T LoadModelFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath)) return default(T);
            
            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        private void SaveModelToFile<T>(string filePath, T model)
        {
            var jsonString = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
        // Métodos específicos para cargar y guardar libros y usuarios
        public List<Book> GetBooks()
        {
            return LoadModelFromFile<List<Book>>("books.json");
        }

        public void SaveBooks(List<Book> books)
        {
            SaveModelToFile("books.json", books);
        }
    }
}