using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumaericalAnalysis
{
    class FalsePosition
    {
        static void Main(string[] args)
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
            Console.ReadKey();
        }

        public static double Function(double x)
        {
            //return ((2*Math.Pow(x,3))+(7*Math.Pow(x,2))-(14*x)+5);       //function #1
            return (Math.Pow(x, 2) - x - 2);        //function #2      


        }
        public static double Iteration(double x_low, double x_up, double error, double error_lim, double limit)
        {
            int i = 1;
            double x_r, x_previous = 0, lFunc, uFunc;
            do
            {
                lFunc = Function(x_low);
                uFunc = Function(x_up);
                x_r = (((x_up * lFunc)) - ((x_low * uFunc))) / (lFunc - uFunc);     //formula of False position method
                Console.WriteLine("Iteration no. {0}:\n", i);

                Console.WriteLine("The root value is: {0}", Math.Round(x_r, 2));

                if (Function(x_low) * Function(x_r) > 0)   //checking the multiplication of lower & mid function to find the root
                {
                    Console.WriteLine("So, ({0})*({1})>0", Math.Round(Function(x_low), 2), Math.Round(Function(x_r), 2));

                    x_low = Math.Round(x_r, 2);  
                    Console.WriteLine("Then, x_low = {0} & x_up = {1}.\n", Math.Round(x_low, 2), Math.Round(x_up, 2));
                }
                else
                {
                    Console.WriteLine("So, ({0})*({1})<0", Math.Round(Function(x_low), 2), Math.Round(Function(x_r), 2));

                    x_up = Math.Round(x_r, 2);   
                    Console.WriteLine("Then, x_low = {0} & x_up = {1}.\n", Math.Round(x_low, 2), Math.Round(x_up, 2));
                }

                if (i > 1)   //checking if iteration happened then calculate the error with the formula of relative tolerance
                {
                    error = Error(Math.Round(x_r, 2), x_previous);
                    Console.WriteLine("The approximate relative tolerance/error is {0}%.\n", Math.Round(error, 2));
                }
                
                Console.WriteLine("The lower limit is {0} & the upper limit is {1}.\n", Math.Round(x_low, 2), Math.Round(x_up, 2));

                x_previous = Math.Round(x_r, 2);
                i++;
            } while (error > error_lim && i <= limit);  //conditions for stopping the calculation with given error & iteration limit
            return Math.Round(x_r, 2);
        }
        public static double Error(double x_present, double x_previous)
        {
            return Math.Abs((x_present - x_previous) / x_present) * 100;  //formula of relative tolerance
        }
    }
}
