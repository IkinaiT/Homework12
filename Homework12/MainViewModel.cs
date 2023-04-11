using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Homework12
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public int _cash = 0;
        public ObservableCollection<BankCheck> BankChecks;

        private BankCheck selectedCheck;
        public BankCheck SelectedCheck
        {
            get { return selectedCheck; }
            set { selectedCheck = value; }
        }

        public MainViewModel()
        {
            bool b = false;
            BankChecks = new ObservableCollection<BankCheck>();
            for(long i = 0; i < 1234567812345678; i++)
            {
                if (b)
                    BankChecks.Add(new NotDeposite("DUser" + i));
                else
                    BankChecks.Add(new Deposite("NDUser" + i));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
