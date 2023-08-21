using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    internal class Directory
    {
        
        public void DirectoryInfo()
        {
            string dir1 = "C:\\Otus\\TestDir1";
            string dir2 = "C:\\Otus\\TestDir2";
            DirectoryInfo directoryInfo1 = new DirectoryInfo(dir1);
            DirectoryInfo directoryInfo2 = new DirectoryInfo(dir2);

            try
            {
                if (directoryInfo1.Exists)
                {
                    Console.WriteLine("This path TestDir1 exist already.");
                    return;
                }
                else if (directoryInfo2.Exists)
                {
                    Console.WriteLine("This path TestDir2 exist already.");
                    return;
                }

                directoryInfo1.Create();
                Console.WriteLine("The directory1 was created successfully.");
                directoryInfo2.Create();
                Console.WriteLine("The directory2 was created successfully.");
                for (int j = 1; j <= 2; j++)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        string path = @"C:\Otus\TestDir" + j + @"\File" + i + ".txt";
                        using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
                        {
                            sw.WriteLine(DateTime.Now);
                            sw.Close();
                        }

                        using (StreamReader sr = new StreamReader(path, true))
                        {
                            string text = sr.ReadLine();
                            Console.WriteLine("\n");
                            Console.WriteLine(text + " . Имя файла - " + path.Substring(17));
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

        }


    }
}
