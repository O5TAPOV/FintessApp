namespace FintessApp.BL.Model
{
    /// <summary>
    /// Стать.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Назва.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Створити нову стать
        /// </summary>
        /// <param name="name">Назва статті</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException("Назва статі не можу бути пуста або null", nameof(name));

            Name = name;
        }

        public override string ToString() => Name;
    }
}