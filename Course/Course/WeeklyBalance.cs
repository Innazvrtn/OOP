using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
    public class WeeklyBalance : IPrettyShowable
    {
        // Delegate
        public delegate string Output(Trip trip);
        // trips for this week
        private List<Trip> trips;
        public List<Trip> Trips
        {
            get { return trips; }
            set { trips = value; }
        }
        // Date when week starts
        //private int countoftrips;
        public Date WeekFrom { get; private set; }
        // Date when week ends
        private Date _weekTo;
        // Getter for _weekTo
        public Date WeekTo
        {
            get
            {
                // Caching object
                return _weekTo;
            }
        }

        public WeeklyBalance(List<Trip> tripss, Date weekFrom)
        {
            WeekFrom = weekFrom;
            _weekTo = WeekFrom.AddDays(6);
            Trips = tripss;
        }

        public void AddTrip(Trip trip)
        {
            if (TripBelongs(trip))
            {
                Trips.Add(trip);
            }
        }
        //check
        private bool TripBelongs(Trip trip)
        {
            return (trip.Dates >= WeekFrom && trip.Dates <= WeekTo);
        }

        public Trip this[int i]
        {
            get { return Trips[i]; }
            set { Trips[i] = value; }
        }
        public void ForEach(Action<Trip> action)
        {
            Trips.ForEach(action);
        }
        public string Display(Output action)
        {
            var s = new StringBuilder();
            s.Append("{weekFrom: ").Append(WeekFrom).Append(", trips: [");

            var tripStrings = new List<string>();
            ForEach((trip) => tripStrings.Add(action.Invoke(trip)));
            s.Append(String.Join(", ", tripStrings.ToArray()));

            return s.Append("]}").ToString();
        }

        public static string AllInfo(Trip trip)
        {
            return String.Format("{{Order: {0}, Truck: {1}, Date: {2}, FuelAmount: {3}}}", trip.Application.ToString(false), trip.Bus.ToString(false), trip.Dates.ToString(true), trip.FuelAmount);
        }
        //Output
        public void ShowHeader()
        {
            const string title = "Недельный баланс";
            Console.WriteLine("\n{0," + (Console.WindowWidth + title.Length) / 2 + "}\n", title);
            Console.Write(Line());
            Console.Write("|       Количество рейсов        |     Дата начала      |      Дата конца      |");
            Console.Write(Line());
        }

        private string Line()
        {
            return "+--------------------------------+----------------------+----------------------+";
        }

        public string ToString(bool pretty)
        {
            if (pretty)
                return String.Format("| {0,30} | {1,20} | {2,20} |", Trips.Count, WeekFrom.ToString(true), WeekTo.ToString(true)) + Line();
            return Display(AllInfo);
        }

        public override string ToString()
        {
            return Display(AllInfo);
        }
        //delegat
        public static void See(object obj)
        {
            Console.WriteLine("Спостерiгач: З’явилися змiни");
            Console.WriteLine();
        }

        public static WeeklyBalance operator +(WeeklyBalance wb, Trip trip)
        {
            wb.AddTrip(trip);
            return wb;
        }

    }
}
