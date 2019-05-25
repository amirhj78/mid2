using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PROJECT
{
    class human
    {
        public int Id;//1
        public String FirstName;//2
        public string LastName;//3
        public string FatherName;//4
        public bool weedingStatus = false;//5
        public bool alive = true;//6
        public int WeedingId = 0;//7
        public string Gender;//8
        public string SpouseFullname = "";//9
        public int YearOfBirth;//10
        public string MonthOfbirth;//11
        public string DayOfbirth;//12
        public string DateOfbirth = "";
        public string Nationality;//13
        public string path;//14
        public string childrenNames = "";//15
        public int NumberChil = 0;//16
        public int FatherSID;//17
        public int MotherSID;//18
        public string status = "";//19
        public int spouseSID = 0;//20
        public void Sethuman()
        {

            for (; ; )
            {
                Console.WriteLine("enter National Code");
                Id = int.Parse(Console.ReadLine());
                path = Program.Direction + Id.ToString() + ".txt";
                if (File.Exists(path)) { Console.WriteLine("this National Code exists,try another"); continue; }
                else break;
            }
            Console.WriteLine("enter FirstName");
            FirstName = Console.ReadLine();
            Console.WriteLine("enter Lastname");
            LastName = Console.ReadLine();
            for (; ; )
            {
                Console.WriteLine("enter Gender:male or female ");
                Gender = Console.ReadLine();
                if (Gender == "male") break;
                if (Gender == "female") break;
                else continue;
            }
            Console.WriteLine("enter Fathername");
            FatherName = Console.ReadLine();
            Console.WriteLine("enter Father`s National Code ");
            FatherSID = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Mother`s National Code ");
            MotherSID = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the date of birth:");
            Console.WriteLine("enter the year:example 1398");
            YearOfBirth = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the month:1 to 12");
            MonthOfbirth = Console.ReadLine();
            Console.WriteLine("enter the day:1 to 31");
            DayOfbirth = Console.ReadLine();
            Console.WriteLine("enter Nationality");
            Nationality = Console.ReadLine();
            Console.WriteLine(FirstName + "" + LastName + " defined. \n");
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(Id.ToString()); //1
                sw.WriteLine(FirstName);//2
                sw.WriteLine(LastName);//3
                sw.WriteLine(Gender);//4
                sw.WriteLine(FatherName);//5
                sw.WriteLine(weedingStatus.ToString());//6
                sw.WriteLine(WeedingId.ToString());//7
                sw.WriteLine(alive.ToString());//8
                sw.WriteLine(YearOfBirth.ToString());//9
                sw.WriteLine(MonthOfbirth);//10
                sw.WriteLine(DayOfbirth);//11
                sw.WriteLine(SpouseFullname);//12
                sw.WriteLine(Nationality);//13
                sw.WriteLine(path);//14
                sw.WriteLine(childrenNames);//15
                sw.WriteLine(NumberChil.ToString());//16
                sw.WriteLine(FatherSID.ToString());//17
                sw.WriteLine(MotherSID.ToString());//18
                sw.WriteLine(status);//19
                sw.WriteLine(spouseSID.ToString());//20
            }

        }

    }
}
