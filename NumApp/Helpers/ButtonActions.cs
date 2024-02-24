namespace NumApp.Helpers;

internal class ButtonActions
{
    /// <summary>
    /// Applies the action of the given operator and updates the operation entry and the operation label.
    /// </summary>
    /// <param name="buttonOperator"></param>
    /// <param name="operationEntry"></param>
    /// <param name="operationLabel"></param>
    internal static void ApplyOperator(string buttonOperator, Entry operationEntry, Label operationLabel)
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
            
            // Updatr the last operation to this operator
            CalculatorPage.LastOperation = buttonOperator;

            operationLabel.Text += (operationEntry.Text + $" {buttonOperator} ");
            operationEntry.Text = "";
        }
        else
        {
            operationEntry.Text = "";
        }
    }

    /// <summary>
    /// Displays the given number in the operation entry.
    /// </summary>
    /// <param name="buttonNumber"></param>
    /// <param name="operationEntry"></param>
    internal static void DisplayNumber(string buttonNumber, Entry operationEntry)
    {
        operationEntry.Text += $"{buttonNumber}";
    }

    /// <summary>
    /// Displays the result of the current operation held by the calculator.
    /// </summary>
    /// <param name="operationEntry"></param>
    /// <param name="operationLabel"></param>
    internal static void DisplayResult(Entry operationEntry, Label operationLabel)
    {
        ApplyOperator("", operationEntry, operationLabel);
        operationEntry.Text = CalculatorPage.CurrentValue.ToString("N2");

        operationLabel.Text = "";
        CalculatorPage.LastOperation = "";
        CalculatorPage.CurrentValue = 0;
    }

    /// <summary>
    /// Clears input and values held by the calculator (all or current entry only).
    /// </summary>
    /// <param name="operationEntry"></param>
    /// <param name="operationLabel"></param>
    /// <param name="clearAll"></param>
    internal static void ClearCalculator(Entry operationEntry, Label operationLabel, bool clearAll = false)
    {
        operationEntry.Text = "";

        if (clearAll)
        {
            operationLabel.Text = "";
            CalculatorPage.LastOperation = "";
            CalculatorPage.CurrentValue = 0;
        }
    }

    /// <summary>
    /// Deletes the last character entered from the operation entry.
    /// </summary>
    /// <param name="operationEntry"></param>
    internal static void Delete(Entry operationEntry)
    {
        operationEntry.Text = operationEntry.Text.Remove(operationEntry.Text.Length - 1);
    }
}
