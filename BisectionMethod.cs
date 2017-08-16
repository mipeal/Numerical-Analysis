using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisection_Method
{
    class BisectionMethod
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("\nInput the lower range of 'X' below = ");
                double x_low = Convert.ToDouble(Console.ReadLine());

                Console.Write("Input the upper range of 'X' below = ");
                double x_up = Convert.ToDouble(Console.ReadLine());

                Console.Write("Input the relative tolerance/error(%) = ");
                double error_lim = Convert.ToDouble(Console.ReadLine());

                Console.Write("Input the iteration number as required = ");
                double iteration = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\n");
                double root, error = error_lim + 1;

                if (Function(x_low) * Function(x_up) < 0)     //by checkning the multiplication of lower & upper range functions we're checking if there's any root in the range
                {
                    root = Iteration(x_low, x_up, error, error_lim, iteration);
                    Console.WriteLine("After calculating with  given tolerance/error and iteration limit,\nthe approximate error is {0}.\n", Math.Round(root, 3));
                   
                }
                else
                {
                    Console.WriteLine("There's  no root on the given range.\n");
                }
                Console.Write("If you want to quit type 'YES' : ");
            } while ("Yes" == Console.ReadLine().ToUpper());
            Console.ReadKey();
        }

        public static double Function(double x)
        {
            //return ((2*Math.Pow(x,3))+(7*Math.Pow(x,2))-(14*x)+5);       //function #1
            return (x - Math.Pow(x, 3) - (4 * Math.Pow(x, 2)) + 10);        //function #2      


        }
        public static double Iteration(double x_low, double x_up, double error, double error_lim, double limit)
        {
            int i = 1;
            double x_mid, x_previous = 0;
            do
            {
                x_mid = (x_low + x_up) / 2;     //dividing the lower & upper range of finding root
                Console.WriteLine("Iteration no. {0}:\n", i);

                Console.WriteLine("The root value is: {0}", Math.Round(x_mid, 3));

                if (Function(x_low) * Function(x_mid) > 0)   //checking the multiplication of lower & mid function to find the root
                {
                    Console.WriteLine("Then, ({0})*({1})>0", Math.Round(Function(x_low), 3), Math.Round(Function(x_mid), 3));

                    x_low = x_mid;    //if conditon f(x_low)*f(x_mid)>0 then x_low=x_mid & x_up=x_up
                    Console.WriteLine("So, x_low = {0} & x_up = {1}.\n", Math.Round(x_low, 3), Math.Round(x_up, 3));
                }
                else
                {
                    Console.WriteLine("Then, ({0})*({1})<0", Math.Round(Function(x_low), 3), Math.Round(Function(x_mid), 3));

                    x_up = x_mid;    //if conditon f(x_low)*f(x_mid)<0 then x_low=x_low & x_up=x_mid
                    Console.WriteLine("So, x_low = {0} & x_up = {1}.\n", Math.Round(x_low, 3), Math.Round(x_up, 3));
                }

                if (i > 1)   //checking if iteration happened then calculate the error with the formula of relative tolerance
                {
                    error = Error(x_mid, x_previous);
                    Console.WriteLine("The approximate relative tolerance/error is {0}%.\n", Math.Round(error, 2));
                }
                
                Console.WriteLine("The lower limit is {0} & the upper limit is {1}.\n", Math.Round(x_low, 3), Math.Round(x_up, 3));

                x_previous = x_mid;
                i++;
            } while (error > error_lim && i <= limit);  //conditions for stopping the calculation with given error & iteration limit
            return x_mid;
        }
        public static double Error(double x_present, double x_previous)
        {
            return Math.Abs((x_present - x_previous) / x_present) * 100;  //formula of relative tolerance
        }
    }
}
