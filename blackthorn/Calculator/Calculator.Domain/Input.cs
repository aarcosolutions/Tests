using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain
{
    public class Input : IInput
    {
        public long FirstArgument
        {
            get;
            set;
        }

        public string Operator
        {
            get;
            set;
        }

        public long SecondArgument
        {
            get;
            set;
        }
    }
}
