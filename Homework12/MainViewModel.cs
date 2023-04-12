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
using WpfApp2;

namespace Homework12
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BankCheck<string>> BankChecks { get; set; }

        private BankCheck<string> selectedCheck;
        public BankCheck<string> SelectedCheck
        {
            get { return selectedCheck; }
            set
            {
                selectedCheck = value;
                OnPropertyChanged("SelectedCheck");
            }
        }

        private BankCheck<string> selectedCheckTransaction;
        public BankCheck<string> SelectedCheckTransaction
        {
            get { return selectedCheckTransaction; }
            set
            {
                selectedCheckTransaction = value; 
                OnPropertyChanged("SelectedCheckTransaction");
            }
        }

        private float _cash;
        public float Cash
        {
            get { return _cash; }
            set
            {
                _cash = value;
                CanTransaction = SelectedCheck.Cash > Cash && SelectedCheck != null && SelectedCheckTransaction != null;
                OnPropertyChanged("Cash");
            }
        }

        private bool canTransaction;
        public bool CanTransaction
        {
            get { return canTransaction; }
            set
            {
                canTransaction = value;
                OnPropertyChanged("CanTransaction");
            }
        }
        private int i = 0;
        public MainViewModel()
        {
            BankChecks = new ObservableCollection<BankCheck<string>>();
            for(; i < 10; i++)
            {
                AddUser();
            }
        }

        private RelayCommand addChechCommand;
        public RelayCommand AddCheckCommand
        {
            get
            {
                return addChechCommand ??
                    (addChechCommand = new RelayCommand(obj =>
                    {
                        AddUser();
                        i++;
                    }));
            }
        }

        private RelayCommand deleteCheckCommand;
        public RelayCommand DeleteCheckCommand
        {
            get
            {
                return deleteCheckCommand ??
                    (deleteCheckCommand = new RelayCommand(
                        obj => BankChecks.Remove(SelectedCheck),
                        obj => SelectedCheck != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void AddUser()
        {
            if (i % 2 != 0)
                BankChecks.Add(new NotDeposite<string>("NDUsername" + i));
            else
                BankChecks.Add(new Deposite<string>("DUsername" + i));
        }
    }
}
