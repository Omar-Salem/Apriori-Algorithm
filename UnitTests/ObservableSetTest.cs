using WPFClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass()]
    public class ObservableSetTest
    {
        [TestMethod()]
        public void InsertItemTest()
        {
            //Arrange
            ObservableSet<string> target = new ObservableSet<string>();
            var item = "Item";

            //Act
            target.Add(item);
            target.Add(item);

            //Assert
            Assert.AreEqual(1, target.Count);

        }
    }
}