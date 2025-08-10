using System;

public class Logger
{
    // Step 2: Private static instance
    private static Logger? instance = null;


    // Step 2: Private constructor
    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }

    // Step 2: Public static method to get the instance
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }
    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}
