using System;
using System.Collections.Generic;

namespace roulette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Table();   
        }

}

    public class Table
    {
        private string Name;
        public double Money;
        private Dictionary<int, int> Magida = new Dictionary<int, int>();
        private List<List<double>> Bets;
        private List<string> madeBets;
        public Table()
        {
            this.Bets = new List<List<double>>();
            this.madeBets = new List<string>();
            FillTable();
            Registrer();
        }
        private void FillTable()
        {

            for (int i = 1; i <= 36; i++)
            {

                if (i <= 10)
                {
                    if (i % 2 == 0)
                    {
                        Magida.Add(i, (int)Colors.Red);
                    }
                    else
                    {
                        Magida.Add(i, (int)Colors.Black);
                    }
                }
                else if (i <= 19)
                {
                    if (i % 2 == 0)
                    {
                        Magida.Add(i, (int)Colors.Black);
                    }
                    else
                    {
                        Magida.Add(i, (int)Colors.Red);
                    }
                }
                else if (i <= 28)
                {
                    if (i % 2 == 0)
                    {
                        Magida.Add(i, (int)Colors.Red);
                    }
                    else
                    {
                        Magida.Add(i, (int)Colors.Black);
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        Magida.Add(i, (int)Colors.Black);
                    }
                    else
                    {
                        Magida.Add(i, (int)Colors.Red);
                    }
                }
            }
        }
        private void Registrer()
        {
            Console.WriteLine("gamarjobat gtxovt sheiyvanot saxeli");
            this.Name = Console.ReadLine();
            Console.WriteLine("gtxovt sheiyvanot sasurveli tanxa (1000 ze naklebi)");
            Double Fuli;
            while (true)
            {
                var ricxvi = Console.ReadLine();
                if (Double.TryParse(ricxvi, out var ricxvi2))
                {
                    if (ricxvi2 > 0 && ricxvi2 <= 1000)
                    {
                        Fuli = ricxvi2;
                        break;
                    }
                }
                Console.WriteLine("gtxovt sheiyvanot scorad");

            }
            this.Money = Fuli;
            GameMenu();
        }

        private void GameMenu()
        {
            MenuPrint();
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
            if (archevani == 1)
            {
                startGame();
            }
            else if (archevani == 2)
            {
                Console.WriteLine($"tqveni tanxa {this.Money}");
                GameMenu();
            }
            else
            {
                Console.WriteLine("kargad brdzandebodet");
            }
        }
        private void startGame()
        {
            while(true)
            {
                Console.WriteLine("daicket  tamashi an dabrundit meniushi  \n 1 - dackeba \n 2 - meniushi dabruneba");
                int choice;
                while (true)
                {
                    var input3 = Console.ReadLine();
                    if (int.TryParse(input3, out var ricxvi2))
                    {
                        if (ricxvi2 > 0 && ricxvi2 <= 2)
                        {
                            choice = ricxvi2;
                            break;
                        }
                    }
                    Console.WriteLine($"gtxovt sheiyvanot scorad (1 an 2 )");

                }
                if (choice == 1)
                {
                    if (this.Money > 0)
                    {
                        MakeBets();
                    }
                    else
                    {
                        Console.WriteLine("tqven argaqvt fuli satamashod");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            GameMenu();
        }
        private void MakeBets()
        {
            Bets.Clear();
            madeBets.Clear();
            List<double> Bet = new List<double>();
            while (true)
            {
                Console.WriteLine("dadet fsoni ricxvze an ferze, an gaagrdzelet  (1- ricxvi , 2 feri ,3 gagrdzeleba (tu dadebuli gaqvt)");
                int choiceOfbet;
                while (true)
                {
                    var input = Console.ReadLine();
                    if (int.TryParse(input, out var ricxvi2))
                    {
                        if (ricxvi2 > 0 && ricxvi2 <= 3)
                        {   
                            choiceOfbet = ricxvi2;
                            break;
                        }
                    }
                    Console.WriteLine($"gtxovt sheiyvanot scorad (tu argaqvt dadebuli jer dadet)");

                }
                Bet.Add(choiceOfbet);
                if (choiceOfbet == 1)
                {
                    Bet.Add(ChooseNumber());
                }
                else if (choiceOfbet == 2)
                {
                    if (madeBets.Contains(Colors.Red.ToString()) && madeBets.Contains(Colors.Black.ToString()))
                    {
                        Console.WriteLine("orive feri ukve archeuli gaqvt");
                        continue;
                    }
                    else
                    {
                        Bet.Add(ChooseColor());
                    }

                }
                else
                {
                    if (Bets.Count>0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("argaqvt jer gaketebuli fsoni");
                        continue;
                    }
                }
                Bet.Add(ChooseBetMoney());
                Bets.Add(Bet);
                int gagrdzeleba = ContinueToBet();
                if (gagrdzeleba != 1)
                    break;
            }
            (string carmateba, double tanxa) = CalculateWin();
            if (carmateba== "moiget")
            {
                Console.WriteLine($"tqven moiget {tanxa} lari, tqveni tanxaa {this.Money}");
            }
            else
            {
                Console.WriteLine($"tqven caaget {tanxa} lari, tqveni tanxaa {this.Money}");
            }

        }
        private int ChooseNumber()
        {
            Console.WriteLine($"aircie cifri dasadebad");

            int Number;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var ricxvi))
                {
                    if (ricxvi > 0 && ricxvi <= 36)
                    {
                        Number = ricxvi;
                        if (this.madeBets.Contains(Number.ToString()))
                        {
                            Console.WriteLine("es ricxvi ukve archeuli gaqvt");
                            continue;
                        }
                        this.madeBets.Add(Number.ToString());
                        break;
                    }
                }
                Console.WriteLine("gtxovt sheiyvanot scorad (1-36 mde)");
            }
            return Number;
        }
        private int ChooseColor()
        {
            int Feri;
            Console.WriteLine("airchiet feri (1-shavi , 2-witeli)");
            while (true)
            {
                var input5 = Console.ReadLine();
                if (int.TryParse(input5, out var ricxvi2))
                {
                    if (ricxvi2 > 0 && ricxvi2 <= 2)
                    {
                        Feri = ricxvi2;
                        if (this.madeBets.Contains(((Colors)Feri).ToString()))
                        {
                            Console.WriteLine("es feri ukve archeuli gaqvt");
                            continue;
                        }
                        madeBets.Add(((Colors)Feri).ToString());
                        break;
                    }
                }
                Console.WriteLine($"gtxovt sheiyvanot scorad)");

            }
            return Feri;
        }
        private double ChooseBetMoney()
        {
            Console.WriteLine($"gtxovt sheiyvanet sasurveli tanxa dasadebad arsebulidan {this.Money} (max bet 60)");
            double tanxa;
            while (true)
            {
                var input2 = Console.ReadLine();
                if (double.TryParse(input2, out var ricxvi2))
                {
                    if (ricxvi2 > 0 && ricxvi2 <= this.Money && ricxvi2 <= 60)
                    {
                        tanxa = ricxvi2;
                        Game.Bet(this, tanxa);
                        break;
                    }
                }
                Console.WriteLine($"gtxovt sheiyvanot arsebulidan scorad (arsebuli {this.Money} da 60 ze naklebi)");

            }
            return tanxa;
        }
        private void MenuPrint()
        {
            Console.WriteLine("gamarjobat tqveni archevania sheyvanisas \n 1 - tamashis dackeba  \n 2 - amjamindeli tanxis naxva \n 3 - tamashidan gamosvla");
        }
        private int ContinueToBet()
        {
            Console.WriteLine("gindat tuara kidev fsonis dadeba? (1-ki, 2-ara)");
            int choiceOfbet;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var ricxvi2))
                {
                    if (ricxvi2 > 0 && ricxvi2 <= 2)
                    {
                        choiceOfbet = ricxvi2;
                        break;
                    }
                }
                Console.WriteLine($"gtxovt sheiyvanot scorad)");
            }
            return choiceOfbet;
        }
        private (string,double) CalculateWin()
        {
            double mogebuli = 0;
            double dadebuli = 0;
            foreach (List<double> i in this.Bets)
            {
                int Shedegi = Game.GetRandomNumber();
                if (i[1] == 1)
                {
                    dadebuli += i[2];
                    //var ans = (Colors)Convert.ToInt64(i[1]);
                    if (Magida[Convert.ToInt32(i[1])]==Magida[Shedegi])
                    {
                        
                       mogebuli+=Game.WinByColor(this,i[2]);
                    }
                }
                else
                {
                    dadebuli += i[2];
                    if (Shedegi==i[1])
                    {
                        
                        mogebuli += Game.WinByNumber(this,i[2]);
                    }
                }
            }
            if (mogebuli>dadebuli)
            {
                return ("moiget",mogebuli);
            }
            else
            {
                return ("caaget", dadebuli-mogebuli);
            }
        }
    }
    public enum Colors:int
        {
            Black=1,
            Red=2,
        }

    public static class Game
    {


        static public int GetRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1,36);
        }
        public static double WinByNumber(Table person, double number)
        {
            person.Money += number * 2;
            return number * 2;
        }
        public static double WinByColor(Table person, double number)
        {
            person.Money +=number+ number * 20 / 100;
            return number + number * 1 / 5;
        }
        public static void Bet(Table person, double bet)
        {
            person.Money -= bet;
        }
    }

}
