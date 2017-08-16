using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalAnalysis
{
    class TaylorSeries2
    {
        static void Main(string[] args)
        {
            double x_0 = 0, result, y_i = 0;
            Console.Write("\nInput the lower range of given interval = ");
            double x_low = Convert.ToDouble(Console.ReadLine());

            Console.Write("Input the upper range of given interval = ");
            double x_up = Convert.ToDouble(Console.ReadLine());

           
            Console.Write("Is there any value of 'y()', \nthen press 'Y' & press ENTER :-  ");
             if ("y" == Console.ReadLine())
            {
                Console.Write("Input the value of x_0 = ");
                x_0 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Input the given value of y({0}) = ", x_0);
                y_i = Convert.ToDouble(Console.ReadLine());
            }
             Console.WriteLine("\n");
            
            result = calculate(x_low, x_up, y_i, x_0);

            
            Console.WriteLine("After calculating with  given step,\nthe result = {0}\n", Math.Round(result, 6));
            Console.ReadKey();
        }

        #region 1st derive function
        public static double FirstFunction(double x, double y)
        {   //y_i 1st derivative function
            return ((x - y) / 2);
        }
        #endregion

        #region 2nd derive function
        public static double SecondFunction(double x, double y)
        {       //y_i function 2nd derivative
            return ((1 - FirstFunction(x, y)) / 2);
        }
        #endregion

        #region 3rd derive function
        public static double ThirdFunction(double x, double y)
        {       //y_i function 2rd derivative
            return (-(SecondFunction(x, y)) / 2);
        }
        #endregion

        #region 4th derive function
        public static double FourthFunction(double x, double y)
        {       //y_i function 4th derivative
            return (-(ThirdFunction(x, y)) / 2);
        }
        #endregion

        #region Factorial method
        public static double factorial(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }

        #endregion

        #region calculation without sub dividing

        public static double calculate(double x_low, double x_up, double y_i, double x_0)
        {
            double i = 1;
            double error, y_prv = y_i, x_in = x_up;
            
            y_i = y_i + subdivide(x_up, x_0) * FirstFunction(x_low, y_i) + ((subdivide(x_up, x_0) * subdivide(x_up, x_0)) * SecondFunction(x_low, y_i)) / factorial(2) + ((subdivide(x_up, x_0) * subdivide(x_up, x_0) * subdivide(x_up, x_0)) * ThirdFunction(x_low, y_i)) / factorial(3) + ((subdivide(x_up, x_0) * subdivide(x_up, x_0) * subdivide(x_up, x_0) * subdivide(x_up, x_0)) * FourthFunction(x_low, y_i)) / factorial(4);     //formula of taylor series without subdividing
            Console.WriteLine("The value of y({0}) is: {1}", x_up, Math.Round(y_i, 6));
            Console.ResetColor();


                x_up += x_in;
                i++;
            
                    error = Error(y_i, y_prv);
                    Console.WriteLine("The approximate relative tolerance/error is {0}%.\n", Math.Round(error, 2));
                    Console.ResetColor();
            return y_i;
        }


        #endregion

        #region Error
        public static double Error(double x_present, double x_previous)
        {
            return Math.Abs((x_present - x_previous) / x_present) * 100;  //formula of relative tolerance
        }
        #endregion

        #region  subdividing
        public static double subdivide(double x, double x_0)
        {
            return (x - x_0);
        }

        #endregion


    }
}
