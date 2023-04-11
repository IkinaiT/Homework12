using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework12
{
    internal class NotDeposite : BankCheck
    {
        public NotDeposite(string userName) : base(userName)
        {
        }

        public override bool Withdraw(float cash)
        {
            bool result = MessageBox.Show("При снятии вы должны дополнительно оплатить 15% комиссии, продолжить?", 
                "Предупреждение!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;
            if(result)
                return base.Withdraw(cash * 1.15f);
            else
                return false;
        }
    }
}
