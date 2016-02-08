using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class MenuEntry
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public Menu Menu { get; set; }
        public Action Callback { get; set; }
        public bool Back { get; set; }

        public MenuEntry(string title, Menu menu, bool back = false)
        {
            Title = title;
            Menu = menu;
            if (!back)
                Menu.Title = title;
            Back = back;
        }

        public MenuEntry(string title, Action callback, bool back = false)
        {
            Title = title;
            Callback = callback;
            Back = back;
        }
    }

}
