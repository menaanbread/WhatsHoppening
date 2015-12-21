using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatsHoppening.Extensions;

namespace WhatsHoppening.Tests.Extensions
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void Test_FormatWith_WithOneParameter_PutsParameterInStringCorrectly()
        {
            var expectedResult = "Hello world!";

            var actualResult = "Hello {0}!".FormatWith("world");

            Assert.AreEqual(expectedResult, actualResult, string.Format("The expected [{0}] didn't match the actual [{1}]", expectedResult, actualResult));
        }

        [TestMethod]
        public void Test_FormatWith_WithMoreInputThanOutputParameters_IgnoresTheExtraParameters()
        {
            var expectedResult = "Hello world!";

            var actualResult = "Hello {0}!".FormatWith("world", "some wrong stuff");

            Assert.AreEqual(expectedResult, actualResult, string.Format("The expected [{0}] didn't match the actual [{1}]", expectedResult, actualResult));
        }
    }
}
