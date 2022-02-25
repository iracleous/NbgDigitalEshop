using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class Aa
    {
        public static void Driver()
        {
            double[] values = { 1.2, 3.4, 4, 5, 2, 5.6, 5.1 };
            Console.WriteLine(StDev(values));
        }

        private static double StDev(double[] values)
        {
            var total = 0.0; // add all elements of the array
            for (var i = 0; i < values.Length; i++)
            {
                total += values[i];
            } // find the average n = values.Length
            var X_hat = total / values.Length;
            total = 0.0;
            for (var i = 0; i < values.Length; i++)
            {
                // subtract and finds the power
                // then sums it
                total += Math.Pow(values[i] - X_hat, 2);
            } // find the variance
            var variance = total / (values.Length - 1);
            var std = Math.Sqrt(variance);
            return std;
        }



    }
}
