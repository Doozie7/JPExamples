using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPExamples
{
    public class FizzBuzz
    {
        public void Execute()
        {

            // Problem
            // Write a program that prints the numbers from 1 to 100. 
            // But for multiples of three print "Fizz" instead of the number and for the multiples of five print "Buzz". 
            // For numbers which are multiples of both three and five print "FizzBuzz".
            
            Enumerable.Range(1, 100).ToList().ForEach(i =>
            Console.WriteLine(
                (i % 3 == 0 && i % 5 == 0) ? "FizzBuzz" :
                (i % 5 == 0) ? "Buzz" :
                (i % 3 == 0) ? "Fizz" :
                i.ToString()
                        )
                    );

            //for (int i = 1; i <= 100; i++)
            //{
            //    string fizz = (i % 3 == 0 ? "Fizz" : "");
            //    string buzz = (i % 5 == 0 ? "Buzz" : "");
            //    string number = i.ToString();
            //    if (fizz.Length > 0 || buzz.Length > 0)
            //    {
            //        number = string.Empty;
            //    }
            //    Console.WriteLine("{0}{1}{2}", fizz, buzz, number);
            //}

            Console.ReadLine();
        }
    }
}
