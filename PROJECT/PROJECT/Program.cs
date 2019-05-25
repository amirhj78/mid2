using System;
using System.IO;

namespace PROJECT
{


   static class Program
    {
        //Drive::::::::::
        public static string Direction = @"E:\";
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("\n \n HINTS: \n For creating record:press 1 ");
                Console.WriteLine("HINTS: Get marry : press 2 ");
                Console.WriteLine("HINTS: child : press 3 ");
                Console.WriteLine("HINTS: get devorced : press 4 ");
                Console.WriteLine("HINTS: death : press 5 ");
                Console.WriteLine("HINTS: Showing people`s information : press 6 ");
                Console.WriteLine("HINTS: exit program : press 0 ");
                Console.WriteLine("enter command::::");
                string press = Console.ReadLine();
                if (press == "1")
                {
                    human a = new human();
                    a.Sethuman();
                }
                else if (press == "2")
                {
                    methods a = new methods();
                    a.marry();

                }
                else if (press == "3")
                {
                    methods a = new methods();
                    a.child();

                }
                else if (press == "4")
                {
                    methods a = new methods();
                    a.divorce();

                }
                else if (press == "5")
                {
                    methods a = new methods();
                    a.death();

                }
                else if (press == "6")
                {
                    methods a = new methods();
                    a.ShowINF();

                }

                else if (press == "0") break;

            }
        }
    }
}
