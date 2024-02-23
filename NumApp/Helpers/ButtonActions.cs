namespace NumApp.Helpers;

internal class ButtonActions
{
    internal static void ApplyButtonAction(string buttonText, Entry operationEntry, Label operationLabel, bool isSymbol)
    {
        if (isSymbol)
        {
            if (String.IsNullOrWhiteSpace(operationEntry.Text))
            {
                return;
            }

            double input;

            if (double.TryParse(operationEntry.Text, out input))
            {
                CalculatorPage.CurrentOperation = buttonText;

                if (String.IsNullOrEmpty(operationLabel.Text))
                {
                    PerformCalculation(buttonText, input);
                }

                operationLabel.Text += (operationEntry.Text + $" {buttonText} ");
                operationEntry.Text = "";
            }
            else
            {
                operationEntry.Text = "";
            }
        }
        else
        {
            operationEntry.Text += $"{buttonText}";
        }
    }

    internal static void DisplayResult(Entry operationEntry, Label operationLabel)
    {
        ApplyButtonAction(CalculatorPage.CurrentOperation, operationEntry, operationLabel, true);
        operationLabel.Text = "";
        operationEntry.Text = CalculatorPage.CurrentValue.ToString("N2");
        CalculatorPage.CurrentValue = 0;
    }

    internal static void PerformCalculation(string operationType, double value)
    {
        switch (operationType)
        {
            case "+":
                CalculatorPage.CurrentValue = Operations.Add(CalculatorPage.CurrentValue, value);
                break;
            case "-":
                CalculatorPage.CurrentValue = Operations.Subtract(CalculatorPage.CurrentValue, value);
                break;
            case "×":
                CalculatorPage.CurrentValue = Operations.Multiply(CalculatorPage.CurrentValue, value);
                break;
            case "÷":
                CalculatorPage.CurrentValue = Operations.Divide(CalculatorPage.CurrentValue, value);
                break;
            default:
                break;
        }
    }
}
