namespace GeniusIdiot.Library
{
    public class User
    {
        public string Name { get; set; }
        public static int CorrectRightAnswers { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }
}

