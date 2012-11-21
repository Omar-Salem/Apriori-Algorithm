using WPFClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace UnitTests
{
    [TestClass()]
    public class CharacterOnlyRuleTest
    {
        [TestMethod()]
        public void ValidateInput_Test()
        {
            //Arrange
            CharacterOnlyRule target = new CharacterOnlyRule();
            object value = "abcd";
            CultureInfo cultureInfo = null;

            //Act
            ValidationResult actual = target.Validate(value, cultureInfo);

            //Assert
            Assert.IsTrue(actual.IsValid);
        }

        [TestMethod()]
        public void InValidateInput_Test()
        {
            //Arrange
            CharacterOnlyRule target = new CharacterOnlyRule();
            object value = "321780/";
            CultureInfo cultureInfo = null;

            //Act
            ValidationResult actual = target.Validate(value, cultureInfo);

            //Assert
            Assert.IsFalse(actual.IsValid);
        }
    }
}