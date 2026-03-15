
namespace GeniusIdiot.Library
{
    public class Check

    {
        public static bool CheckDigit(string input)
        {
            foreach (var symbol in input)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }
        public static string ChooseCorrectAnswer(string userChoice)
        {
           
            while ((userChoice != "да" && userChoice != "нет") || string.IsNullOrEmpty(userChoice))
            {
                Console.WriteLine("Пожалуйста, введите ДА или НЕТ");
                userChoice = Console.ReadLine().ToLower();
                
            }
            return userChoice;
        }
        public static bool GetUserChoice(string userChoice)
        {
            userChoice = ChooseCorrectAnswer(userChoice);
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
