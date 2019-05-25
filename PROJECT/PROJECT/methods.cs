using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PROJECT
{
    class methods
    {

        public void Saveobject(human y)
        {
            using (StreamWriter sw = File.CreateText(y.path))
            {
                sw.WriteLine(y.Id.ToString()); //1
                sw.WriteLine(y.FirstName);//2
                sw.WriteLine(y.LastName);//3
                sw.WriteLine(y.Gender);//4
                sw.WriteLine(y.FatherName);//5
                sw.WriteLine(y.weedingStatus.ToString());//6
                sw.WriteLine(y.WeedingId.ToString());//7
                sw.WriteLine(y.alive.ToString());//8
                sw.WriteLine(y.YearOfBirth.ToString());//9
                sw.WriteLine(y.MonthOfbirth);//10
                sw.WriteLine(y.DayOfbirth);//11
                sw.WriteLine(y.SpouseFullname);//12
                sw.WriteLine(y.Nationality);//13
                sw.WriteLine(y.path);//14
                sw.WriteLine(y.childrenNames);//15
                sw.WriteLine(y.NumberChil.ToString());//16
                sw.WriteLine(y.FatherSID.ToString());//17
                sw.WriteLine(y.MotherSID.ToString());//18
                sw.WriteLine(y.status);//19
                sw.WriteLine(y.spouseSID.ToString());//20


            }
        }
        public human Loadobject(string path3)
        {
            using (StreamReader sr = File.OpenText(path3))
            {
                human o = new human();
                o.Id = int.Parse(sr.ReadLine());
                o.FirstName = sr.ReadLine();
                o.LastName = sr.ReadLine();
                o.Gender = sr.ReadLine();
                o.FatherName = sr.ReadLine();
                o.weedingStatus = Convert.ToBoolean(sr.ReadLine());//6
                o.WeedingId = int.Parse(sr.ReadLine());
                o.alive = Convert.ToBoolean(sr.ReadLine());//8
                o.YearOfBirth = int.Parse(sr.ReadLine());//9
                o.MonthOfbirth = sr.ReadLine();
                o.DayOfbirth = sr.ReadLine();//11
                o.SpouseFullname = sr.ReadLine();
                o.Nationality = sr.ReadLine();
                o.path = sr.ReadLine();
                o.childrenNames = sr.ReadLine();
                o.NumberChil = int.Parse(sr.ReadLine());
                o.FatherSID = int.Parse(sr.ReadLine());
                o.MotherSID = int.Parse(sr.ReadLine());
                o.status = sr.ReadLine();
                o.spouseSID = int.Parse(sr.ReadLine());//20
                o.DateOfbirth = o.YearOfBirth + "\\" + o.MonthOfbirth + "\\" + o.DayOfbirth;
                return o;


            }
        }
        public void marry()
        {
            string id1, id2;
            human p = new human();
            human q = new human();
            for (; ; )
            {
                Console.WriteLine("enter National Code 1:");
                id1 = Console.ReadLine();
                string path1 = Program.Direction + id1 + ".txt";
                if (!File.Exists(path1))
                {
                    Console.WriteLine("This National Code  " + id1 + " is not defined.");
                    break;
                }
                Console.WriteLine("enter National Code 2:");
                id2 = Console.ReadLine();
                string path2 = Program.Direction + id2 + ".txt";
                if (!File.Exists(path2))
                {
                    Console.WriteLine("This National Code  " + id2 + " is not defined.");
                    break;
                }
                p = Loadobject(path1);
                q = Loadobject(path2);
                if (p.Id == q.Id)
                {
                    Console.WriteLine(" ids are same,try again");
                    continue;
                }
                else if (!p.alive)
                {
                    Console.WriteLine(p.FirstName + "" + p.LastName + "is dead ");
                    break;
                }
                else if (!q.alive)
                {
                    Console.WriteLine(q.FirstName + " " + q.LastName + "is dead ");
                    break;
                }
                else if (p.Gender == q.Gender)
                {
                    Console.WriteLine(" According to the rules couldn`t be married .");
                    break;
                }
                else if (p.weedingStatus)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName + "has married before "); break;
                }
                else if (q.weedingStatus)
                {
                    Console.WriteLine(q.FirstName + " " + q.LastName + "has married before "); break;
                }
                else if (1398 - p.YearOfBirth <= 15)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName + " not legal to marry!!"); break;
                }
                else if (1398 - q.YearOfBirth <= 15)
                {
                    Console.WriteLine(q.FirstName + " " + q.LastName + " not legal to marry!!"); break;
                }
                else if (p.FatherSID == q.FatherSID)
                {
                    Console.WriteLine("Not valid!!"); break;
                }
                else if (p.MotherSID == q.MotherSID)
                {
                    Console.WriteLine("Not valid!!"); break;
                }
                else
                {

                    p.weedingStatus = true;
                    q.weedingStatus = true;
                    p.SpouseFullname = q.FirstName + " " + q.LastName;
                    p.spouseSID = q.Id;
                    q.SpouseFullname = p.FirstName + " " + p.LastName;
                    q.spouseSID = p.Id;
                    Saveobject(p);
                    Saveobject(q);
                    Console.Write(p.FirstName + " " + p.LastName + "and" + q.FirstName + " " + q.LastName + "  sucecssfully mariied.\n");
                    break;
                }

            }
        }
        public void child()
        {
            string id1, id2;
            human p = new human();
            human q = new human();
            for (; ; )
            {
                Console.WriteLine("enter parent`s National Code:");
                Console.WriteLine("National Code 1:");
                id1 = Console.ReadLine();
                string path1 = Program.Direction + id1 + ".txt";
                if (!File.Exists(path1))
                {
                    Console.WriteLine("This national code  " + id1 + " is not defined.");
                    break;
                }
                Console.WriteLine("National Code 2:");
                id2 = Console.ReadLine();
                string path2 = Program.Direction + id2 + ".txt";
                if (!File.Exists(path2))
                {
                    Console.WriteLine("This national code  " + id2 + " is not defined.");
                    break;
                }
                p = Loadobject(path1);
                q = Loadobject(path2);
                if (p.Id == q.Id)
                {
                    Console.WriteLine(" ids are same,try again");
                    continue;
                }

                if (p.weedingStatus == false)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName + "hasn`t married  ");
                    break;
                }
                else if (q.weedingStatus == false)
                {
                    Console.WriteLine(q.FirstName + " " + q.LastName + "hasn`t married  ");
                    break;
                }
                else if (p.spouseSID != q.Id)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName + "and" + q.FirstName + " " + q.LastName + "  han`t married to each other!!!");
                    break;
                }
                else
                {

                    human j = new human();
                    Console.WriteLine("enter child`s infomartaion:");
                    for (; ; )
                    {
                        Console.WriteLine("enter National code");
                        j.Id = int.Parse(Console.ReadLine());
                        j.path = Program.Direction + j.Id.ToString() + ".txt";
                        if (File.Exists(j.path))
                        {
                            Console.WriteLine("this national code  exists,try another");
                            continue;
                        }
                        else break;
                    }
                    Console.WriteLine("enter FirstName");
                    j.FirstName = Console.ReadLine();
                    for (; ; )
                    {
                        Console.WriteLine("enter Gender:male or female ");
                        j.Gender = Console.ReadLine();
                        if (j.Gender == "male") break;
                        if (j.Gender == "female") break;
                        else continue;
                    }
                    if (p.Gender == "male")
                    {
                        j.FatherName = p.FirstName;
                        j.FatherSID = p.Id;
                        j.LastName = p.LastName;
                        j.MotherSID = q.Id;
                    }
                    else
                    {
                        j.FatherName = q.FirstName;
                        j.FatherSID = q.Id;
                        j.LastName = q.LastName;
                        j.MotherSID = p.Id;
                    }

                    Console.WriteLine("enter the date of birth");
                    Console.WriteLine("enter the year:example 1398");
                    j.YearOfBirth = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter the month");
                    j.MonthOfbirth = Console.ReadLine();
                    Console.WriteLine("enter the day");
                    j.DayOfbirth = Console.ReadLine();
                    Console.WriteLine("enter nationality");
                    j.Nationality = Console.ReadLine();
                    Console.WriteLine(j.FirstName + "" + j.LastName + " defined.");
                    p.childrenNames += "*" + j.FirstName + "" + j.LastName;
                    q.childrenNames += "*" + j.FirstName + "" + j.LastName;
                    p.NumberChil++;
                    q.NumberChil++;
                    Saveobject(p); Saveobject(q); Saveobject(j); break;
                }

            }

        }
        public void divorce()
        {
            string id1, id2;
            human p = new human();
            human q = new human();
            for (; ; )
            {
                Console.WriteLine("enter National Code 1:");
                id1 = Console.ReadLine();
                string path1 = Program.Direction + id1 + ".txt";
                if (!File.Exists(path1))
                {
                    Console.WriteLine("This National Code  " + id1 + " is not defined.");
                    break;
                }
                Console.WriteLine("enter National Code 2:");
                id2 = Console.ReadLine();
                string path2 = Program.Direction + id2 + ".txt";
                if (!File.Exists(path2))
                {
                    Console.WriteLine("This National Code  " + id2 + " is not defined.");
                    break;
                }
                p = Loadobject(path1);
                q = Loadobject(path2);
                if (p.Id == q.Id)
                {
                    Console.WriteLine(" ids are same,try again");
                    continue;
                }
                if (p.weedingStatus == false)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName + "hasn`t married  ");
                    break;
                }
                else if (q.weedingStatus == false)
                {
                    Console.WriteLine(q.FirstName + " " + q.LastName + "hasn`t married  ");
                    break;
                }
                else if (p.spouseSID != q.Id)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName + "and" + q.FirstName + " " + q.LastName + "  han`t married to each other!!!");
                    break;
                }
                else
                {
                    p.spouseSID = 0;
                    q.spouseSID = 0;
                    p.weedingStatus = false;
                    q.weedingStatus = false;
                    p.SpouseFullname = "";
                    q.SpouseFullname = "";
                    p.status += " *get divorced from " + q.FirstName + "" + q.LastName + " Spouce`sNational code: " + q.Id;
                    q.status += " *get divorced from " + p.FirstName + "" + p.LastName + " Spouce`sNational code: " + p.Id;
                    Saveobject(p);
                    Saveobject(q);
                    Console.Write(p.FirstName + " " + p.LastName + "and" + q.FirstName + " " + q.LastName + "  sucecssfully get divorced.\n");                    
                    break;
                }
            }
        }
        public void death()
        {
            string id1;
            human p = new human();
            for (; ; )
            {
                Console.WriteLine("enter National Code :");
                id1 = Console.ReadLine();
                string path1 = Program.Direction+id1+".txt";
                if (!File.Exists(path1))
                {
                    Console.WriteLine("This National Code  " + id1 + " is not defined.");
                    break;
                }
                p = Loadobject(path1);
                if (p.alive == false)
                {
                    Console.WriteLine("This person has dead before");
                    break;
                }
                else if (p.weedingStatus == true)
                {
                    human q = new human();
                    string path2 = Program.Direction + p.spouseSID + ".txt";
                    q = Loadobject(path2);
                    q.spouseSID = 0;
                    q.weedingStatus = false;
                    q.SpouseFullname = "";
                    q.status += " *spouse :" + p.FirstName + "" + p.LastName + " National code: " + p.Id.ToString() + "  was dead \t";
                    p.alive = false;
                    p.status += "\t *" + p.FirstName + "" + p.LastName + "  National code:" + p.Id.ToString() + " dead";
                    Console.WriteLine("*" + p.FirstName + "" + p.LastName + "  National code: " + p.Id.ToString() + " dead");
                    Saveobject(q);
                    Saveobject(p);

                    break;
                }
                else
                {

                    p.alive = false;
                    p.status += "\t *" + p.FirstName + "" + p.LastName + "  National code: " + p.Id.ToString() + " dead";
                    Saveobject(p);
                    Console.WriteLine("done*" + p.FirstName + "" + p.LastName + " National code: " + p.Id.ToString() + " dead");
                    break;
                }
            }
        }
        public void ShowINF()
        {
            string id1, path1;
            human p = new human();
            for (; ; )
            {
                Console.WriteLine("enter National Code :");
                id1 = Console.ReadLine();
                path1 = Program.Direction + id1 + ".txt";
                if (!File.Exists(path1))
                {
                    Console.WriteLine("This National Code  " + id1 + " is not defined.");
                    break;
                }
                else
                {
                    p = Loadobject(path1);
                    string W;
                    if (p.weedingStatus == true) W = "*Married* " + p.SpouseFullname + " " + p.spouseSID.ToString();
                    else W = "single";
                    Console.WriteLine("*National code: " + p.Id.ToString() + " *Full name:" + p.FirstName + " " + p.LastName + "  Gender: " + p.Gender + " *Nationality " + p.Nationality);
                    Console.WriteLine("parant`s information: Fathe`s Name: " + p.FatherName + " *National code: " + p.FatherSID.ToString() + "  Mother`s National code: " + p.MotherSID.ToString());
                    Console.WriteLine("Date of Birth:" + p.DateOfbirth + " *" + W);
                    Console.WriteLine("children`s name: " + p.childrenNames + " " + " number of children: "+p.NumberChil.ToString());
                    Console.WriteLine(p.status);
                    break;
                }
            }
        }
    }

}
