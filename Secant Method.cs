using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalAnalysis
{
    class SecanMethod
    {
        static void Main(string[] args)
        {
            Console.Write("\nInput the lower range of 'X' below = ");
            double x_zero = Convert.ToDouble(Console.ReadLine());

            Console.Write("Input the upper range of 'X' below = ");
            double x_n = Convert.ToDouble(Console.ReadLine());

            Console.Write("Input the relative tolerance/error(%) = ");
            double error_lim = Convert.ToDouble(Console.ReadLine());

            Console.Write("Input the iteration number as required = ");
            double iteration = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("\n");
            double x_r, error = error_lim + 1;

            x_r = Iteration(x_zero, x_n, error, error_lim, iteration);
            Console.WriteLine("After calculating with  given tolerance/error and decimal limit,\nthe root value is {0}.\n", Math.Round(x_r, 2));
           
            Console.ReadKey();
        }
        public static double Function(double x)
        {
            return (Math.Pow(x, 4) - x - 10);        //function f(x)  
        }
        public static double Iteration(double x_zero, double x_n, double error, double error_lim, double limit)
        {
            int i = 1;
            double x_r, x_previous = 0, lFunc, uFunc;
            do
            {
                lFunc = Function(x_zero); //storing function value for  x_i-1
                uFunc = Function(x_n);  //storing function value  for  x_i
                x_r = x_n - ((uFunc * (x_n - x_zero)) / (uFunc - lFunc));     //formula for secant method
                Console.WriteLine("Iteration no. {0}:\n", i);


                i++;
                Console.WriteLine("The  value x{0} is: {1}", i, Math.Round(x_r, 2));

                x_previous = x_n;
                error = Error(x_r, x_previous);
                Console.WriteLine("The approximate relative tolerance/error is {0}%.\n", Math.Round(error,2));
                
                Console.WriteLine("The lower limit is {0} & the upper limit is {1}.\n", Math.Round(x_zero,2), Math.Round(x_n,2));

                x_zero = x_n;
                x_n = Math.Round(x_r, 2);
            } while (error > error_lim && i <= limit);  //conditions for stopping the calculation with given error & iteration limit
            return Math.Round(x_r, 2);
        }
        public static double Error(double x_present, double x_previous)
        {
            return Math.Abs((x_present - x_previous) / x_present) * 100;  //formula of relative tolerance
        }
    }
}
