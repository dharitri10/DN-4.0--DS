using System;

public class LoggerTest
{
    public static void RunTest()
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("This is the first log message.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("This is the second log message.");

        if (object.ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("logger1 and logger2 are the same instance. Singleton verified.");
        }
        else
        {
            Console.WriteLine("logger1 and logger2 are different instances. Singleton failed.");
        }
    }
}
