using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Course
{
    public static class StringExtension
    {
        public static string GetLast(this string source, int tailLength)
        {
            if (tailLength >= source.Length)
                return source;
            return source.Substring(source.Length - tailLength);
        }
    }
    public static class Program
    {
        public delegate void Observer(object obj);
        private static List<Trip> _trips = new List<Trip>();
        private static List<Application> _applications = new List<Application>();
        private static List<Bus> _buses = new List<Bus>();
        private static List<Driver> _drivers = new List<Driver>();
        private static List<WeeklyBalance> _weeklyBalances = new List<WeeklyBalance>();
        static int ind = 0;
        //checking for input string
        private static string GetString(string title, Regex regex = null)
        {
            Console.WriteLine(title + " <12 :");
            var input = "";
            bool condition, f;
            do
            {
                f = false;
                input = Console.ReadLine();
                condition = (input != null && ((input.Length == 0) || (regex != null && !regex.Match(input).Success)));
                if (condition)
                {
                    Console.WriteLine("Невiрний ввiд");
                    Console.WriteLine(title + " <12 :");
                }
                if (input.Length > 13)
                {
                    Console.WriteLine("Ви ввели >13 символiв");
                    Console.WriteLine(title + " <12 :");
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] >= '0' && input[i] <= '9')
                    {

                        f = true;
                    }

                }
                if (f == true)
                {
                    Console.WriteLine("Помилки ви ввели числовi символи");
                    Console.WriteLine(title + ":");
                }
            } while (condition || input.Length > 13 || f);
            return input;
        }
        // checking for input file name
        private static string GetStringF(string title, Regex regex = null)
        {
            Console.WriteLine(title + "  :");
            var input = "";
            bool condition;
            do
            {

                input = Console.ReadLine();
                condition = (input != null && ((input.Length == 0) || (regex != null && !regex.Match(input).Success)));
                if (condition)
                {
                    Console.WriteLine("Невiрний ввiд");
                }

            } while (condition);
            return input;
        }
        //checking for input int32
        private static int GetInt(string title)
        {
            Console.WriteLine(title + ":");
            var input = 0;
            bool condition;
            string i;
            do
            {
                condition = false;
                try
                {
                    do
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                        i = Convert.ToString(input);
                        if (i.Length > 6)
                        {
                            Console.WriteLine("Ви ввели >7 символiв");
                            Console.WriteLine(title + " <7 :");
                        }
                        if (input <= 0)
                        {
                            Console.WriteLine("Введiть числове значення бiльше нуля");
                            Console.WriteLine(title + ":");
                        }

                    }
                    while (input <= 0 || i.Length > 6);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Невiрний ввiд" + ex.Message);
                    condition = true;
                }
            } while (condition);
            return input;
        }
        //checking for input cout of soldtickets
        private static int GetIntK(string title)
        {
            Console.WriteLine(title + ":");
            var input = 0;
            bool condition;
            string i;
            do
            {
                condition = false;
                try
                {
                    do
                    {
                        do
                        {
                            input = Convert.ToInt32(Console.ReadLine());

                            i = Convert.ToString(input);
                            if (i.Length > 6)
                            {
                                Console.WriteLine("Ви ввели >7 символiв");
                                Console.WriteLine(title + " <7 :");
                            }
                            if (input <= 0)
                            {
                                Console.WriteLine("Введiть числове значення бiльше нуля(кiлькiсть проданих квиткiв <=кiлькостi мiсть)");
                                Console.WriteLine(title + ":");
                            }
                            if (_buses[ind].Numbers < input)
                            {
                                Console.WriteLine("Введена кiлькiсть бiльша кiлькостi мiсть (кiлькiсть проданих квиткiв <=кiлькостi мiсть)");
                                Console.WriteLine(title + ":");
                            }

                        }
                        while (_buses[ind].Numbers < input);
                    }
                    while (input <= 0 || i.Length > 6);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Невiрний ввiд" + ex.Message);
                    condition = true;
                }
            } while (condition);
            return input;
        }
        //checking for input double
        private static double GetDouble(string title)
        {
            Console.WriteLine(title + ":");
            double input = 0;
            bool condition;
            string i;
            do
            {
                condition = false;
                try
                {
                    do
                    {
                        i = Convert.ToString(input);
                        if (i.Length > 6)
                        {
                            Console.WriteLine("Ви ввели >7 символiв");
                            Console.WriteLine(title + " <7 :");
                        }
                        input = Convert.ToDouble(Console.ReadLine());
                        if (input <= 0)
                        {
                            Console.WriteLine("Введiть числове значення бiльше нуля");
                            Console.WriteLine(title + ":");
                        }


                    } while (input <= 0 || i.Length > 6);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Невiрний ввiд " + ex.Message);
                    condition = true;
                }
            } while (condition);
            return input;
        }
        //checking for input decimal and own ex
        private static decimal GetDecimal(string title)
        {
            Console.WriteLine(title + ":");
            decimal input = 0;
            bool condition;
            string i;
            do
            {
                condition = false;
                try
                {
                    do
                    {

                        input = Convert.ToDecimal(Console.ReadLine());
                        i = Convert.ToString(input);
                        if (i.Length > 6)
                        {
                            Console.WriteLine("Ви ввели >7 символiв");
                            Console.WriteLine(title + " <7 :");
                        }
                        if (input <= 0)
                        {
                            Console.WriteLine("Введiть числове значення бiльше нуля");
                            Console.WriteLine(title + ":");
                        }

                    } while (input <= 0 || i.Length > 6);
                }
                catch (LessthennullExeception e)
                {
                    Console.WriteLine("Невiрний ввiд " + e.Message);
                    condition = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Невiрний ввiд " + e.Message);
                    condition = true;
                }
            } while (condition);

            return input;
        }
        //checking for input Month
        private static int GetIntM(string title)
        {
            Console.WriteLine(title + ":");
            var input = 0;
            bool condition;
            do
            {
                condition = false;
                try
                {
                    do
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                        if (input <= 0 || input > 13)
                        {
                            Console.WriteLine("Введiть мiсяць вiд 1 до 12");
                            Console.WriteLine(title + ":");
                        }

                    }
                    while (input <= 0 || input > 13);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Невiрний ввiд" + ex.Message);
                    condition = true;
                }
            } while (condition);
            return input;
        }
        //checking for input day
        private static int GetIntD(string title)
        {
            Console.WriteLine(title + ":");
            var input = 0;
            bool condition;
            do
            {
                condition = false;
                try
                {
                    do
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                        if (input <= 0 || input > 32)
                        {
                            Console.WriteLine("Введiть день вiд 1 до 31");
                            Console.WriteLine(title + ":");
                        }

                    }
                    while (input <= 0 || input > 32);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Невiрний ввiд" + ex.Message);
                    condition = true;
                }
            } while (condition);
            return input;
        }
        //checking for input day
        private static int GetIntY(string title)
        {
            Console.WriteLine(title + ":");
            var input = 0;
            bool condition;
            do
            {
                condition = false;
                try
                {
                    do
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                        if (input < 1900)
                        {
                            Console.WriteLine("Введiть рiк >1900");
                        }
                        if (21 > DateTime.Today.Year - input)
                        {
                            Console.WriteLine("Водiю не виповнилося 21 рiк.Керування автобусом заборонено.Перевiрте правильнiсть введених даних");
                            Console.WriteLine(title + ":");
                        }

                    }
                    while (input <= 1900 || 21 > DateTime.Today.Year - input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Невiрний ввiд" + ex.Message);
                    condition = true;
                }
            } while (condition);
            return input;
        }
        //checking for input Date
        private static Date GetDate(string title)
        {

            int d = 0;
            int m = 0;
            int y = 0;
            bool condition;
            do
            {
                condition = false;
                try
                {
                    do
                    {
                        Console.WriteLine("Рiк >1900" + ":");
                        y = Convert.ToInt32(Console.ReadLine());
                    } while (y < 1900);
                    do
                    {
                        Console.WriteLine("Мiсяць(1<m<12)" + ":");
                        m = Convert.ToInt32(Console.ReadLine());
                    }
                    while (m > 13 || m < 0);
                    do
                    {
                        Console.WriteLine("День(1<d<31)" + ":");
                        d = Convert.ToInt32(Console.ReadLine());
                    } while (d < 0 || d > 32);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Невiрний ввiд " + e.Message);
                    condition = true;
                }
            } while (condition);
            return new Date(y, m, d);
        }
        //choose
        private static T Get<T>(string title, IReadOnlyList<T> collection)
        {
            Console.WriteLine("Оберiть " + title + ":");
            var resource = default(T);

            for (var i = 0; i < collection.Count; i++)
                Console.WriteLine("{0}. {1}", i + 1, collection[i]);


            bool condition;
            do
            {
                condition = false;

                var index = GetInt("Номер") - 1;
                ind = index;
                try
                {
                    resource = collection[index];
                }
                catch (Exception ex)
                {
                    condition = true;
                    Console.WriteLine("Невiрний номер! " + ex.Message);
                }
            } while (condition);

            return resource;
        }
        // for weeklybalance
        private static List<T> GetList<T>(string title, List<T> collection)
        {
            var l = new List<T>();

            bool condition;
            do
            {
                condition = false;
                l.Add(Get(title, collection));
                Console.WriteLine("Додати?(Введiть 'y' або 'д' або '1' для пiдтвердження)");
                var input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToLower();
                    if (input == "y" || input == "д" || input == "1")
                    {
                        condition = true;
                    }
                }
            } while (condition);
            return l;
        }
        private static void ShowCollection<T>(List<T> collection)
        {
            if (collection.Any())
            {
                ((IPrettyShowable)(collection.First())).ShowHeader();

                foreach (var t in collection)
                    Console.Write(((IPrettyShowable)t).ToString(true));

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Об’єкти в базi вiдсутнi");
            }

        }
        // checking for name bin file
        private static string GetPath(bool exists = false)
        {
            string path;
            bool condition;
            do
            {
                condition = false;
                path = GetStringF("Назва файлу", new Regex(@"^[\w^ ]+[ \w]+(.*)$"));
                const string extension = ".bin";
                if (path.GetLast(4) != extension)
                    path += extension;
                if (exists && !File.Exists(path))
                    condition = true;
            } while (condition);
            return path;
        }
        private static string GetName(bool exists = false)
        {
            string path;
            bool condition;
            do
            {
                condition = false;
                path = GetStringF("Назва файлу", new Regex(@"^[\w^ ]+[ \w]+(.*)$"));
                const string extension = ".txt";
                if (path.GetLast(4) != extension)
                    path += extension;
                if (exists && !File.Exists(path))
                    condition = true;
            } while (condition);
            return path;
        }
        //Write txt file
        private static void FileWrite()
        {
            try
            {
                var name = GetName();
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(name);

                //Write a line of text
                sw.WriteLine("Bus {0}", _buses.Count);
                for (var i = 0; i < _buses.Count; i++)
                {
                    sw.WriteLine("Kiлькiсть мiсць {0} Витр.на100км {1}", _buses[i].Numbers, _buses[i].Consumption);
                }
                sw.WriteLine("Driver {0}", _drivers.Count);
                for (var i = 0; i < _drivers.Count; i++)
                {
                    sw.WriteLine("Iм’я {0} Прiзвище {1}  Дата народження {2} Оклад {3} ", _drivers[i].Name, _drivers[i].SurName, _drivers[i].date.ToString(true), _drivers[i].Wages);
                }
                sw.WriteLine("Application {0}", _applications.Count);
                for (var i = 0; i < _applications.Count; i++)
                {
                    sw.WriteLine("Вiдстань {1} Вартiсть {2} Пункт призначення {0}    ", _applications[i].Destination, _applications[i].Long, _applications[i].Cost);
                }
                sw.WriteLine("Trip {0}", _trips.Count);
                for (var i = 0; i < _trips.Count; i++)
                {
                    sw.WriteLine("{0} {1} {2} {3} {4}", _trips[i].Driver.ToString(false), _trips[i].Bus.ToString(false), _trips[i].SoldTickets, _trips[i].Application.ToString(false), _trips[i].Dates.ToString(true));
                }
                sw.WriteLine("WeeklyBalances {0}", _weeklyBalances.Count);
                for (var i = 0; i < _weeklyBalances.Count; i++)
                {
                    sw.WriteLine("Trips {0}", _weeklyBalances[i].Trips.Count);
                    for (var j = 0; j < _weeklyBalances[i].Trips.Count; j++)
                    {
                        sw.WriteLine("{0} {1} {2} ", _weeklyBalances[i].Trips[j], _weeklyBalances[i].WeekFrom.ToString(true), _weeklyBalances[i].WeekTo.ToString(true));
                    }
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Файл записано");
            }
        }
        //Read txt file
        private static void FileReade()
        {
            try
            {
                var name = GetName();
                StreamReader sr = new StreamReader(name);
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] f = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < Convert.ToInt32(f[1]); i++)
                    {
                        string line1 = sr.ReadLine();
                        string[] f2 = line1.Split(new Char[] { ' ' });
                        Bus b = new Bus();
                        b.Numbers = Convert.ToInt32(f2[2]);
                        b.Consumption = Convert.ToDecimal(f2[4]);
                        _buses.Add(b);
                    }
                    line = sr.ReadLine();
                    f = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < Convert.ToInt32(f[1]); i++)
                    {
                        line = sr.ReadLine();
                        string[] f3 = line.Split(new Char[] { ' ' });
                        string[] f2 = f3[7].Split(new Char[] { '/' });
                        Driver d = new Driver(f3[1], f3[3], Convert.ToInt32(f2[2]), Convert.ToInt32(f2[1]), Convert.ToInt32(f2[0]), Convert.ToDecimal(f3[9]));
                        _drivers.Add(d);
                    }
                    line = sr.ReadLine();
                    f = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < Convert.ToInt32(f[1]); i++)
                    {
                        line = sr.ReadLine();
                        string[] f2 = line.Split(new Char[] { ' ' });
                        Application a = new Application(Convert.ToDecimal(f2[1]), Convert.ToDouble(f2[3]), f2[6]);
                        _applications.Add(a);
                    }
                    line = sr.ReadLine();
                    f = line.Split(new Char[] { ' ' });
                    for (int i = 0; i < Convert.ToInt32(f[1]); i++)
                    {
                        line = sr.ReadLine();
                        string[] f3 = line.Split(new Char[] { ' ' });
                        string[] f2 = f3[6].Split(new Char[] { '/' });
                        string[] f4 = f3[25].Split(new Char[] { '/' });

                        Driver d1 = new Driver(f3[1], f3[3], Convert.ToInt32(f2[2]), Convert.ToInt32(f2[1]), Convert.ToInt32(f2[0]), Convert.ToDecimal(f3[8]));
                        Bus b1 = new Bus(Convert.ToInt32(f3[11]), Convert.ToDecimal(f3[13]));
                        Date d = new Date(Convert.ToInt32(f4[2]), Convert.ToInt32(f4[1]), Convert.ToInt32(f4[0]));
                        Application a = new Application(Convert.ToDecimal(f3[21]), Convert.ToDouble(f3[23]), f3[18]);
                        Trip T = new Trip(d1, b1, d, Convert.ToInt32(f3[15]), a);
                        _trips.Add(T);
                    }
                    line = sr.ReadLine();
                    f = line.Split(new Char[] { ' ' });

                    for (int j = 0; j < Convert.ToInt32(f[1]); j++)
                    {
                        line = sr.ReadLine();
                        List<Trip> Tripstry = new List<Trip>();

                        string[] f5 = line.Split(new Char[] { ' ' });
                        if (Convert.ToInt32(f5[1]) != 0)
                        {

                            for (int i = 0; i < Convert.ToInt32(f5[1]); i++)
                            {
                                line = sr.ReadLine();
                                string[] f3 = line.Split(new Char[] { ' ' });
                                string[] f2 = f3[7].Split(new Char[] { '/' });
                                string[] f4 = f3[12].Split(new Char[] { '/' });

                                Driver d1 = new Driver(f3[2], f3[4], Convert.ToInt32(f2[2]), Convert.ToInt32(f2[1]), Convert.ToInt32(f2[0]), Convert.ToDecimal(f3[9]));
                                Bus b1 = new Bus(Convert.ToInt32(f3[15]), Convert.ToDecimal(f3[17]));
                                Date d = new Date(Convert.ToInt32(f4[2]), Convert.ToInt32(f4[1]), Convert.ToInt32(f4[0]));
                                Application a = new Application(Convert.ToDecimal(f3[32]), Convert.ToDouble(f3[34]), f3[29]);
                                Trip T = new Trip(d1, b1, d, Convert.ToInt32(f3[25]), a);

                                Tripstry.Add(T);

                            }
                            string[] f7 = line.Split(new Char[] { ' ' });
                            string[] f6 = f7[37].Split(new Char[] { '/' });

                            Date d2 = new Date(Convert.ToInt32(f6[2]), Convert.ToInt32(f6[1]), Convert.ToInt32(f6[0]));
                            WeeklyBalance w = new WeeklyBalance(Tripstry, d2);
                            _weeklyBalances.Add(w);
                            //_weeklyBalances[0].CountofTrips = (Convert.ToInt32(f5[1]));
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Файл вiдкрито");
            }
        }
        //serrialize and bin file write
        private static void SerializeGraph()
        {
            var path = GetPath();

            var binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, _trips);
                binFormat.Serialize(fStream, _drivers);
                binFormat.Serialize(fStream, _applications);
                binFormat.Serialize(fStream, _buses);
                binFormat.Serialize(fStream, _weeklyBalances);
            }
        }
        //serrialize and bin file read
        private static void DeserializeGraph()
        {
            string path;
            bool condition;
            do
            {
                condition = false;

                try
                {
                    path = GetPath(true);

                    var binFormat = new BinaryFormatter();
                    using (Stream fStream = File.OpenRead(path))
                    {
                        _trips = (List<Trip>)binFormat.Deserialize(fStream);
                        _drivers = (List<Driver>)binFormat.Deserialize(fStream);
                        _applications = (List<Application>)binFormat.Deserialize(fStream);
                        _buses = (List<Bus>)binFormat.Deserialize(fStream);
                        _weeklyBalances = (List<WeeklyBalance>)binFormat.Deserialize(fStream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Файл не iснує або обраний невiрний файл. Повторити (Введiть 'y' або 'д' або '1')? " + ex.Message);
                    string input = Console.ReadLine();
                    if (input == "y" || input == "д" || input == "1")
                        condition = true;
                }
                finally
                {
                    Console.WriteLine("Файл вiдкрито");
                }
            } while (condition);
        }
        //statistic function
        public delegate decimal StaticticFunction(Application trip);

        public static void Avg(string title, StaticticFunction f)
        {
            decimal sum = 0, sum1 = 0;
            var count = 1;
            var c = 1;

            if (_weeklyBalances.Any() && _weeklyBalances.First().Trips.Any())
                for (c = 0; c < _weeklyBalances.Count; c++)
                {
                    sum = 0;
                    for (count = 0; count < _weeklyBalances.First().Trips.Count; count++)
                    {
                        sum += f.Invoke(_weeklyBalances.First().Trips[count].Application);
                    }
                    sum = sum / count;
                    sum1 += sum;
                }

            Console.WriteLine("Среднє {0}: {1:F2}", title, count == 0 ? 0 : sum1 / c);
        }


        public static void All(string title, StaticticFunction f)
        {
            decimal sum = 0;
            var count = 1;
            var c = 1;
            if (_weeklyBalances.Any() && _weeklyBalances.First().Trips.Any())
                for (c = 0; c < _weeklyBalances.Count; c++)
                {
                    for (count = 0; count < _weeklyBalances.First().Trips.Count; count++)
                        sum += f.Invoke(_weeklyBalances.First().Trips[count].Application);
                }

            Console.WriteLine("Протяжнicть всiх рейсiв {0}: {1:F2}", title, count == 0 ? 0 : sum);
        }
        // seach in cost
        public delegate T SearchDelegate<out T>(Application application);

        public static void SearchDouble(string title, SearchDelegate<double> f)
        {
            var condition = GetDouble(title);
            var search = _applications.Where(application => f.Invoke(application) == condition).ToList();
            ShowCollection(search);
        }
        //seach in destination
        public static void SearchString(string title, SearchDelegate<string> f)
        {
            var condition = GetString(title);
            var search = _applications.Where(application => f.Invoke(application) == condition).ToList();
            ShowCollection(search);
        }
        public static void AddMassTen(List<Trip> tripn,List<Application> ap,List<Bus> b,List<Driver> dr,List<WeeklyBalance> wb) {
            Bus bus =new Bus(45,12);
            Bus bus1 =new Bus(35,15);
            Bus bus2 =new Bus(12,10);
            b.Add(bus);
            b.Add(bus1);
            b.Add(bus2);
            Driver d = new Driver("Inna", "Zavertana", 1990, 2, 21, 3000);
            Driver d1 = new Driver("Mihail", "Logvin", 1992, 11, 21, 2000);
            Driver d3 = new Driver("Vova", "Voytash", 1991, 7, 10, 1000);
            dr.Add(d);
            dr.Add(d1);
            dr.Add(d3);
            Date f = new Date(2015,05,10);
            Date f2 = new Date(2015,05,11);
            Date f3 = new Date(2015,05,12);
            Date f4 = new Date(2015, 05, 13);
            Application app = new Application(140, 80, "Kiev");
            Application app1 = new Application(270, 180, "Lviv");
            Application app2 = new Application(144, 85, "Zhachkiv");
            ap.Add(app);
            ap.Add(app1);
            ap.Add(app2);
            Trip t = new Trip(d, bus, f, 10, app);
            Trip t1 = new Trip(d1, bus1, f, 25, app2);
            Trip t2 = new Trip(d3, bus2, f, 5, app2);
            Trip t3 = new Trip(d, bus, f2, 38, app);
            Trip t4 = new Trip(d1, bus1, f2,8, app2);
            Trip t5 = new Trip(d3, bus2, f2, 11, app2);
            Trip t6 = new Trip(d, bus, f3, 38, app);
            Trip t7 = new Trip(d1, bus1, f3, 8, app2);
            Trip t8 = new Trip(d3, bus2, f3, 11, app2);
            Trip t9 = new Trip(d, bus, f4, 11, app2);
            tripn.Add(t);
            tripn.Add(t1);
            tripn.Add(t2);
            tripn.Add(t3);
            tripn.Add(t4);
            tripn.Add(t5);
            tripn.Add(t6);
            tripn.Add(t7);
            tripn.Add(t8);
            tripn.Add(t9);
            WeeklyBalance w = new WeeklyBalance(tripn, f);
            wb.Add(w);
        }
        static void Main(string[] args)
        {

            _trips = new List<Trip>();
            _applications = new List<Application>();
            _buses = new List<Bus>();
            _drivers = new List<Driver>();
            _weeklyBalances = new List<WeeklyBalance>();
            AddMassTen(_trips,_applications,_buses,_drivers,_weeklyBalances);
            new Menu("Головне меню", new List<MenuEntry>()
            {
                new MenuEntry("Додати", new Menu(new List<MenuEntry>() {
                    new MenuEntry("Автобус", () => _buses.Add(new Bus(GetInt("Кiлькiсть мiсць"), GetDecimal("Витрати пального на 100 км")))),
                    new MenuEntry("Водiй",() => _drivers.Add(new Driver(GetString("Iм’я"),GetString("Прiзвище"),GetIntY("Рiк"), GetIntM("Мiсяць"), GetIntD("День"), GetDecimal("Оклад")))),
                    new MenuEntry("Заявка", () => _applications.Add(new Application( GetDecimal("Протяжнicть маршруту"),  GetDouble("Вартiсть квитка"),GetString("Пункт призначення")))),
                    new MenuEntry("Рейс", () =>  _trips.Add(new Trip(Get("Водiя", _drivers), Get("Автобус", _buses), GetDate("Дата"),GetIntK("Кiлькiсть проданих квиткiв"),Get("Заявку",_applications)))),
                    new MenuEntry("Створити тижневий  баланс", () => _weeklyBalances.Add(new WeeklyBalance(GetList("Рейс", _trips), GetDate("Дата")))),
                    new MenuEntry("Додати рейс в тижневий баланс", () =>
                    {
                        var wb = Get("Тижневий баланс", _weeklyBalances);
                        var index = _weeklyBalances.IndexOf(wb);
                        wb += Get("Рейс", _trips);
                        if (index >= 0)
                            _weeklyBalances[index] = wb;
                    })
                })),
                new MenuEntry("Перегляд", new Menu(new List<MenuEntry>() {
                    new MenuEntry("Автобус", () => ShowCollection(_buses)),
                    new MenuEntry("Водiй", () => ShowCollection(_drivers)),
                    new MenuEntry("Заявка", () => ShowCollection(_applications)),
                     new MenuEntry("Рейси", () => ShowCollection(_trips)),
                    new MenuEntry("Тижневий  баланс", () => ShowCollection(_weeklyBalances)),
                    new MenuEntry("Список рейсiв для тижневого балансу", () =>
                    {
                        var wb = Get("Номер тижневого балансу", _weeklyBalances);

                        if (wb.Trips.Any())
                        {
                            ((IPrettyShowable)(wb.Trips.First())).ShowHeader();

                            for (int i = 0; i < wb.Trips.Count; i++)
                                Console.Write(((IPrettyShowable) wb[i]).ToString(true));

                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("Об’єкти  в базi вiдсутнi");
                    })
                })),
                new MenuEntry("Запис в бiнарний  файл", SerializeGraph),
                new MenuEntry("Зчитування даних з бiнарного файлу", DeserializeGraph),
                 new MenuEntry("Запис в текстовий файл", FileWrite),
                  new MenuEntry("Зчитування з текстового файлу",FileReade),
               new MenuEntry("Стастичнi функцiї", new Menu(new List<MenuEntry>()
                {
                    new MenuEntry("Средня вiдстань", () => Avg("Вiдстань ", Application.AppLong)),
                    new MenuEntry("Загальна  вiдстань", () => All("Загальна вiдстань", Application.AppLong)),
                })),
                new MenuEntry("Пошук", new Menu(new List<MenuEntry>()
                {
                    new MenuEntry("Пошук заявок по пункту призначення", () => SearchString("Пункт призначення", Application.AppDestination)),
                   new MenuEntry("Пошук заявки по вартостi квитка", () => SearchDouble("Введin", Application.AppCost)),
          })), 
                new MenuEntry("Паттерн \"Спостерiгач\"", () =>
                {
                    if (_weeklyBalances.Any())
                    {
                        for (int i = 0; i < _trips.Count ; i++)
                        {
                            _trips[i].RegisterChange(new Observer(WeeklyBalance.See));
                            _trips[i].ChangeTrip();
                        }
                    }
                    else
                        Console.WriteLine("Об’єкти  в базi вiдсутнi");
                })
            }).Show();
            Console.ReadLine();


        }
    }
}
