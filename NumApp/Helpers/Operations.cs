namespace NumApp.Helpers;

internal class Operations
{
    private const string Addition = "+";
    private const string Subtraction = "-";
    private const string Multiplication = "×";
    private const string Division = "÷";

    internal static double Add(double x, double y)
    {
        return x + y;
    }

    internal static double Subtract(double x, double y)
    {
        return x - y;
    }

    internal static double Multiply(double x, double y)
    {
        return x * y;
    }

    internal static double Divide(double x, double y)
    {
        return x / y;
    }

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


