using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IInput
    {
        long FirstArgument { get; set; }
        string Operator { get; set; }
        long SecondArgument { get; set; }
    }
}
