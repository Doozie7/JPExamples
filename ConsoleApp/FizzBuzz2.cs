using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JPExamples
{
    public class FizzBuzz2
    {

        private List<string> _results;

        public static string Evaluate(int value)
        {
            if (value.ToString().Contains("3"))
            {
                return "lucky";
            }

            if (value % 15 == 0)
            {
                return "fizzbuzz";
            }
            if (value % 3 == 0)
            {
                return "fizz";
            }
            if (value % 5 == 0)
            {
                return "buzz";
            }

            return value.ToString();
        }

        public FizzBuzz2 Evaluate(int startInteger, int endInteger)
        {
            if (startInteger > endInteger)
            {
                throw new ArgumentException(
                    "The startInteger needs to be smaller than the endInteger when running the EvaluateAndReport method.");
            }

            _results = new List<string>();

            var tooEvaluate = startInteger;
            do
            {
                var fbe = Evaluate(tooEvaluate);
                _results.Add(fbe);
                tooEvaluate++;

            } while (tooEvaluate <= endInteger);

            return this;
        }

        public override string ToString()
        {
            if (_results == null)
            {
                throw new InvalidOperationException("ToString can only be called after Evaluate(start, end) has been called on an instance of FizzBuzz2.");
            }
            return string.Join(" ", _results);
        }

        public string WithSummary()
        {
            var pretty = ToString();

            var integerCount = Regex.Matches(pretty, "[0-9] ").Count;
            var fizzCount = Regex.Matches(pretty, "fizz ").Count;
            var buzzCount = Regex.Matches(pretty, "buzz ").Count;
            var fizzbuzzCount = Regex.Matches(pretty, "fizzbuzz ").Count;
            var luckyCount = Regex.Matches(pretty, "lucky ").Count;

            return string.Format(
                $"{pretty} fizz: {fizzCount} buzz: {buzzCount} fizzbuzz: {fizzbuzzCount} lucky: {luckyCount} integer: {integerCount}");
        }
    }
}
