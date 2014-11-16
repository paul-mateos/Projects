using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestTime
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void TestEqualsObjectEqualTimes()
        {
            int hours = 4; 
            int minutes = 12; 
            Time firstTime = new Time(hours, minutes);
            object obj = new Time(hours, minutes); 

            bool expected = true; 
            bool actual = firstTime.Equals(obj);

            Assert.AreEqual<bool>(expected, actual,
                            "There was a problem in comparing times.");       
        }

        [TestMethod]
        public void TestEqualsObjectNotEqualTimes()
        {
            int hours = 4;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);
            object obj = new Time(hours, minutes + 5);

            bool expected = false;
            bool actual = firstTime.Equals(obj);

            Assert.AreEqual(expected, actual,
                            "There was a problem in comparing times.");
        }

        [TestMethod]
        public void TestEqualObjectNull()
        {
            int hours = 4;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);
            object obj = null;

            bool expected = false;
            bool actual = firstTime.Equals(obj);

            Assert.AreEqual(expected, actual,
                            "There was a problem in comparing times.");
        }

        [TestMethod]
        public void TestEqualsEqualTimes()
        {
            int hours = 4;
            int minutes = 12;
            Time firstTime = new Time(hours, minutes);
            Time secondTime = new Time(hours, minutes);

            bool expected = true;
            bool actual = firstTime.Equals(secondTime);

            Assert.AreEqual(expected, actual,
                            "There was a problem in comparing times.");
        }

        [TestMethod]
        public void TestEqualsNotEqualTimes()
        {
            int hours = 4;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);
            Time secondTime = new Time(hours, minutes + 5);

            bool expected = false;
            bool actual = firstTime.Equals(secondTime);

            Assert.AreEqual(expected, actual,
                            "There was a problem in comparing times.");
        }

        [TestMethod]
        public void TestEqualNull()
        {
            int hours = 4;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);
            Time secondTime = null;

            bool expected = false;
            bool actual = firstTime.Equals(secondTime);

            Assert.AreEqual(expected, actual,
                            "There was a problem in comparing times.");
        }

        [TestMethod]
        public void TestTimeConstructorAreMinutesCorrect()
        {
            int hours = 4;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);

            int expected = minutes;
            int actual = firstTime.Minutes;

            Assert.AreEqual<int>(actual, expected,
                                 "There was a problem in initialazing the minutes.");
        }

        [TestMethod]
        public void TestTimeConstructorAreHoursCorrect()
        {
            int hours = 4;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);

            int expected = hours;
            int actual = firstTime.Hours;

            Assert.AreEqual<int>(actual, expected,
                                 "There was a problem in initialazing the hours.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "When tried to initialize properties" +
                           " with too big hour it didn't throw an exception!")]
        public void TestTimeConstructorWithTooBigHour()
        {
            int hours = 25;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "When tried to initialize properties with" +
                           " negativ hour it didn't throw an exception!")]
        public void TestTimeConstructorWithNegativHour()
        {
            int hours = -5;
            int minutes = 20;
            Time firstTime = new Time(hours, minutes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "When tried to initialize properties with too big" +
                           " amount of minutes it didn't throw an exception!")]
        public void TestTimeConstructorWithTooBigAmountMinutes()
        {
            int hours = 3;
            int minutes = 69;
            Time firstTime = new Time(hours, minutes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "When tried to initialize properties with negativ" +
                           " amount of minutes it didn't throw an exception!")]
        public void TestTimeConstructorWithNegativAmountMinutes()
        {
            int hours = 3;
            int minutes = -69;
            Time firstTime = new Time(hours, minutes);
        }

        [TestMethod()]
        public void TestGetHashCodeEqualObjects()
        {
            int hours = 4;
            int minutes = 12;
            Time firstTime = new Time(hours, minutes);
            object secondTime = new Time(hours, minutes);

            int firstTimeHashCode = firstTime.GetHashCode();
            int secondTimeHashCode = secondTime.GetHashCode();

            Assert.AreEqual<int>(firstTimeHashCode, secondTimeHashCode,
                                 "There was a problem calculating the hashcode of times.");
        }

        [TestMethod]
        public void TestGetHashCodeDifferentObjects()
        {
            int previousTimeHashCode = 0;
            int sameHashcodesCount = 0;
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    Time currentTime = new Time(i, j);
                    int currentTimeHashCode = currentTime.GetHashCode();
                    if (previousTimeHashCode == currentTimeHashCode)
                    {
                        sameHashcodesCount++;
                    }
                    previousTimeHashCode = currentTimeHashCode;
                }
            }
            if (sameHashcodesCount > 5)
            {
                Assert.Fail("Too much hashcodes are same!");
            }
        }

        [TestMethod()]
        public void TestToString()
        {
            int hours = 4;
            int minutes = 12;
            Time firstTime = new Time(hours, minutes);

            string expected = String.Format("{0:00}:{1:00}", hours, minutes); 
            string actual = firstTime.ToString();

            Assert.AreEqual<string>(expected, actual,
                                    "There was a problem in" +
                                    " creating a correct string of time object!");
        }

        [TestMethod]
        public void TestAdditionNormalValues()
        {
            Time givenTime = new Time(13, 10);
            int givenMinutes = 30;

            Time expected = new Time(13, 40); 
            Time actual = (givenTime + givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in addition of times!");
        }

        [TestMethod]
        public void TestAdditionIncreaseHour()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = 30;

            Time expected = new Time(14, 10);
            Time actual = (givenTime + givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in addition of times!");
        }

        [TestMethod]
        public void TestAdditionWithMoreThan60Minutes()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = 120;

            Time expected = new Time(15, 40);
            Time actual = (givenTime + givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in addition of times!");
        }

        [TestMethod]
        public void TestAdditionWithNegativAmountOfMinutes()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = -10;

            Time expected = new Time(13, 30);
            Time actual = (givenTime + givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in addition of times!");
        }

        [TestMethod]
        public void TestAdditionWhen23Hour59MinutesPlus10Minutes()
        {
            Time givenTime = new Time(23, 59);
            int givenMinutes = 10;

            Time expected = new Time(0, 9);
            Time actual = (givenTime + givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in addition of times!");
        }

        [TestMethod]
        public void TestAdditionWith0Mintes()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = 0;

            Time expected = new Time(13, 40);
            Time actual = (givenTime + givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in addition of times!");
        }

        [TestMethod]
        public void TestSubtractionNormalValues()
        {
            Time givenTime = new Time(13, 10);
            int givenMinutes = 5;

            Time expected = new Time(13, 5);
            Time actual = (givenTime - givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Subtraction of times!");
        }

        [TestMethod]
        public void TestSubtractionDecreaseHours()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = 50;

            Time expected = new Time(12, 50);
            Time actual = (givenTime - givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Subtraction of times!");
        }

        [TestMethod]
        public void TestSubtractionWithMoreThan60Minutes()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = 120;

            Time expected = new Time(11, 40);
            Time actual = (givenTime - givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Subtraction of times!");
        }

        [TestMethod]
        public void TestSubtractionWithNegativAmountOfMinutes()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = -10;

            Time expected = new Time(13, 50);
            Time actual = (givenTime - givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Subtraction of times!");
        }

        [TestMethod]
        public void TestSubtractionWhen0Hour10MinutesMinus20Minutes()
        {
            Time givenTime = new Time(0, 10);
            int givenMinutes = 20;

            Time expected = new Time(23, 50);
            Time actual = (givenTime - givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Subtraction of times!");
        }

        [TestMethod]
        public void TestSubtractionWith0Mintes()
        {
            Time givenTime = new Time(13, 40);
            int givenMinutes = 0;

            Time expected = new Time(13, 40);
            Time actual = (givenTime - givenMinutes);

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in subtraction of times!");
        }

        [TestMethod]
        public void TestIncrementNormalValuesPrefixIncrement()
        {
            Time givenTime = new Time(13, 40);        
            
            Time expected = new Time(13, 41);
            Time actual = ++givenTime;

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in increment of time!");
        }

        [TestMethod]
        public void TestIncrementNormalValuesSufixIncrement()
        {
            Time givenTime = new Time(13, 40);

            Time expected = new Time(13, 40);
            Time actual = givenTime++;
            
            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in increment of time!");
        }

        [TestMethod]
        public void TestIncrementWith59Minutes()
        {
            Time givenTime = new Time(13, 59);

            Time expected = new Time(14, 00);
            Time actual = ++givenTime;

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in increment of time!");
        }

        [TestMethod]
        public void TestDecrementNormalValuesPrefixIncrement()
        {
            Time givenTime = new Time(13, 40);

            Time expected = new Time(13, 39);
            Time actual = --givenTime;

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Decrement of time!");
        }

        [TestMethod]
        public void TestDecrementNormalValuesSufixIncrement()
        {
            Time givenTime = new Time(13, 40);

            Time expected = new Time(13, 40);
            Time actual = givenTime--;

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Decrement of time!");
        }

        [TestMethod]
        public void TestDecrementWith59Minutes()
        {
            Time givenTime = new Time(14, 00);

            Time expected = new Time(13, 59);
            Time actual = --givenTime;

            Assert.AreEqual<Time>(expected, actual,
                                  "There was a problem in Decrement of time!");
        }
    }
}

