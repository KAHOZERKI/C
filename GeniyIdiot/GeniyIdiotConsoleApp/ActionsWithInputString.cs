namespace GeniusIdiotConsoleApp
{
    public class ActionsWithInputString
    {
        public static string CheckForNullorWhiteSpace(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Пожалуйста,не оставляйте эту строку пустой");
                input = Console.ReadLine();
            }
            return input;
        }
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
      public  static string GetValidInput()
        {
            string input = Console.ReadLine();
            return ActionsWithInputString.CheckForNullorWhiteSpace(input);
        }
    }
}

