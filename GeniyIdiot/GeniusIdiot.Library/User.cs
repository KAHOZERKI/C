namespace GeniusIdiot.Library
{
    public class User
    {
        public User() { }
        public string Name { get; set; }
        public int CorrectRightAnswers { get; set; }
        public string Diagnosis { get; set; }

        public User(string name)
        {
            Name = name;
            CorrectRightAnswers = 0;
        }
    }
}

