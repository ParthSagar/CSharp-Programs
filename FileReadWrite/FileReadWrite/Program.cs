using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class Program
    {
        private static string s;
        static void Main(string[] args)
        {
            String f="test.txt";
            string st = "Yes";
            do
            {
                Console.WriteLine("you want to Read or Write or " +
                                  "Delete file or Rename or Info or Exit?");
                s = Console.ReadLine();
                if (s == "Read")
                {
                    if (File.Exists(f))
                    {
                        string content = File.ReadAllText(f);
                        Console.WriteLine("current content");
                        Console.WriteLine(content);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else if (s == "Write")
                {
                    Console.WriteLine("Please enter the new content to file and enter exit");
                    string newContent = Console.ReadLine();
                    while (newContent != "exit")
                    {
                        File.AppendAllText(f, newContent + Environment.NewLine);
                        newContent = Console.ReadLine();
                    }

                }
                else if (s == "Delete")
                {
                    if (File.Exists(f))
                    {
                        File.Delete(f);
                        if (File.Exists(f) == false)
                            Console.WriteLine("File Deleted");
                    }
                    else
                    {
                        Console.WriteLine("File does not exists");
                    }
                }
                else if (s == "Rename")
                {
                    Console.WriteLine("Please Enter the new Name of the file");
                    string nf = Console.ReadLine();
                    if (nf != String.Empty)
                    {
                        File.Move(f, nf);
                        if (File.Exists(nf))
                        {
                            Console.WriteLine("File Renamed");
                            f = nf;
                        }
                    }
                }
                else if (s=="Info")
                {
                    FileInfo fi=new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    if(fi!=null)
                        Console.WriteLine(String.Format("Information about file" +
                                                        "{0},{1} bytes, Last Modified on {2} -" +
                                                        "Full Path: {3}",fi.Name,fi.Length,fi.LastWriteTime,fi.FullName));
                }
                else
                    Environment.Exit(0);
                Console.WriteLine("Do you want to continue?(Yes/No)");
                st = Console.ReadLine();
            } while (st.ToLower() != "no");


        }
    }
}
