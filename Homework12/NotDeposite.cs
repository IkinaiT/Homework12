using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework12
{
    internal class NotDeposite<T> : BankCheck<T>
    {
        public NotDeposite(T userName) : base(userName)
        {
        }
    }
}
