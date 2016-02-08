using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
    public class Bus : IPrettyShowable
    {
        // Number of seatі
        public int Numbers { get; set; }
        //Fuel consumption per 100 km
        public decimal Consumption { get; set; }
        public Bus()
            : this(0, 0)
        {
        }
        public Bus(int num, decimal consumption)
        {
            Numbers = num;
            Consumption = consumption;
        }
        //Output in table
        private string Line()
        {
            return "+--------------------------------------+---------------------------------------+";
        }
        void IPrettyShowable.ShowHeader()
        {
            const string title = "Автобуси";
            Console.WriteLine("\n{0," + (Console.WindowWidth + title.Length) / 2 + "}\n", title);
            Console.Write(Line());
        }

        public string ToString(bool pretty)
        {
            if (pretty)
                return String.Format("| Кiлькiсть мiсть: {0,18}  | Витрата палива : {1, 20} |", Numbers, Consumption) + Line();
            else
                return String.Format("{{Мiсць: {0} витрат.100км: {1} }}", Numbers, Consumption);
        }
        public override string ToString()
        {
            return ToString(false);
        }
    }
}
