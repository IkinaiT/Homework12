using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal interface IWithdraw<out T>
        where T : BankCheck
    {
        T Withdraw(float money);
    }
}
