using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
    public class Application : IPrettyShowable
    {
        //  length of the route
        private decimal longs;
        // cost of tickets
        private double cost;
        //destination
        public string Destination { get; private set; }
        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Uncorrect");
                }
                else
                {
                    cost = value;
                }
            }
        }
        public decimal Long
        {
            get
            {
                return longs;
            }
            set
            {
                if (value < 0)
                {
                    throw new LessthennullExeception("Значення менше нуля");
                }
                else
                {
                    longs = value;
                }
            }
        }

        public Application(decimal longs, double cost, string distans)
        {
            Long = longs;
            Cost = cost;
            Destination = distans;
        }
        public override string ToString()
        {
            return ToString(false);
        }
        // for seach
        public static string AppDestination(Application o)
        {
            return o.Destination;
        }
        public static double AppCost(Application o)
        {
            return o.Cost;
        }
        // for statistic
        public static decimal AppLong(Application o)
        {

            return o.Long;
        }
        //Output
        private string Line()
        {
            return "+----------------------------+------------------------+------------------------+";
        }

        public void ShowHeader()
        {
            const string title = "Заявка";
            Console.WriteLine("\n{0," + (Console.WindowWidth + title.Length) / 2 + "}\n", title);
            Console.Write(Line());
            Console.Write("|   Пункт призначення        | Протяжнiсть маршруту   |    Вартiсть квитка     |");
            Console.Write(Line());
        }

        public string ToString(bool pretty)
        {
            if (pretty)
                return String.Format("| {0,25}  | {1,22} | {2,22} |", Destination, Long, Cost) + Line();
            return String.Format("{{Пункт призначення: {0} Протяжнiсть маршруту: {1} Цiна: {2} }}", Destination, Long, Cost);
        }
    }
}
