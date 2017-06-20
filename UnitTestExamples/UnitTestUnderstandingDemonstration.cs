using System.Collections.Generic;
using System.Text.RegularExpressions;
using JPExamples;
using NUnit.Framework;

namespace UnitTestExamples
{
    [TestFixture]
    public class UnitTestUnderstandingDemonstration
    {
        // test the following cases
        // the number
        // ‘fizz’ for numbers that are multiples of 3
        // ‘buzz’ for numbers that are multiples of 5
        // ‘fizzbuzz’ for numbers that are multiples of 15
        // e.g.
        //1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz

        #region replaced_in_step2
        //[TestCase(3, ExpectedResult = "fizz")]
        //[TestCase(int.MaxValue, ExpectedResult = "2147483647")]
        //[TestCase(int.MinValue, ExpectedResult = "-2147483648")]
        #endregion

        [TestCase(0, ExpectedResult = "fizzbuzz")]
        [TestCase(1, ExpectedResult = "1")]
        [TestCase(2, ExpectedResult = "2")]
        [TestCase(3, ExpectedResult = "lucky")]
        [TestCase(4, ExpectedResult = "4")]
        [TestCase(5, ExpectedResult = "buzz")]
        [TestCase(6, ExpectedResult = "fizz")]
        [TestCase(13, ExpectedResult = "lucky")]
        [TestCase(15, ExpectedResult = "fizzbuzz")]
        [TestCase(20, ExpectedResult = "buzz")]
        [TestCase(30, ExpectedResult = "lucky")]
        [TestCase(int.MaxValue, ExpectedResult = "lucky")]
        [TestCase(int.MinValue, ExpectedResult = "lucky")]
        public string FizzBuzz_method_should_return_when_passed(int numberToTest)
        {
            //Arrange
            var responder = FizzBuzz2.Evaluate(numberToTest);

            //Act
            const string regexpattern = @"[0-9|fizz|buzz]";
            var r = new Regex(regexpattern, RegexOptions.IgnoreCase);
            var m = r.Match(responder);

            //Assert
            Assert.NotNull(responder);
            Assert.AreEqual(true, m.Success);

            //Now send the test output back to NUnit
            return responder;
        }

        [TestCase]
        [Ignore("This was a step 1 test and will not work for step 2.")]
        public void FizzBuzz_should_return_known_string()
        {
            //Arrange
            var results = new List<string>();

            //Act
            for (var i = 1; i < 21; i++)
            {
                results.Add(FizzBuzz2.Evaluate(i));
            }

            var pretty = string.Join(" ", results);

            //Assert
            Assert.AreEqual(pretty, "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz");
        }

        [TestCase]
        public void FizzBuzz_should_return_known_string_step2()
        {
            //Arrange
            var results = new List<string>();

            //Act
            for (var i = 1; i < 21; i++)
            {
                results.Add(FizzBuzz2.Evaluate(i));
            }

            var pretty = string.Join(" ", results);

            //Assert
            Assert.AreEqual(pretty, "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz");
        }

        [Test]
        public void Test_count_numbers()
        {
            //Arrange
            var example = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            //Act
            var integerCount = Regex.Matches(example, "[0-9] ").Count;
            //Assert
            Assert.AreEqual(integerCount, 10);
        }

        [Test]
        public void Test_count_fizz()
        {
            //Arrange
            var example = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            //Act
            var fizzCount = Regex.Matches(example, "fizz ").Count;
            //Assert
            Assert.AreEqual(fizzCount, 4);
        }

        [Test]
        public void Test_count_buzz()
        {
            //Arrange
            var example = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            //Act
            var buzzCount = Regex.Matches(example, "buzz ").Count;
            //Assert
            Assert.AreEqual(buzzCount, 3);
        }

        [Test]
        public void Test_count_fizzbuzz()
        {
            //Arrange
            var example = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            //Act
            var fizzbuzzCount = Regex.Matches(example, "fizzbuzz ").Count;
            //Assert
            Assert.AreEqual(fizzbuzzCount, 1);
        }

        [Test]
        public void Test_count_lucky()
        {
            //Arrange
            var example = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz";
            //Act
            var luckyCount = Regex.Matches(example, "lucky ").Count;
            //Assert
            Assert.AreEqual(luckyCount, 2);
        }

        [TestCase]
        public void FizzBuzz_should_return_known_string_final()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz2();
            //Act
            var results = fizzBuzz.Evaluate(1, 20).ToString();

            //Assert
            Assert.AreEqual(results,
                "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz");
        }

        [TestCase]
        public void FizzBuzz_should_return_known_string_and_summary()
        {
            //Arrange
            var fizzBuzz = new FizzBuzz2();
            //Act
            var results = fizzBuzz.Evaluate(1, 20).WithSummary();

            //Assert
            Assert.AreEqual(results,
                "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz fizz: 4 buzz: 3 fizzbuzz: 1 lucky: 2 integer: 10");
        }
    }
}
