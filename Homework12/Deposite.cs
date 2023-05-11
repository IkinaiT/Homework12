using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal class Deposite : BankCheck, IWithdraw<Deposite>
    {
        public Deposite(string userName) : base(userName)
        {
        }

        public Deposite Withdraw(float money)
        {
            Cash -= money;
            return this;
        }
    }
}
