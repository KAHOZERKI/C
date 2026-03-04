namespace GeniusIdiotConsoleApp
{
    public class FileSystem
    {
      static  string path = "note.txt";
        public static void WriteSystemFile(string userName, int correctAnswersCount, string diagnosis)
        {
            string table = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", "ФИО", "кол-во правильных ответ", "Диагноз");  
            string userDataForTable = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", userName, correctAnswersCount, diagnosis);
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                if (new FileInfo(path).Length == 0)
                {
                    sw.WriteLine(table);
                }
                sw.WriteLine(userDataForTable);
            }
        }
        public static void ReadSystemFile()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
        

