using ImportFile.Domain.Common.Extensions;
using Xunit;

namespace ImportFile.Tests.Application
{
    public class StringToDoubleExtensionTest
    {
        [Fact]
        public void ToDouble_With_Valid_Integer_Success()
        {
            //arrange
            var doubleString = "10,50";
            //act
            var result = doubleString.ToDouble();
            //assert
            Assert.Equal(10.50, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalidInput")]
        public void ToDouble_With_Invalid_Integer_Should_Return_Success(string input)
        {
            //act
            var result = input.ToDouble();
            //assert
            Assert.Equal(0, result);
        }
    }
}