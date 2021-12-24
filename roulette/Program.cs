using System;
using System.Collections.Generic;

namespace roulette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game.CreateSelf();
            Console.WriteLine("gamarjobat gtxovt sheiyvanot saxeli");
            String Name=Console.ReadLine();
            Console.WriteLine("gtxovt sheiyvanot sasurveli tanxa (1000 ze naklebi)");
            Double Fuli;
            while (true)
            {
                var ricxvi = Console.ReadLine();
                if (Double.TryParse(ricxvi, out var ricxvi2))
                {
                    if (ricxvi2>0 &&ricxvi2<=1000)
                    {
                    Fuli= ricxvi2;
                    break;
                    }
                }
                Console.WriteLine("გთხოვთ შეიყვანოთ სწორად");

            }
            Person person = new Person(Name,Fuli);
            GameMenu(person);
        }
        static void GameMenu(Person person)
        {
            Becdva();
            int archevani;
            while (true)
            {
                var ricxvi = Console.ReadLine();
                if (int.TryParse(ricxvi, out var ricxvi2))
                {
                    if (ricxvi2 > 0 && ricxvi2 <= 3)
                    {
                        archevani = ricxvi2;
                        break;
                    }
                }
                Console.WriteLine("gtxovt sheiyvanot cifri 1 dan samamde");

            }
            if (archevani==1)
            {
                startGame(person);
            }
            else if (archevani==2)
            {
                Console.WriteLine($"tqveni tanxa {person.Money}");
                GameMenu(person);
            }
            else
            {
                Console.WriteLine("kargad brdzandebodet");
            }
        }


        static void startGame(Person person)
        {   
            Console.WriteLine("raze gindat dadeba ferze tu rivxvze (1- ricxvi , 2 feri)");
            int choiceOfbet;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var ricxvi2))
                {
                    if (ricxvi2 > 0 && ricxvi2 <=2)
                    {
                        choiceOfbet = ricxvi2;
                        break;
                    }
                }
                Console.WriteLine($"gtxovt sheiyvanot scorad)");

            }
            int Number = -1;
            int Feri = -1;
            if (choiceOfbet==1)
            {
                Number = NumberBet(person);
            }
            else
            {
                Console.WriteLine("airchiet feri (1-shavi , 2-witeli)");
                while (true)
                {
                    var input5 = Console.ReadLine();
                    if (int.TryParse(input5, out var ricxvi2))
                    {
                        if (ricxvi2 > 0 && ricxvi2 <= 2)
                        {
                            Feri = ricxvi2;
                            break;
                        }
                    }
                    Console.WriteLine($"gtxovt sheiyvanot scorad)");

                }
            }
           
            Console.WriteLine($"gtxovt sheiyvanet sasurveli tanxa arsebulidan {person.Money}");
            double tanxa;
            while (true)
            {
                var input2 = Console.ReadLine();
                if (double.TryParse(input2, out var ricxvi2))
                {
                    if (ricxvi2 > 0  &&  ricxvi2 <= person.Money && ricxvi2<=60)
                    {
                        tanxa = ricxvi2;
                        Game.Bet(person,tanxa);
                        break;
                    }
                }
                Console.WriteLine($"gtxovt sheiyvanot arsebulidan scorad (arsebuli {person.Money} da 60 ze naklebi)");

            }
            int shedegi = Game.GetRandomNumber();
            Console.WriteLine($"gacherda {shedegi}");
            if (Number!=-1)
            {
            if (shedegi==Number)
            {
                Game.WinByColor(person, tanxa);   
                Console.WriteLine($"tqven moiget , gagiormagdat tanxa , tqveni tanxaa {person.Money}");
            }
            else
                {
                    Console.WriteLine($"tqven caaget tqveni tanxaa {person.Money}");
                }
            }
            else
            {
                if (Feri==1)
                {
                    if (Game.Black.Contains(shedegi))
                    {
                        Game.WinByColor(person, tanxa);
                        Console.WriteLine($"tqven daamtxviet feri tqveni tanxaa {person.Money}");
                    }
                     else
                {
                    Console.WriteLine($"tqven caaget tqveni tanxaa {person.Money}");
                }
                }
                else
                {
                    if (Game.Red.Contains(shedegi))
                    {
                        Game.WinByColor(person, tanxa);
                        Console.WriteLine($"tqven daamtxviet feri tqveni tanxaa {person.Money}");
                    }
                    else
                    {
                        Console.WriteLine($"tqven caaget tqveni tanxaa {person.Money}");
                    }
                }
            }
           
            

            Console.WriteLine("kidev gsurt tu gindat meniushi dabruneba \n 1 - kidev \n 2 - meniushi dabruneba");
            int choice;
            while (true)
            {
                var input3 = Console.ReadLine();
                if (int.TryParse(input3, out var ricxvi2))
                {
                    if (ricxvi2 > 0 && ricxvi2 <=2)
                    {
                        choice = ricxvi2;
                        break;
                    }
                }
                Console.WriteLine($"gtxovt sheiyvanot scorad (1 an 2 )");

            }
            if (choice==1)
            {
                if (person.Money>0)
                {
                    startGame(person);
                }
                else
                {
                    Console.WriteLine("tqven argaqvt fuli satamashod");
                }
            }
            else
            {
                GameMenu(person);
            }
        }
        static int  NumberBet(Person person)
        {
        Console.WriteLine($"{person.Name} aircie cifri dasadebad");
            
                    int  Number;
                    while (true)
                    {
                        var input=Console.ReadLine();
                        if (int.TryParse(input, out var ricxvi2))
                        {
                            if (ricxvi2 > 0 && ricxvi2 <= 1000)
                            {
                                Number = ricxvi2;
                                break;
                            }
                        }
                        Console.WriteLine("gtxovt sheiyvanot scorad (1-36 mde)");

                    }
                    return Number;
        }
        static void Becdva()
        {
            Console.WriteLine("gamarjobat tqveni archevania sheyvanisas \n 1 - tamashis dackeba  \n 2 - amjamindeli tanxis naxva \n 3 - tamashidan gamosvla");
        }

}
    public class Person
    { 
        public string Name { get; set; }
        public double Money { get; set; }

        public Person(string Name,double money)
        {
            this.Name = Name;
            this.Money = money;
        }
        public Person()
        {

        }
    }
    public class Table
    {
        private double Money;
        public static Dictionary<int,int> Magida = new Dictionary<int,int>();
        public Table(double money)
        {
            this.Money = money;
            FillTable();
        }
        private static void FillTable()
        {

            for (int i = 1; i <= 36; i++)
            {

                if (i <= 10)
                {
                    if (i % 2 == 0)
                    {
                        Game.Red.Add(i);
                        Magida.Add(i, (int)Colors.Red);
                    }
                    else
                    {
                        Game.Black.Add(i);
                        Magida.Add(i, (int)Colors.Black);
                    }
                }
                else if (i <= 19)
                {
                    if (i % 2 == 0)
                    {
                        Game.Black.Add(i);
                        Magida.Add(i, (int)Colors.Black);
                    }
                    else
                    {
                        Game.Red.Add(i);
                        Magida.Add(i, (int)Colors.Red);
                    }
                }
                else if (i <= 28)
                {
                    if (i % 2 == 0)
                    {
                        Game.Red.Add(i);
                        Magida.Add(i, (int)Colors.Red);
                    }
                    else
                    {
                        Game.Black.Add(i);
                        Magida.Add(i, (int)Colors.Black);
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        Game.Black.Add(i);
                        Magida.Add(i, (int)Colors.Black);
                    }
                    else
                    {
                        Game.Red.Add(i);
                        Magida.Add(i, (int)Colors.Red);
                    }
                }
                }
            }
        }
    public enum Colors
        {
            Black=1,
            Red=2,
        }

    public static class Game
    {
        public static  List<int> Table { get; set; }
        public static List<int> Red { get; set; }
        public static List<int> Black { get; set; }


        static public int GetRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1,36);
        }
        static public void CreateSelf()
        {
                    Game.Table = new List<int>();
                    Game.Black = new List<int>();
                    Game.Red = new List<int>();
                    for (int i=1;i<=36;i++)
                    {
                        Game.Table.Add(i);
                        if (i<=10)
                        {
                            if (i%2==0)
                            {
                                Game.Red.Add(i);
                            }
                            else
                            {
                                Game.Black.Add(i);
                            }
                        }
                        else if (i<=19)
                        {
                            if (i % 2 == 0)
                            {
                                Game.Black.Add(i);
                            }
                            else
                            {
                                Game.Red.Add(i);
                            }
                        }
                        else if (i<=28)
                        {
                            if (i % 2 == 0)
                            {
                                Game.Red.Add(i);
                            }
                            else
                            {
                                Game.Black.Add(i);
                            }
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                Game.Black.Add(i);
                            }
                            else
                            {
                                Game.Red.Add(i);
                            }
                        }

                    }
        }
        public static void WinByNumber(Person person, double number)
        {
            person.Money += number * 2;
        }
        public static void WinByColor(Person person, double number)
        {
            person.Money +=number+ number * 20 / 100;
        }
        public static void Bet(Person person, double bet)
        {
            person.Money -= bet;
        }
    }

}
