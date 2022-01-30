using System;
using System.IO;

namespace JournalConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome Your Journal");
            string startText;
            bool statu = true;
            do
            {
                startText = Console.ReadLine().ToLower();
                if (startText == "start")
                    statu = false;
            } while (statu);
            Console.WriteLine("Captain's log");
            Console.WriteLine("StartDate<" + DateTime.Now.ToShortDateString() + ">");
            string date = DateTime.Now.ToShortDateString();
            var myJournal = new FileStream(@"C:\Journal\" + date + ".txt", FileMode.CreateNew);
            myJournal.Close();
            string text = "";

            using (StreamWriter sw = new StreamWriter(@"C:\Journal\" + date + ".txt"))
            {
                bool isEnd = true;
                do
                {
                    text = "";
                    text = Console.ReadLine();
                    if(text.EndsWith("stop") || text.EndsWith("Stop") || text.EndsWith("STOP"))
                    {
                        text=text.Remove(text.Length - 4);
                        isEnd = false;
                    }
                    sw.WriteLine(text);
                } while (isEnd);
                
            }
            Console.ReadLine();
        }
    }
}
