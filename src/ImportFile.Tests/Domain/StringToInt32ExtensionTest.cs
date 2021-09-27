using ImportFile.Domain.Common.Extensions;
using Xunit;

namespace ImportFile.Tests.Application
{
    public class StringToInt32ExtensionTest
    {
        [Fact]
        public void ToInt32_With_Valid_Integer_Success()
        {
            //arrange
            var intString = "10";
            //act
            var result = intString.ToInt32();
            //assert
            Assert.Equal(10, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalidInput")]
        public void ToInt32_With_Invalid_Integer_Should_Return_Success(string input)
        {
            //act
            var result = input.ToInt32();
            //assert
            Assert.Equal(0, result);
        }
    }
}