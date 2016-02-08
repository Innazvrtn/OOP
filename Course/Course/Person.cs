using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
    public abstract class Person
    {
        private string name;
        public Date date { get; private set; }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string SurName { get; private set; }

        protected Person()
            : this("Unknow", "Unknow", 01, 01, 2000)
        {
        }
        public Person(string name, string surname, Date d)
        {
            this.name = name;
            SurName = surname;
            this.date = d;

        }
        public Person(string name, string surname, int year, int month, int day)
        {
            this.name = name;
            SurName = surname;
            this.date = new Date(year, month, day);

        }
    }
}
