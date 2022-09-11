using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using System.Runtime.CompilerServices;

namespace Rainbow
{

    public class sort
    {
        public string Name;
        public int std;
        public List<sort> ReadUserFile()
        {
            List<sort> lstUser;

            string[] content1 = File.ReadAllLines("G:\\C#\\students_details_list.txt");
            if (content1 != null)
            {

                string[] s1;
                lstUser = new List<sort>();
                for (int i = 0; i < content1.GetLength(0); i++)
                {
                    s1 = Regex.Split(content1[i], ",");
                    //need some validation
                    if (s1 != null && s1.GetLength(0) > 1)
                    {
                        sort obj = new sort();
                        obj.Name = s1[0];
                        int.TryParse(s1[1], out obj.std);
                        lstUser.Add(obj);
                    }
                }
                Console.WriteLine("Sorting based on names:");
                Console.WriteLine("---------------------------------------");

                foreach (var i in lstUser.OrderBy(o => o.Name).ToList())
                {
                    Console.WriteLine("Name:" + i.Name + " ->Class:" + i.std);
                }
                // return lstUser.OrderBy(o => o.Name).ToList();

                Console.WriteLine("---------------------------------------");

            }
            else
            {
                Console.WriteLine("Empty!!");
            }
            return null;


        }
        public static void search()
        {
            var content = File.ReadAllLines("G:\\C#\\students_details_list.txt");

            Console.WriteLine("Enter the word to search:");
            Console.WriteLine("---------------------------------------");

            string f = Console.ReadLine();

            foreach (string line in content)
            {
                if (line.Contains(f))
                {

                    Console.WriteLine(line);
                    Console.WriteLine("Found !!");

                }

            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Search Using Stream Reader class : ");

            using (var sr = new StreamReader("G:\\C#\\students_details_list.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (String.IsNullOrEmpty(line)) continue;
                    if (line.IndexOf(f, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);
                        Console.WriteLine("Found !!");
                        Console.WriteLine("---------------------------------------");

                    }

                }
                //Console.WriteLine("Not found..");
            }


        }

        static void Main(string[] args)
        {
            var content = File.ReadAllLines("G:\\C#\\students_details_list.txt");
            char ch;


            Console.WriteLine("Contents in file:");
            Console.WriteLine("---------------------------------------");
            foreach (string line in content)
            {

                Console.WriteLine(line);
            }

            Console.WriteLine("---------------------------------------");
            do
            {
                Console.WriteLine("Enter your choice: \n 1.sort \n 2.search");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        sort s = new sort();

                        s.ReadUserFile();
                        break;
                    case 2:
                        search();
                        break;
                }
                Console.WriteLine("Do u want to continue press y or Y:");
                ch = Convert.ToChar(Console.ReadLine());

            } while (ch == 'Y' || ch == 'y');







            Console.ReadLine();

        }
    }
}
