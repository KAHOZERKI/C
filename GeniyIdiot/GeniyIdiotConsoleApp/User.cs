namespace GeniusIdiotConsoleApp
{
    public class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
        public static bool GetUserChoice(string userChoice)
        {
            while (userChoice != "да" && userChoice != "нет")
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userChoice = Console.ReadLine().ToLower();
                userChoice = ActionsWithInputString.CheckForNullorWhiteSpace(userChoice);
            }
            if (userChoice == "да")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

