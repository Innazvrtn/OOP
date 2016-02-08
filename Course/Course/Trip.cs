using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
    public class Trip : IPrettyShowable
    {
        // for pattern
        Program.Observer tripobser;
        public Driver Driver { get; private set; }
        public Bus Bus { get; private set; }
        public Date Dates { get; private set; }
        public int SoldTickets { get; private set; }
        //FuelAmount 
        public decimal FuelAmount { get; private set; }
        public Application Application { get; private set; }
        public Trip(Driver driver, Bus bus, Date date, int soldtickets, Application application)
        {
            Driver = driver;
            Bus = bus;
            Dates = date;
            SoldTickets = soldtickets;
            Application = application;
            FuelAmount = bus.Consumption / 100 * application.Long;
        }

        private string Line()
        {
            return "+-----------------------+----------+------------------------------+-----+------+";
        }

        public void ShowHeader()
        {
            const string title = "Рейси";
            Console.WriteLine("\n{0," + (Console.WindowWidth + title.Length) / 2 + "}\n", title);
            Console.Write(Line());
            Console.Write("|        Водiй          |   Дата   |            Автобус           |Палив|Квит. |");
            Console.Write(Line());
        }

        public string ToString(bool pretty)
        {
            if (pretty)
            {
                return String.Format("| {0,12} {1,9}|{2,10}| {3,29}|{4,5}|{5,6}|", Driver.SurName, Driver.Name, Dates.ToString(true), Bus, FuelAmount, SoldTickets) + Line();

            }

            return String.Format("{{Водiй: {0} Дата: {1} Автобус: {2} Витрати пального: {3} Кiлькiсть проданих квиткiв {4} Заявка {5} }}", Driver, Dates, Bus, FuelAmount, SoldTickets, Application);
        }

        public override string ToString()
        {
            return ToString(false);
        }
        public void RegisterChange(Program.Observer so)
        {
            tripobser += so;
        }
        public void ChangeTrip()
        {
            Console.WriteLine("Джерело : З’явився рейс!");
            if (tripobser != null)
            {
                tripobser(this);
            }
        }

    }
}
