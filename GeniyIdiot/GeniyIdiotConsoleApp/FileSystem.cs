namespace GeniusIdiotConsoleApp
{
    public class FileSystem
    {

        public static void Append(string path, string text)
        {
            StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
            sw.WriteLine(text);
            sw.Close();
        }
        public static string Read(string path)
        {
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            var content = sr.ReadToEnd();
            sr.Close();
            return content;
        }
        public static bool IsEmpty(string path)
        {
            if (!File.Exists(path)) return true;
            return new FileInfo(path).Length == 0;
        }
        public static void ClearFile(string path)
        {
            StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default);
            sw.Close();
        }
        
    }
}

