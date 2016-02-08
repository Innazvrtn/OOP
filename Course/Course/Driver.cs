using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
    public class Driver : Person, IPrettyShowable
    {
        //salary driver
        public decimal Wages { get; set; }
        public Driver()
            : base()
        {
        }
        public Driver(string name, string surname, int year, int month, int day, decimal wages)
            : base(name, surname, year, month, day)
        {
            Wages = wages;
        }
        // Output
        private string Line()
        {
            return "+--------------------------+------------------+-------------------+------------+";
        }
        void IPrettyShowable.ShowHeader()
        {
            const string title = "Водiї";
            Console.WriteLine("\n{0," + (Console.WindowWidth + title.Length) / 2 + "}\n", title);
            Console.Write(Line());
            Console.Write("|          Прiзвище        |      Iм’я        | Дата народження   | Оклад      |");
            Console.Write(Line());
        }
        public string ToString(bool pretty)
        {
            if (pretty)
                return String.Format("| {0,24} | {1, 16} | {2,17} |  {3,10}|", base.SurName, base.Name, base.date.ToString(true), Wages) + Line();
            return String.Format("{{Iм’я: {0} Прiзвище: {1} Дата народження {2} Оклад: {3} }}", base.Name, base.SurName, base.date.ToString(true), Wages);
        }
        // for abstract class
        public override string ToString()
        {
            return ToString(false);
        }

    }
}
