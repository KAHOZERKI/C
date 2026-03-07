namespace GeniusIdiotConsoleApp
{
        public class FileSystem
        {
          static  string path = "note.txt";
        
            public static StreamWriter WriteSystemFile()
            {
            bool isNew = !File.Exists(path) || new FileInfo(path).Length == 0;
                StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                    if (isNew)
                    {
                string table = string.Format("|| {0,-25} || {1,-25} || {2,-10} ||", "ФИО", "кол-во правильных ответ", "Диагноз");
                sw.WriteLine(table);
                    }
            return sw;
            }
            public static string ReadSystemFile()
            {
                StreamReader sr = new StreamReader(path);
                string userResult = sr.ReadToEnd();
            sr.Close();
            return userResult;
            }
        }
}        

