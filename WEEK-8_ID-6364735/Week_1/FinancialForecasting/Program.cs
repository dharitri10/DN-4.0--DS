using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter current amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter growth rate (e.g., 0.05 for 5%): ");
        double growthRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter number of years to forecast: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double futureValue = PredictFutureValue(amount, growthRate, years);
        Console.WriteLine($"\nFuture value after {years} years: {futureValue:F2}");

        // Optimized version using formula
        double optimizedValue = PredictFutureValueOptimized(amount, growthRate, years);
        Console.WriteLine($"(Optimized) Future value after {years} years: {optimizedValue:F2}");
    }

    static double PredictFutureValue(double amount, double growthRate, int years)
    {
        if (years == 0)
            return amount;

        return PredictFutureValue(amount * (1 + growthRate), growthRate, years - 1);
    }

    static double PredictFutureValueOptimized(double amount, double growthRate, int years)
    {
        return amount * Math.Pow(1 + growthRate, years);
    }
}
