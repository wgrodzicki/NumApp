namespace NumApp.Helpers;

internal class ButtonActions
{
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
        if (!String.IsNullOrEmpty(operationEntry.Text))
        {
            operationEntry.Text = operationEntry.Text.Remove(operationEntry.Text.Length - 1);
        }
    }

    /// <summary>
    /// Validates input and applies the action of the given operator, updates the operation entry and the operation label.
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
            if (CalculatorPage.LastOperation == "÷" && input == 0)
            {
                operationEntry.Text = "Error";
                return;
            }

            if (String.IsNullOrEmpty(CalculatorPage.LastOperation))
            {
                CalculatorPage.CurrentValue = input;
            }
            else
            {
                Operations.PerformCalculation(CalculatorPage.LastOperation, input);
            }
            
            // Update the last operation to this operator
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
        double input;

        if (!double.TryParse(operationEntry.Text, out input))
        {
            operationEntry.Text = "";
            return;
        }

        ApplyOperator("", operationEntry, operationLabel);

        if (CalculatorPage.LastOperation == "÷" && input == 0)
        {
            operationEntry.Text = "Error";
        }
        else
        {
            operationEntry.Text = CalculatorPage.CurrentValue.ToString();
        }

        operationLabel.Text = "";
        CalculatorPage.LastOperation = "";
        CalculatorPage.CurrentValue = 0;
    }
    
    /// <summary>
    /// Changes the sign of the value in the operation entry to the opposite, unless 0 or invalid.
    /// </summary>
    /// <param name="operationEntry"></param>
    internal static void ChangeSign(Entry operationEntry)
    {
        double input;

        if (double.TryParse(operationEntry.Text, out input))
        {
            if (input != 0)
            {
                input *= -1;
            }
            operationEntry.Text = input.ToString();
        }
        else
        {
            operationEntry.Text = "";
        }
    }

    /// <summary>
    /// Handles operations that involve only the content of the operation entry.
    /// </summary>
    /// <param name="operationEntry"></param>
    /// <param name="operation"></param>
    internal static void SingleVariableOperation(Entry operationEntry, string operation)
    {
        double input;

        if (double.TryParse(operationEntry.Text, out input))
        {
            Operations.UpdateOperationEntryValue(operationEntry, operation, input);
        }
        else
        {
            operationEntry.Text = "";
        }
    }
}
