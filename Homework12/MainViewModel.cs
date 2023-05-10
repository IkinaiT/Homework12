using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using WpfApp2;

namespace Homework12
{
    internal class MainViewModel : Transferer, INotifyPropertyChanged
    {
        public ObservableCollection<BankCheck> BankChecks { get; set; }

        private BankCheck selectedCheck;
        public BankCheck SelectedCheck
        {
            get { return selectedCheck; }
            set
            {
                selectedCheck = value;
                OnPropertyChanged("SelectedCheck");
            }
        }

        private BankCheck selectedCheckTransaction;
        public BankCheck SelectedCheckTransaction
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
            BankChecks = new ObservableCollection<BankCheck>();
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

        private RelayCommand transactionCommand;
        public RelayCommand TransactionCommand
        {
            get
            {
                return transactionCommand ??
                    (transactionCommand = new RelayCommand(obj =>
                    {
                        Transfer<BankCheck>(SelectedCheck, SelectedCheckTransaction, Cash);
                        SelectedCheckTransaction = null;
                    },
                    obj => SelectedCheck != null && 
                           SelectedCheckTransaction != null && 
                           SelectedCheck != SelectedCheckTransaction &&
                           Cash > 0));
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
                BankChecks.Add(new BankCheck("NDUsername" + i));
            else
                BankChecks.Add(new BankCheck("DUsername" + i));
        }

        public override void Transfer<T>(T t1, T t2, float cash)
        {
            t1.Cash -= Cash;
            t2.Cash += Cash;
        }

    }
}
