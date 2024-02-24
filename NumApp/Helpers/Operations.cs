namespace NumApp.Helpers;

internal class Operations
{
    private const string Addition = "+";
    private const string Subtraction = "-";
    private const string Multiplication = "×";
    private const string Division = "÷";

    /// <summary>
    /// Returns the sum of the two given numbers.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    internal static double Add(double x, double y)
    {
        return x + y;
    }

    /// <summary>
    /// Returns the difference of the two given numbers.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    internal static double Subtract(double x, double y)
    {
        return x - y;
    }

    /// <summary>
    /// Returns the product of the two given numbers.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    internal static double Multiply(double x, double y)
    {
        return x * y;
    }

    /// <summary>
    /// Returns the quotient of the two given numbers.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    internal static double Divide(double x, double y)
    {
        return x / y;
    }

    /// <summary>
    /// Performs the given calculation on the current value held by the calcultor and the value given.
    /// </summary>
    /// <param name="operationType"></param>
    /// <param name="value"></param>
    internal static void PerformCalculation(string operationType, double value)
    {
        switch (operationType)
        {
            case Addition:
                CalculatorPage.CurrentValue = Operations.Add(CalculatorPage.CurrentValue, value);
                break;
            case Subtraction:
                CalculatorPage.CurrentValue = Operations.Subtract(CalculatorPage.CurrentValue, value);
                break;
            case Multiplication:
                CalculatorPage.CurrentValue = Operations.Multiply(CalculatorPage.CurrentValue, value);
                break;
            case Division:
                CalculatorPage.CurrentValue = Operations.Divide(CalculatorPage.CurrentValue, value);
                break;
            default:
                break;
        }
    }
}


