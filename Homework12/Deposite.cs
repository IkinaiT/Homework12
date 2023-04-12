using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class Deposite<T> : BankCheck<T>
    {
        public Deposite(T userName) : base(userName)
        {
        }
    }
}
