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
            operationEntry.Text = operationEntry.Text.Remove(operationEntry.Text.Length - 1);
    }

    /// <summary>
    /// Applies the action of the given operator, updates the operation entry and the operation label.
    /// </summary>
    /// <param name="buttonOperator"></param>
    /// <param name="operationEntry"></param>
    /// <param name="operationLabel"></param>
    internal static void ApplyOperator(string buttonOperator, Entry operationEntry, Label operationLabel, bool isKeyboardInput = false)
    {
        if (String.IsNullOrWhiteSpace(operationEntry.Text))
            return;

        string textInput;

        if (isKeyboardInput)
            textInput = operationEntry.Text.Remove(operationEntry.Text.Length - 1).Trim();
        else
            textInput = operationEntry.Text;

        double input;

        if (double.TryParse(textInput, out input))
        {
            if (CalculatorPage.LastOperation == "÷" && input == 0)
            {
                operationEntry.Text = "Error";
                return;
            }

            if (String.IsNullOrEmpty(CalculatorPage.LastOperation))
                CalculatorPage.CurrentValue = input;
            else
                Operations.PerformCalculation(CalculatorPage.LastOperation, input);

            // Update the last operation to this operator
            CalculatorPage.LastOperation = buttonOperator;

            if (String.IsNullOrEmpty(operationLabel.Text))
            {
                operationLabel.Text += (textInput + $" {buttonOperator} ");
            }
            else
            {
                // Keep current operation for saving
                int operationNumber = CalculatorPage.Operations.Count + 1;
                CalculatorPage.Operations.Add($"Operation {operationNumber.ToString()}: {operationLabel.Text}{input.ToString()}");

                operationLabel.Text = (CalculatorPage.CurrentValue.ToString() + $" {buttonOperator} ");
            }

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
    internal static void DisplayResult(Entry operationEntry, Label operationLabel, bool isKeyboardInput = false)
    {
        string textInput;

        if (isKeyboardInput)
            textInput = operationEntry.Text.Remove(operationEntry.Text.Length - 1).Trim();
        else
            textInput = operationEntry.Text;

        double input;

        if (!double.TryParse(textInput, out input))
        {
            operationEntry.Text = "";
            return;
        }

        if (isKeyboardInput)
            ApplyOperator("", operationEntry, operationLabel, true);
        else
            ApplyOperator("", operationEntry, operationLabel);

        if (CalculatorPage.LastOperation == "÷" && input == 0)
        {
            operationEntry.Text = "Error";
        }
        else
        {
            if (CalculatorPage.DecimalPrecision > 0)
            {
                operationEntry.Text = CalculatorPage.CurrentValue.ToString($"N{CalculatorPage.DecimalPrecision}");
            }
            else
            {
                // Keep current result for saving
                operationEntry.Text = CalculatorPage.CurrentValue.ToString();
                CalculatorPage.Operations.Add($"Result: {operationEntry.Text}");
            }
        }

        operationLabel.Text = "";
        CalculatorPage.LastOperation = "";
        CalculatorPage.CurrentValue = 0;
    }
    
    /// <summary>
    /// Changes the sign of the value in the operation entry to the opposite.
    /// </summary>
    /// <param name="operationEntry"></param>
    internal static void ChangeSign(Entry operationEntry)
    {
        double input;

        if (double.TryParse(operationEntry.Text, out input))
        {
            if (input != 0)
                input *= -1;

            operationEntry.Text = input.ToString();
        }
        else
        {
            operationEntry.Text = "";
        }
    }

    /// <summary>
    /// Changes the decimal precision of the calculator.
    /// </summary>
    /// <param name="operationEntry"></param>
    internal static bool ChangeDecimalPrecision(Entry operationEntry)
    {
        int input;

        if (int.TryParse(operationEntry.Text, out input))
        {
            if (input > 0 && input <= 10)
            {
                CalculatorPage.DecimalPrecision = input;
                return true;
            }
            else if (input == 0)
            {
                operationEntry.Text = "";
                return true;
            }
            else
            {
                operationEntry.Text = "Invalid";
                return false;
            }
        }
        operationEntry.Text = "";
        return true;
    }

    /// <summary>
    /// Handles operations that involve only the content of the operation entry.
    /// </summary>
    /// <param name="operationEntry"></param>
    /// <param name="operation"></param>
    internal static void ApplySingleVariableOperation(Entry operationEntry, string operation)
    {
        double input;

        if (double.TryParse(operationEntry.Text, out input))
            Operations.UpdateOperationEntryValue(operationEntry, operation, input);
        else
            operationEntry.Text = "";
    }

    /// <summary>
    /// Generates a random number between the content of the random entry from and the conent of the random entry to (inclusive).
    /// </summary>
    /// <param name="randomEntryFrom"></param>
    /// <param name="randomEntryTo"></param>
    internal static bool GenerateRandom(Entry randomEntryFrom, Entry randomEntryTo)
    {
        double inputFrom;
        double inputTo;

        if (!double.TryParse(randomEntryFrom.Text, out inputFrom))
        {
            randomEntryFrom.Text = "";
            randomEntryTo.Text = "";
            return false;
        }

        if (!double.TryParse(randomEntryTo.Text, out inputTo))
        {
            randomEntryFrom.Text = "";
            randomEntryTo.Text = "";
            return false;
        }

        if (inputTo < inputFrom)
        {
            randomEntryFrom.Text = "";
            randomEntryTo.Text = "";
            return false;
        }

        CalculatorPage.CurrentValue = Operations.GetRandom(inputFrom, inputTo);
        return true;
    }
}
