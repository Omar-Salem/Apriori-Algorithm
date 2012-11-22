using AprioriAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass()]
    public class SorterTest
    {
        [TestMethod()]
        public void SortTest()
        {
            //Arrange
            ISorter target = new Sorter();
            var token = "cba";

            //Act
            var actual = target.Sort(token);

            //Assert
            Assert.AreEqual(actual, "abc");
        }
    }
}