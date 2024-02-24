namespace NumApp.Helpers;

internal class ButtonActions
{
    internal static void ApplyOperator(string buttonText, Entry operationEntry, Label operationLabel)
    {
        if (String.IsNullOrWhiteSpace(operationEntry.Text))
        {
            return;
        }

        double input;

        if (double.TryParse(operationEntry.Text, out input))
        {
            if (String.IsNullOrEmpty(CalculatorPage.LastOperation))
            {
                CalculatorPage.CurrentValue = input;
            }
            else
            {
                Operations.PerformCalculation(CalculatorPage.LastOperation, input);
            }
            
            CalculatorPage.LastOperation = buttonText;
            operationLabel.Text += (operationEntry.Text + $" {buttonText} ");
            operationEntry.Text = "";
        }
        else
        {
            operationEntry.Text = "";
        }
    }

    internal static void DisplayNumber(string buttonText, Entry operationEntry, Label operationLabel)
    {
        operationEntry.Text += $"{buttonText}";
    }

    internal static void DisplayResult(Entry operationEntry, Label operationLabel)
    {
        ApplyOperator("", operationEntry, operationLabel);
        operationEntry.Text = CalculatorPage.CurrentValue.ToString("N2");

        operationLabel.Text = "";
        CalculatorPage.LastOperation = "";
        CalculatorPage.CurrentValue = 0;
    }
}
