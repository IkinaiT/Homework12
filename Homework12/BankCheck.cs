using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework12
{
    internal class BankCheck
    {
        static private int ID = 0;

        public string GetID
        {
            get
            {
                string s = ("{0:d16}", ID) + "$";
                return s;
            }
        }
        public string UserName { get; set; }
        public float Cash { get; set; } = 0.0f;


        public BankCheck(string userName)
        {
            BankCheck.ID++;
            UserName = userName;
        }

        public void TopUp(float cash)
        {
            Cash += cash;
        }

        public virtual bool Withdraw(float cash) 
        {
            if (Cash >= cash)
            {
                Cash -= cash;
                return true;
            }
            else
            {
                MessageBox.Show("Недостаточно средств!");
                return false;
            }
        }
    }
}
