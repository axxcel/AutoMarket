using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Text;
using System;
using System.Data;

namespace DLLForWriteLogs
{
    public class WriteLogs
    {
        public async void Logs(string buttonText)
        {
            if (File.Exists("logs.txt"))
            {
                File.AppendAllText("logs.txt", "Кнопка " + buttonText + " была нажата " + DateTime.Now.ToString() + "\n");

            }
            else
            {
                FileStream fstream = new FileStream("logs.txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fstream);
                sw.Write("Кнопка " + buttonText + " была нажата " + DateTime.Now.ToString() + "\n");
                sw.Close();
                fstream.Close();
            }
        }
    }
}