using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Menu
    {
        private static void setCursorVisibility(bool state)
        {
            try
            {
                Console.CursorVisible = state;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Stack<Menu> VisitedMenus;
        public string Title { get; set; }
        public List<MenuEntry> Choises { get; set; }
        public Menu Parent { get; set; }
        public MenuEntry Selected { get; set; }

        static Menu()
        {
            VisitedMenus = new Stack<Menu>();
        }

        public Menu(string title)
        {
            Title = title;
        }

        public Menu(string title, List<MenuEntry> choises)
        {
            Title = title;
            Choises = choises;
        }

        public Menu(List<MenuEntry> choises)
        {
            Choises = choises;
        }

        public Menu Show()
        {
            VisitedMenus.Push(this);

            if (VisitedMenus.Count > 1)
            {
                const string title = "Назад";
                var menuEntries = (from MenuEntry m in Choises where m.Title == title select m).ToArray();

                if (!menuEntries.Any())
                    Choises.Add(new MenuEntry(title, VisitedMenus.Peek(), true));
            }
            else
            {
                const string title = "Вихiд";
                var menuEntries = (from MenuEntry m in Choises where m.Title == title select m).ToArray();

                if (!menuEntries.Any())
                    Choises.Add(new MenuEntry(title, () => { }, true));
            }

            setCursorVisibility(false);
            Selected = Choises.First();
            MenuLayout(true);
            ConsoleKeyInfo c;
            do
            {
                c = Console.ReadKey(true);
                if (c.Key == ConsoleKey.UpArrow)
                {
                    var index = Choises.IndexOf(Selected) - 1;
                    Selected = index < 0 ? Choises.Last() : Choises[index];
                    MenuLayout(false);
                }
                if (c.Key == ConsoleKey.DownArrow)
                {
                    var index = Choises.IndexOf(Selected) + 1;
                    Selected = index >= Choises.Count ? Choises.First() : Choises[index];
                    MenuLayout(false);
                }
            } while (c.Key != ConsoleKey.Enter);

            if (Selected.Back)
            {
                if (Selected.Title != "Вихiд")
                {
                    VisitedMenus.Pop();
                    VisitedMenus.Pop().Show();
                }
            }
            else
            {
                if (Selected.Callback == null)
                    Selected.Menu.Show();
                else
                {
                    DrawHeader(true);
                    Selected.Callback.Invoke();
                    const string msg = "*** Натиснiть enter для повернення в попередне меню. ***";
                    Console.WriteLine("{0," + (Console.WindowWidth + msg.Length) / 2 + "}", msg);
                    Console.ReadLine();
                    VisitedMenus.Pop().Show();
                }
            }
            return this;
        }

        public void DrawHeader(bool b)
        {
            if (b)
                Console.Clear();
            else
                Console.SetCursorPosition(0, 0);

            Console.WriteLine("\n{0," + (Console.WindowWidth + Title.Length) / 2 + "}\n", Title);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public void MenuLayout(bool b)
        {
            DrawHeader(b);

            for (int i = 0; i < Choises.Count; i++)
            {
                MenuEntry choise = Choises[i];
                if (choise == Selected)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine("{0,2}. {1, -" + (Console.WindowWidth - 5) + "}", i + 1, choise.Title);
                if (choise == Selected)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}
