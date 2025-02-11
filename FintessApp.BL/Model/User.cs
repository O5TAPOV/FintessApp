using System.Text.Json.Serialization;

namespace FintessApp.BL.Model
{
    /// <summary>
    /// Користувач.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Властивості
        /// <summary>
        /// Ім'я.
        /// </summary>
        public string? Name {get; }

        /// <summary>
        /// Стать.
        /// </summary>
        public Gender? Gender { get; }

        /// <summary>
        /// Дата народження.
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Вага.
        /// </summary>
        public double Weight { get; set; } 

        /// <summary>
        /// Зріст.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Створити нового користувача.
        /// </summary>
        /// <param name="name"> Ім'я. </param>
        /// <param name="gender"> Стать. </param>
        /// <param name="birthDate"> Дата народження. </param>
        /// <param name="weight"> Вага. </param>
        /// <param name="height"> Зріст. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Перевірка умов
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Ім'я користувача не може бути пустим або null. ", nameof(name));

            if (gender == null)
                throw new ArgumentNullException("Стать не може бути null. ", nameof(gender));

            if (birthDate < DateTime.Parse("01.01.1900"))
                throw new ArgumentException("Дата не може бути менше 01.01.1900. ", nameof(birthDate));

            if(birthDate > DateTime.Now)
                throw new ArgumentException("Дата не може бути більше сьогоднішньої. ", nameof(birthDate));

            if (weight <= 0.0)
                throw new ArgumentException("Вага людини не може бути менше нуля або дорівнювати йому. ", nameof(weight));

            if(height <= 0.0)
                throw new ArgumentException("Висота людини не може бути менше нуля або дорівнювати йому. ", nameof(height));

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString() => Name!;
    }
}
