using EmployeesApp.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EmployeesApp.Tests.Validation
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidation _validation;
        public AccountNumberValidationTests()
        {
            _validation = new AccountNumberValidation();
        }

        [Fact]
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("123-4543234576-23"));
        }
        //[Fact]
        //public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse()
        //{
        //    Assert.False(_validation.IsValid("1234-3454565676-25"));
        //}
        [Theory]
        [InlineData("1234-3454565676-25")]
        [InlineData("12-34546565676-23")]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }
        [Theory]
        [InlineData("123-345456567-24")]
        [InlineData("123-345456567622-25")]
        public void IsValid_AccountNumberMiddlePartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }
        [Theory]
        [InlineData("123-345456567633=23")]
        [InlineData("123+345456567633-23")]
        [InlineData("123+345456567633=23")]
        public void IsValid_InvalidDelimiters_ThrowsArgumentException(string accountNumber)
        {
            Assert.Throws<ArgumentException>(() => _validation.IsValid(accountNumber));
        }
    }
}
