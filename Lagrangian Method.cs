using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalAnalysis
{
    class Lagrangian
    {
        public static void Main(string[] args)
        {
            int i = 0;
            
            Console.Write("\nInput the given year = ");
            double a_r = Convert.ToDouble(Console.ReadLine());

            double result;
            double[] a = new double[10];
            double[] f_a = new double[100];
            
            Console.Write("\nInput the order of polynomial interpolation = ");
            double order = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n");
            for (i = 0; i <= order; i++)
            {
                Console.Write("Input the given closest year of {0}, a_{1} = ",a_r,i);
                a[i] = Convert.ToDouble(Console.ReadLine());
                
                Console.Write("Input the given value of f({0}) = ",a[i]);
                f_a[i] = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\n");
            }
            
            Console.WriteLine("\n");
            result = Calculate(a_r,a,f_a,order);
            Console.WriteLine("After calculating with  given data sheet,\nthe result of f({0}) = {1}\n",a_r, Math.Round(result, 6));
            Console.ResetColor();
            Console.ReadKey();
        }



        #region calculation of the result

        public static double Calculate(double a_r, double[] a, double[] f_a, double order)
        {
            int i = 0,j=0;
            int k = 0, m;
            double result=0,l=1,lj=1;

            for(i=0; i<=order;i++)
            {
                if (k == i && k==0)
                {
                    for (j=i+1; j <= order; j++)
                    {
                        lj = (a_r - a[j]) / (a[i] - a[j]);
                        l = lj * l;                          //calculating the value for l_0
                    }
                }
                else if(k==i && k>0)
                {
                    m = 0;
                    while (a[m] != 0)
                    {
                        m++;
                    }
                    a[m] = a[i - 1];

                    for (j = i+1; j <= order+i; j++)
                    {
                        lj = (a_r - a[j]) / (a[i] - a[j]);
                        l = lj * l;                          //calculating the value for l_1,l_2,l_3,...........
                    }
                }
                k++;
                
                Console.WriteLine("The value of l({0}) is: {1}", i, Math.Round(l, 6));

                result += (l * f_a[i]);
                l = 1; lj = 1;

            }
            return result;
        }


        #endregion
    }
}
