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

        readonly Mock<AprioriAlgorithm.IApriori> aprioriMock;
        readonly MainViewModel target;

        #endregion

        #region Constructor

        public MainViewModelTest()
        {
            aprioriMock = new Mock<AprioriAlgorithm.IApriori>();
            target = new MainViewModel(aprioriMock.Object);
        }

        #endregion

        #region TestMethods

        [TestMethod()]
        public void AddItemTest()
        {
            //Arrange
            target.NewItem = "a";

            //Act
            target.AddItem.Execute(null);

            //Assert
            Assert.AreEqual(1, target.Items.Count);
        }

        [TestMethod()]
        public void RemoveItemTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a' };
            var itemB = new Item { Name = 'b' };

            target.Items = new ObservableSet<Item> { itemA, itemB };

            //Act
            target.SelectedItem = itemA;
            target.RemoveItem.Execute(null);

            //Assert
            Assert.AreEqual(1, target.Items.Count);
            Assert.AreEqual(itemB.Name, target.Items[0].Name);
        }

        [TestMethod()]
        public void RemoveItemInTransactionTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a' };
            var itemB = new Item { Name = 'b' };
            target.Items = new ObservableSet<Item> { itemA, itemB };
            var transaction = itemA.Name + "" + itemB.Name;
            target.Transactions = new ObservableCollection<string> { transaction };

            //Act
            target.SelectedItem = itemA;
            target.RemoveItem.Execute(null);

            //Assert
            Assert.AreEqual(2, target.Items.Count);
            Assert.AreNotEqual(string.Empty, target.Error);
        }

        [TestMethod()]
        public void AddTransactionTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a', Selected = true };
            var itemB = new Item { Name = 'b' };
            var itemC = new Item { Name = 'c', Selected = true };

            target.Items = new ObservableSet<Item> { itemA, itemB, itemC };

            //Act
            target.AddTransaction.Execute(null);

            //Assert
            Assert.AreEqual(1, target.Transactions.Count);
            Assert.AreEqual("ac", target.Transactions[0]);
        }

        [TestMethod()]
        public void CanAddTransactionWhenNoItemsSelectedTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a' };
            var itemB = new Item { Name = 'b' };

            target.Items = new ObservableSet<Item> { itemA, itemB };

            //Assert
            Assert.IsFalse(target.AddTransaction.CanExecute(null));
        }

        [TestMethod()]
        public void CanAddTransactionTest()
        {
            //Arrange
            var itemA = new Item { Name = 'a', Selected = true };
            var itemB = new Item { Name = 'b' };

            target.Items = new ObservableSet<Item> { itemA, itemB };

            //Assert
            Assert.IsTrue(target.AddTransaction.CanExecute(null));
        }

        [TestMethod()]
        public void DeleteTransactionTest()
        {
            //Arrange
            var transaction = "ab";
            target.Transactions = new ObservableCollection<string> { transaction, "cd" };

            //Act
            target.SelectedTransaction = transaction;
            target.DeleteTransaction.Execute(null);

            //Assert
            Assert.AreEqual(1, target.Transactions.Count);
        }

        [TestMethod()]
        public void ClearAllTransactionsTest()
        {
            //Arrange
            var transaction = "ab";
            target.Transactions = new ObservableCollection<string> { transaction, "cd" };

            //Act
            target.SelectedTransaction = transaction;
            target.ClearAllTransactions.Execute(null);

            //Assert
            Assert.AreEqual(0, target.Transactions.Count);
        }

        [TestMethod()]
        public void ProcessTransactionsTest()
        {
            //Arrange
            var items = target.Items.Select(t => t.Name.ToString());

            //Act
            target.ProcessTransactions.Execute(null);

            //Assert
            aprioriMock.Verify(a => a.ProcessTransaction(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<IEnumerable<string>>(), It.IsAny<string[]>()), Times.Once());

        }

        [TestMethod()]
        public void CanRemoveItemWhenSelectedItemIsNull()
        {
            //Act
            target.RemoveItem.Execute(null);

            //Assert
            Assert.IsFalse(target.RemoveItem.CanExecute(null));
        }

        [TestMethod()]
        public void CanDeleteTransactionWhenSelectedTransactionIsNull()
        {
            //Act
            target.DeleteTransaction.Execute(null);

            //Assert
            Assert.IsFalse(target.DeleteTransaction.CanExecute(null));
        }

        #endregion
    }
}