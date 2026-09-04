using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    // Generic delegate declaration with 2 generic arguments and return type T
    public delegate T Formula<T>(T arg1, T arg2);

    public class CalculatorClass
    {
        // Private backing field for the event accessor 
        private Formula<double> calculateEvent;

        // Custom Event Accessor 
        public event Formula<double> CalculateEvent
        {
            add
            {
                calculateEvent += value;
                Console.WriteLine("Added the Delegate"); // Confirmation message
            }
            remove
            {
                calculateEvent -= value;
                Console.WriteLine("Removed the Delegate"); // Confirmation message
            }
        }

        // Method to invoke the current event delegate safely
        public double ExecuteCalculation(double arg1, double arg2)
        {
            return calculateEvent?.Invoke(arg1, arg2) ?? 0.0;
        }

        // Arithmetic Methods
        public double GetSum(double num1, double num2)
        {
            return num1 + num2;
        }

        public double GetDifference(double num1, double num2)
        {
            return num1 - num2;
        }

        // Product and Quotient
        public double GetProduct(double num1, double num2)
        {
            return num1 * num2;
        }

        public double GetQuotient(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return num1 / num2;
        }
    }
}
