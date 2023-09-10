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
            var dir1 = "C:\\Otus\\TestDir1";
            var dir2 = "C:\\Otus\\TestDir2";
            var directoryInfo1 = new DirectoryInfo(dir1);
            var directoryInfo2 = new DirectoryInfo(dir2);

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
                        var path = @"C:\Otus\TestDir" + j + @"\File" + i + ".txt";
                        if (!File.Exists(path))
                        {
                            try {
                                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
                                {
                                    sw.WriteLine(DateTime.Now);
                                    sw.WriteLine(Path.GetFileName(path));
                                    sw.Close();
                                }
                            } 
                            catch (Exception e)  
                            {
                                Console.WriteLine("The file does not have write access: {0}", e.ToString());
                            }
                            
                            using (StreamReader sr = new StreamReader(path))
                            {
                                string text = sr.ReadLine();
                                Console.WriteLine("\n");
                                Console.WriteLine(text + " . File name - " + Path.GetFileName(path));
                            }
                        }
                        else
                        {
                            Console.WriteLine("File does not exist.");
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
