using FintessApp.BL.Controller;
using FintessApp.BL.Model;

namespace FintessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас вітає додаток FintessApp");
            
            Console.Write("Введіть ім'я користувача: ");
            var name = Console.ReadLine();

            Console.Write("Введіть стать: ");
            var gender = Console.ReadLine();

            Console.Write("Введіть дату народження: ");
            var birthDate = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Введіть вагу: ");
            var weigth = double.Parse(Console.ReadLine()!);

            Console.Write("Введіть зріст: ");
            var heigth = double.Parse(Console.ReadLine()!);

            var userController = new UserController(name!, gender!, birthDate, weigth, heigth);
            userController.Save();
        }
    }
}
