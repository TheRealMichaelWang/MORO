using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Moro
{
    class Program
    {
        static int hour = 0;
        static int minute = 0;
        static void SetTime()
        {
            try
            {
                Console.Write("When does your day end?>");
                string input = Console.ReadLine();
                string[] args = input.Split(':');
                string[] argsb = args[1].Split(' ');
                hour = int.Parse(args[0]);
                minute = int.Parse(argsb[0]);
                if (argsb[1] == "am")
                {

                }
                else if (argsb[1] == "pm")
                {
                    hour = hour + 12;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                SetTime();
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "MORO";
            Console.WriteLine("MORO\n(C) Michael Wang 2018-2019. Also availible for Constellation OS\n");
            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\moro.txt"))
            {
                string[] towrite = new string[2];
                SetTime();
                towrite[0] = hour.ToString();
                towrite[1] = minute.ToString();
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\moro.txt", towrite);
            }
            else
            {
                string[] toload = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\moro.txt");

                hour = int.Parse(toload[0]);
                minute = int.Parse(toload[1]);

                int totalmin = (hour * 60 + minute) - (DateTime.Now.Hour * 60 + DateTime.Now.Minute);
                if(totalmin<=0)
                {
                    Console.WriteLine("Congragulations\nYour work day is over!");
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\moro.txt");
                }
                else
                {
                    int hoursleft = totalmin / 60;
                    int minutesleft = totalmin % 60;
                    if(hoursleft==0)
                    {
                        if (totalmin != 1)
                        {
                            Console.WriteLine("You've got " + totalmin + " minutes left.");
                        }
                        else
                        {
                            Console.WriteLine("Hold in there! You've only got one minute left!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You've got " + hoursleft + " hours and " + minutesleft + " minutes left.");
                    }
                    Console.WriteLine("Check again soon");
                }
                Console.ReadKey();
            }
        }
    }
}
