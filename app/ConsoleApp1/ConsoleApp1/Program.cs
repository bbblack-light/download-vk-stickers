using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select menu item:\n" +
                                  "1. Download stickerpack\n" +
                                  "0. Exit.");
                string menuItem = Console.ReadLine();
                
                if (menuItem.Equals(""))
                {
                    Console.WriteLine("Select menu item");
                    Console.ReadLine();
                    continue;
                }

                int item = -1;
                if (!Int32.TryParse(menuItem, out item))
                {
                    Console.WriteLine("Incorrect value");
                    Console.ReadLine();
                    continue;
                }
                SelectMenu(item);
                
            }
            
        }

        private static void SelectMenu(int item)
        {
            switch (item)
            {
                case 1:
                    DownloadStickers();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void DownloadStickers()
        {
            Console.Clear();
            List<string> Images;
            string Linkes;
            string Path;
            
            Console.WriteLine("Enter copied links");
            Linkes = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter Path directory");
            Path = Console.ReadLine();
            Console.Clear();
            Path.Replace('\\', '/');
            Path += '/';

            Images = Linkes.Split(',').ToList();

            using (var client = new WebClient())
            {
                
                try
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i % 10 == 0)
                        {
                            Task.Delay(2000);
                        }

                        client.DownloadFile(Images[i], Path + (i+1) + ".png");
                        Console.Clear();
                        Console.WriteLine("Ready " + (i+1) + "/" + Images.Count);
                    }
                    Console.WriteLine("Ready");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ooops... " + e);
                    throw;
                }
                Console.WriteLine("Enter to continue");
                Console.ReadLine();
            }
        }
    }
}