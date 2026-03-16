
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
    }
}
