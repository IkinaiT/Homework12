using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework12
{
    internal class BankCheck<T> : INotifyPropertyChanged
    {
        static private int ID = 0;
        private int currentID;
        public int CurrentID 
        {
            get
            {
                return currentID;
            }
            private set
            {
                currentID = value;
                OnPropertyChanged("CurrentID");
            }
        }
        public string GetID
        {
            get
            {
                string s = String.Format("{0:d16}", CurrentID);
                return s;
            }
        }
        public T UserName { get; set; }
        private float cash;
        public float Cash
        {
            get
            {
                return cash;
            }
            set
            {
                cash = value;
                OnPropertyChanged("Cash");
            }
        }

        public BankCheck(T userName)
        {
            UserName = userName;
            currentID = ID;
            BankCheck<T>.ID++;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
