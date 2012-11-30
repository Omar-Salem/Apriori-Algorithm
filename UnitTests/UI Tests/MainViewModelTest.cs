using WPFClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass()]
    public class MainViewModelTest
    {
        #region Member Variables

        readonly Mock<AprioriAlgorithm.IApriori> _aprioriMock;
        readonly Mock<IResult> _resultWindowMock;
        readonly MainViewModel _target;

        #endregion

        #region Constructor

        public MainViewModelTest()
        {
            _aprioriMock = new Mock<AprioriAlgorithm.IApriori>();
            _resultWindowMock = new Mock<IResult>();
            _target = new MainViewModel(_aprioriMock.Object, _resultWindowMock.Object);
        }

        #endregion

        #region TestMethods

        [TestMethod()]
        public void AddItemTest()
        {
            //Arrange
            _target.NewItem = "a";

            //Act
            _target.AddItem.Execute(null);

            //Assert
            Assert.AreEqual(1, _target.Items.Count);
        }

        [TestMethod()]
        public void RemoveItemTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a' };
            var itemB = new Item { Name = 'b' };

            _target.Items = new ObservableSet<Item> { itemA, itemB };

            //Act
            _target.SelectedItem = itemA;
            _target.RemoveItem.Execute(null);

            //Assert
            Assert.AreEqual(1, _target.Items.Count);
            Assert.AreEqual(itemB.Name, _target.Items[0].Name);
        }

        [TestMethod()]
        public void RemoveItemInTransactionTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a' };
            var itemB = new Item { Name = 'b' };
            _target.Items = new ObservableSet<Item> { itemA, itemB };
            string transaction = itemA.Name + "" + itemB.Name;
            _target.Transactions = new ObservableCollection<string> { transaction };

            //Act
            _target.SelectedItem = itemA;
            _target.RemoveItem.Execute(null);

            //Assert
            Assert.AreEqual(2, _target.Items.Count);
            Assert.AreNotEqual(string.Empty, _target.Error);
        }

        [TestMethod()]
        public void AddTransactionTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a', Selected = true };
            var itemB = new Item { Name = 'b' };
            var itemC = new Item { Name = 'c', Selected = true };

            _target.Items = new ObservableSet<Item> { itemA, itemB, itemC };

            //Act
            _target.AddTransaction.Execute(null);

            //Assert
            Assert.AreEqual(1, _target.Transactions.Count);
            Assert.AreEqual("ac", _target.Transactions[0]);
        }

        [TestMethod()]
        public void CanAddTransactionWhenNoItemsSelectedTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a' };
            var itemB = new Item { Name = 'b' };

            _target.Items = new ObservableSet<Item> { itemA, itemB };

            //Assert
            Assert.IsFalse(_target.AddTransaction.CanExecute(null));
        }

        [TestMethod()]
        public void CanAddTransactionTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a', Selected = true };
            var itemB = new Item { Name = 'b' };

            _target.Items = new ObservableSet<Item> { itemA, itemB };

            //Assert
            Assert.IsTrue(_target.AddTransaction.CanExecute(null));
        }

        [TestMethod()]
        public void DeleteTransactionTest()
        {
            //Arrange
            var transaction = "ab";
            _target.Transactions = new ObservableCollection<string> { transaction, "cd" };

            //Act
            _target.SelectedTransaction = transaction;
            _target.DeleteTransaction.Execute(null);

            //Assert
            Assert.AreEqual(1, _target.Transactions.Count);
        }

        [TestMethod()]
        public void ClearAllTransactionsTest()
        {
            //Arrange
            var transaction = "ab";
            _target.Transactions = new ObservableCollection<string> { transaction, "cd" };

            //Act
            _target.SelectedTransaction = transaction;
            _target.ClearAllTransactions.Execute(null);

            //Assert
            Assert.AreEqual(0, _target.Transactions.Count);
        }

        [TestMethod()]
        public void ProcessTransactionsTest()
        {
            //Arrange
            IEnumerable<string> items = _target.Items.Select(t => t.Name.ToString());
            string[] transactionsList = _target.Transactions.ToArray();

            //Act
            _target.ProcessTransactions.Execute(null);

            //Assert
            _aprioriMock.Verify(a => a.ProcessTransaction(_target.MinSupport / 100, _target.MinConfidence / 100, items, transactionsList), Times.Once());
            _resultWindowMock.Verify(r => r.Show(It.IsAny<AprioriAlgorithm.Output>()), Times.Once());

        }

        [TestMethod()]
        public void CanRemoveItemWhenSelectedItemIsNull()
        {
            //Act
            _target.RemoveItem.Execute(null);

            //Assert
            Assert.IsFalse(_target.RemoveItem.CanExecute(null));
        }

        [TestMethod()]
        public void CanDeleteTransactionWhenSelectedTransactionIsNull()
        {
            //Act
            _target.DeleteTransaction.Execute(null);

            //Assert
            Assert.IsFalse(_target.DeleteTransaction.CanExecute(null));
        }

        #endregion
    }
}