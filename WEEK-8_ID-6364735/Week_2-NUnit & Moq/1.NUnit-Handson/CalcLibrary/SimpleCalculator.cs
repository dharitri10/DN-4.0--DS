using System;

namespace CalcLibrary
{
    public class SimpleCalculator
    {
        private double result;

        public double GetResult => result;

        public double Addition(double a, double b)
        {
            result = a + b;
            return result;
        }

        public double Subtraction(double a, double b)
        {
            result = a - b;
            return result;
        }

        public double Multiplication(double a, double b)
        {
            result = a * b;
            return result;
        }

        public double Division(double a, double b)
        {
            if (b == 0)
                throw new ArgumentException("Division by zero");
            result = a / b;
            return result;
        }

        public void AllClear()
        {
            result = 0;
        }
    }
}
