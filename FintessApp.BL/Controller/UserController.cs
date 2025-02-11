using FintessApp.BL.Model;
using System.Text.Json;

namespace FintessApp.BL.Controller
{
    /// <summary>
    /// Контролер користувача. 
    /// </summary>
    public class UserController
    {

        /// <summary>
        /// Користувач додатку. 
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Шлях до файлу із даними. 
        /// </summary>
        public string FilePath { get; set; } = "user.json";

        /// <summary>
        /// Створення нового контролера користувача. 
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }

        /// <summary>
        /// Завантажити дані користувача. 
        /// </summary>
        public UserController()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Console.WriteLine($"Файл {FilePath} не знайдено.");
                    User = null!;
                }

                string jsonString = File.ReadAllText(FilePath);

                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                };
                User = JsonSerializer.Deserialize<User>(jsonString, options)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні даних: {ex.Message}");
                User = null!;
            }
        }

        /// <summary>
        /// Зберегти дані користувача. 
        /// </summary>
        public bool Save()
        {
            try
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string jsonString = JsonSerializer.Serialize(User, options);

                File.WriteAllText(FilePath, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні даних: {ex.Message}");
                return false;
            }
        }

        
    }
}
