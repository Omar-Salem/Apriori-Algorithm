using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using AprioriAlgorithm;
using System.Windows.Input;

namespace WPFClient
{
    class MainViewModel : ViewModelBase
    {
        #region Member Variables

        ObservableSet<Item> _items;
        ObservableCollection<string> _transactions;
        string _selectedTransaction, _newItem, _error;
        double _minSupport = 1, _minConfidence = 1;
        Item _selectedItem;

        readonly IApriori _apriori;

        #endregion

        #region Constructor

        public MainViewModel(IApriori apriori)
        {
            _items = new ObservableSet<Item>();
            _transactions = new ObservableCollection<string>();
            this._apriori = apriori;
        }

        #endregion

        #region Public Properties

        public string NewItem
        {
            get { return _newItem; }
            set
            {
                if (_newItem != value)
                {
                    _newItem = value;
                    OnPropertyChanged("NewItem");
                }
            }
        }

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public ObservableSet<Item> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        public ObservableCollection<string> Transactions
        {
            get { return _transactions; }
            set
            {
                if (_transactions != value)
                {
                    _transactions = value;
                    OnPropertyChanged("Transactions");
                }
            }
        }

        public string SelectedTransaction
        {
            get { return _selectedTransaction; }
            set
            {
                if (_selectedTransaction != value)
                {
                    _selectedTransaction = value;
                    OnPropertyChanged("SelectedTransaction");
                }
            }
        }

        public double MinSupport
        {
            get { return _minSupport; }
            set
            {
                if (_minSupport != value)
                {
                    _minSupport = value;
                    OnPropertyChanged("MinSupport");
                }
            }
        }

        public double MinConfidence
        {
            get { return _minConfidence; }
            set
            {
                if (_minConfidence != value)
                {
                    _minConfidence = value;
                    OnPropertyChanged("MinConfidence");
                }
            }
        }

        public string Error
        {
            get { return _error; }
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged("Error");
                }
            }
        }

        #endregion Public Properties

        #region Commands

        public ICommand AddItem
        {
            get { return new RelayCommand(AddItemExecute, CanAddItemExecute); }
        }

        public ICommand RemoveItem
        {
            get { return new RelayCommand(RemoveItemExecute, () => SelectedItem != null); }
        }

        public ICommand AddTransaction
        {
            get { return new RelayCommand(AddTransactionExecute, CanAddTransactionExecute); }
        }

        public ICommand DeleteTransaction
        {
            get { return new RelayCommand(DeleteTransactionExecute, () => SelectedTransaction != null); }
        }

        public ICommand ClearAllTransactions
        {
            get { return new RelayCommand(ClearAllTransactionsExecute, () => true); }
        }

        public ICommand ProcessTransactions
        {
            get { return new RelayCommand(ProcessTransactionsExecute, () => Transactions.Count != 0); }
        }

        #endregion Commands

        #region Commands Methods

        private void AddItemExecute()
        {
            Items.Add(new Item { Name = NewItem[0] });
            NewItem = string.Empty;
        }

        private bool CanAddItemExecute()
        {
            CharacterOnlyRule characterOnlyRule = new CharacterOnlyRule();
            var validationResult = characterOnlyRule.Validate(NewItem, System.Globalization.CultureInfo.CurrentCulture);

            return validationResult.IsValid;
        }

        private void RemoveItemExecute()
        {
            if (SelectedItem != null)
            {
                if (CheckItemIsInTransaction())
                {
                    Error = "Item present in a transaction, cannot delete";
                }
                else
                {
                    Error = string.Empty;
                    Items.Remove(SelectedItem);
                }
            }
        }

        private void AddTransactionExecute()
        {
            var selectedItems = Items.Where(i => i.Selected).Select(i => i.Name);
            Transactions.Add(new string(selectedItems.ToArray()));
        }

        private bool CanAddTransactionExecute()
        {
            var selectedItems = Items.Where(i => i.Selected);
            return selectedItems.Count() != 0;
        }

        private void DeleteTransactionExecute()
        {
            Transactions.Remove(SelectedTransaction);
        }

        private void ClearAllTransactionsExecute()
        {
            Transactions.Clear();
        }

        private void ProcessTransactionsExecute()
        {
            IEnumerable<string> items = Items.Select(t => t.Name.ToString());
            Output output = _apriori.ProcessTransaction(MinSupport / 100, MinConfidence / 100, items, Transactions.ToArray());

            Result result = new Result(output);
            result.Show();
        }

        #endregion

        #region Helper Methods

        private bool CheckItemIsInTransaction()
        {
            foreach (var item in Transactions)
            {
                if (item.Contains(SelectedItem.Name))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}