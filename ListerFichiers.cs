using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace ListerFichiers
{
    class ListerFichiers
    {
        static void Main(string[] args)
        {
             var dirnames = Directory.GetDirectories("\\GîtHub");

            int i = 0;

            try
            {
                foreach (var dir in dirnames)
                {
                    var fnames = Directory.GetFiles(dir);

                    DirectoryInfo d = new DirectoryInfo(dir);
                    Console.WriteLine(dir);
                    FileInfo[] finfo = d.GetFiles("*.*");

                    foreach (var f in fnames)
                    {
                        i++;
                        if (f.Split('\\')[0] != "\\System Volume Information")
                        {
                            Console.Write("Index "+ i);
                            Console.Write(Path.Combine(d.FullName, f));
                            File.Move(Path.Combine(d.FullName, f), Path.Combine(d.FullName, f).ToUpper()); //renommer en majuscules
                            Console.WriteLine(" en date du {0} ", File.GetLastWriteTime(dir));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
