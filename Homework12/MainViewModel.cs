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
    

    internal class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Коллекция всех счетов
        /// </summary>
        public ObservableCollection<BankCheck> BankChecks { get; set; }

        /// <summary>
        /// Выбранный в ListBox'е пользователь
        /// </summary>
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

        /// <summary>
        /// Выбранный в ComboBox'е пользователь
        /// </summary>
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

        /// <summary>
        /// Кол-во переволимых/снимаемых денег
        /// </summary>
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

        /// <summary>
        /// Возможно ли совершить перевод
        /// </summary>
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
        
        /// <summary>
        /// Итератор заполнения коллекции
        /// </summary>
        private int i = 0;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainViewModel()
        {
            BankChecks = new ObservableCollection<BankCheck>();
            for(; i < 10; i++)
            {
                AddUser();
            }
        }

        /// <summary>
        /// Команда добавления счета
        /// </summary>
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

        /// <summary>
        /// Команда удаления счета
        /// </summary>
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

        /// <summary>
        /// Команда перевода между счетами
        /// </summary>
        private RelayCommand transactionCommand;
        public RelayCommand TransactionCommand
        {
            get
            {
                return transactionCommand ??
                    (transactionCommand = new RelayCommand(obj =>
                    {
                        ITransfer<BankCheck> t;
                        ITransfer<Deposite> td = SelectedCheck as Deposite;
                        ITransfer<NotDeposite> tnd = SelectedCheck as NotDeposite;
                        if (td != null)
                            t = td as BankCheck;
                        else
                            t = tnd as BankCheck;

                        t.Transfer(SelectedCheckTransaction as BankCheck, Cash);

                    },
                    obj => SelectedCheck != null && 
                           SelectedCheckTransaction != null && 
                           SelectedCheck != SelectedCheckTransaction &&
                           Cash > 0));
            }
        }

        /// <summary>
        /// Команда снятия денег со счета
        /// </summary>
        private RelayCommand withdrawChechCommand;
        public RelayCommand WithdrawCommand
        {
            get
            {
                return withdrawChechCommand ??
                    (withdrawChechCommand = new RelayCommand(obj =>
                    {
                        IWithdraw<Deposite> scd = SelectedCheck as Deposite;
                        IWithdraw<NotDeposite> scn = SelectedCheck as NotDeposite;
                        IWithdraw<BankCheck> withdraw;

                        if (scn != null)
                            withdraw = scn;
                        else
                            withdraw = scd;

                        withdraw.Withdraw(Cash);
                    }));
            }
        }

        /// <summary>
        /// MVVM 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Метод добавления пользователя
        /// </summary>
        private void AddUser()
        {
            if (i % 2 != 0)
                BankChecks.Add(new NotDeposite("NDUsername" + i));
            else
                BankChecks.Add(new Deposite("DUsername" + i));
        }

    }
}
