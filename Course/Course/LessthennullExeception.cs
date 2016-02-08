using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{

    [Serializable]
    public class LessthennullExeception : Exception
    {

        public LessthennullExeception(string message)
            : base(message)
        {
        }

        public LessthennullExeception(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
