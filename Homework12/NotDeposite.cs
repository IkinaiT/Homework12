using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework12
{
    internal class NotDeposite : BankCheck, IWithdraw<NotDeposite>
    {
        public NotDeposite(string userName) : base(userName)
        {
        }

        public NotDeposite Withdraw(float money)
        {
            Cash -= money;
            return this;
        }
    }
}
