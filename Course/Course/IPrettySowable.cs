using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public interface IPrettyShowable
    {
        void ShowHeader();
        string ToString(bool pretty);
    }

}
