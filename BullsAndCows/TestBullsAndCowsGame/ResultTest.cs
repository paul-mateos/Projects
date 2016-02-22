using BullsAndCows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBullsAndCowsGame
{
    [TestClass]
    public class ResultTest
    {
        private const string INCORRECT_RESULT_MSG = "Incorrect bool result return." +
                                                   " The result should be equal!";
        [TestMethod]
        public void TestResultConstructor()
        {
            int expectedBulls = 2;
            int expectedCows = 1;
            Result result = new Result(expectedBulls, expectedCows);
            bool areBullsEqual = expectedBulls == result.Bulls;
            bool areCowsEqual = expectedCows == result.Cows;

            bool expected = true;
            bool actual = areBullsEqual && areCowsEqual;

            Assert.AreEqual<bool>(actual, expected,
                                  "Incorrect intialization of result object!");
        }

        [TestMethod]
        public void TestEqualNull()
        {
            Result firstResult = new Result(1, 2);
            Result secondResult = null;

            bool expected = false;
            bool actual = firstResult.Equals(secondResult);

            Assert.AreEqual<bool>(expected, actual,
                                  INCORRECT_RESULT_MSG);
        }

        [TestMethod]
        public void TestEqualSameResults()
        { 
            Result firstResult = new Result(1, 2);
            Result secondResult = new Result(1, 2);

            bool expected = true;
            bool actual = firstResult.Equals(secondResult);

            Assert.AreEqual<bool>(expected, actual,
                                  INCORRECT_RESULT_MSG);
        }

        [TestMethod]
        public void TestEqualWithDifferentCountOfCows()
        {
            Result firstResult = new Result(1, 1);
            Result secondResult = new Result(1, 2);

            bool expected = false;
            bool actual = firstResult.Equals(secondResult);

            Assert.AreEqual<bool>(expected, actual,
                                  INCORRECT_RESULT_MSG);
        }

        [TestMethod]
        public void TestEqualWithDifferentCountOfBulls()
        {
            Result firstResult = new Result(2, 1);
            Result secondResult = new Result(1, 1);

            bool expected = false;
            bool actual = firstResult.Equals(secondResult);

            Assert.AreEqual<bool>(expected, actual,
                                  INCORRECT_RESULT_MSG);
        }

        [TestMethod]
        public void TestToString()
        {
            Result result = new Result(2, 1);
            
            string expected = "Wrong number! Bulls: 2, Cows: 1";
            string actual = result.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    "Incorrect string of the object!");
        }
    }
}