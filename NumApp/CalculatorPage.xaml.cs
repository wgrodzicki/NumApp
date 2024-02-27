using NumApp.Helpers;

namespace NumApp;

public partial class CalculatorPage : ContentPage
{
    public static double CurrentValue { get; set; }
    public static string LastOperation { get; set; }
    public bool RandomOn { get; set; }

    private bool _moreOptionsShown = false;
    private List<Button> moreOptionsButtons = new List<Button>();

    private bool _randomEntryFromWasFocused = false;
    private bool _randomEntryToWasFocused = false;

    public CalculatorPage()
    {
        InitializeComponent();
        BindingContext = this;

        CurrentValue = 0;
        LastOperation = "";
        RandomOn = false;
        moreOptionsButtons = new List<Button>() { SaveButton, RandomButton, HexButton, BinButton };
    }
    
    /// <summary>
    /// Shows or hides the additional buttons.
    /// </summary>
    /// <param name="shouldShow"></param>
    private void ShowMoreOptions(bool shouldShow)
    {
        foreach (Button moreOptionsButton in moreOptionsButtons)
        {
            if (shouldShow)
                moreOptionsButton.IsVisible = true;
            else
                moreOptionsButton.IsVisible = false;
        }
    }

    /// <summary>
    /// Handles showing/hiding additional buttons and adjusting the layout accordingly.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMoreButtonClicked(object sender, EventArgs e)
    {
        if (!_moreOptionsShown)
        {
            this.Window.Height += SaveButton.MinimumHeightRequest;
            this.Window.MinimumHeight += SaveButton.MinimumHeightRequest;
            _moreOptionsShown = true;
            MoreButton.Text = "Less";
            ShowMoreOptions(true);
        }
        else
        {
            this.Window.MinimumHeight -= SaveButton.MinimumHeightRequest;
            this.Window.Height -= SaveButton.MinimumHeightRequest;
            _moreOptionsShown = false;
            MoreButton.Text = "More";
            ShowMoreOptions(false);
        }
    }

    /// <summary>
    /// Resets current values in all currently visible entries.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.ClearCalculator(OperationEntry, OperationLabel, true);
            return;
        }
            
        ButtonActions.ClearCalculator(RandomEntryFrom, OperationLabel);
        ButtonActions.ClearCalculator(RandomEntryTo, OperationLabel);
    }

    /// <summary>
    /// Resets currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClearEntryButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.ClearCalculator(OperationEntry, OperationLabel);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.ClearCalculator(RandomEntryFrom, OperationLabel);
        if (_randomEntryToWasFocused)
            ButtonActions.ClearCalculator(RandomEntryTo, OperationLabel);
    }

    /// <summary>
    /// Removes the last input in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.Delete(OperationEntry);
            return;
        }
            
        if (_randomEntryFromWasFocused)
            ButtonActions.Delete(RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.Delete(RandomEntryTo);
    }

    /// <summary>
    /// Applies the power of 2 to the content of the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSquareButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplySingleVariableOperation(OperationEntry, SquareButton.Text);
    }

    /// <summary>
    /// Applies square root to the content of the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSqrtButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplySingleVariableOperation(OperationEntry, SqrtButton.Text);
    }

    /// <summary>
    /// Convert the content of the operation entry to a percentage.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnPercentageButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplySingleVariableOperation(OperationEntry, PercentageButton.Text);
    }

    /// <summary>
    /// Applies division to the content of the operation entry and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDivideButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplyOperator(DivideButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Applies multiplication to the content of the operation entry and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMultiplyButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplyOperator(MultiplyButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Applies subtraction to the content of the operation entry and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSubtractButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplyOperator(SubtractButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Applies addition to the content of the operation entry and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplyOperator(AddButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Shows the value of the current operation and ends it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayResult(OperationEntry, OperationLabel);
            return;
        }

        bool randomSuccessful = ButtonActions.GenerateRandom(RandomEntryFrom, RandomEntryTo);

        RandomOn = false;
        _randomEntryFromWasFocused = false;
        _randomEntryToWasFocused = false;
        RandomEntryFrom.Text = "";
        RandomEntryTo.Text = "";
        SwitchButtons(false, true);

        if (randomSuccessful)
            OperationEntry.Text = CurrentValue.ToString();
    }

    /// <summary>
    /// Inverts the sign of the value in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.ChangeSign(OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.ChangeSign(RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.ChangeSign(RandomEntryTo);
    }

    /// <summary>
    /// Displays the floating point in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnPointButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.DisplayNumber(PointButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 0 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnZeroButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(ZeroButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(ZeroButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(ZeroButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 1 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnOneButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(OneButton.Text, OperationEntry);
            return;
        }
        
        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(OneButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(OneButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 2 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTwoButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(TwoButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(TwoButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(TwoButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 3 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnThreeButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(ThreeButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(ThreeButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(ThreeButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 4 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnFourButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(FourButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(FourButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(FourButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 5 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnFiveButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(FiveButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(FiveButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(FiveButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 6 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSixButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(SixButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(SixButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(SixButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 7 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSevenButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(SevenButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(SevenButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(SevenButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 8 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEightButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(EightButton.Text, OperationEntry);
            return;
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(EightButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(EightButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Displays 9 in the currently used entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnNineButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
        {
            ButtonActions.DisplayNumber(NineButton.Text, OperationEntry);
        }

        if (_randomEntryFromWasFocused)
            ButtonActions.DisplayNumber(NineButton.Text, RandomEntryFrom);
        if (_randomEntryToWasFocused)
            ButtonActions.DisplayNumber(NineButton.Text, RandomEntryTo);
    }

    /// <summary>
    /// Converts the number in the operation entry to hexadecimal.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnHexButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplySingleVariableOperation(OperationEntry, HexButton.Text);
    }

    /// <summary>
    /// Converts the number in the operation entry to binary.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnBinButtonClicked(object sender, EventArgs e)
    {
        if (!RandomOn)
            ButtonActions.ApplySingleVariableOperation(OperationEntry, BinButton.Text);
    }

    /// <summary>
    /// Switches buttons on/off depending on the random option being on/off.
    /// </summary>
    /// <param name="randomButtonsValue"></param>
    /// <param name="otherButtonsValue"></param>
    private void SwitchButtons(bool randomButtonsValue, bool otherButtonsValue)
    {
        HexButton.IsEnabled = otherButtonsValue;
        BinButton.IsEnabled = otherButtonsValue;
        SquareButton.IsEnabled = otherButtonsValue;
        SqrtButton.IsEnabled = otherButtonsValue;
        PercentageButton.IsEnabled = otherButtonsValue;
        DivideButton.IsEnabled = otherButtonsValue;
        MultiplyButton.IsEnabled = otherButtonsValue;
        SubtractButton.IsEnabled = otherButtonsValue;
        AddButton.IsEnabled = otherButtonsValue;
        PointButton.IsEnabled = otherButtonsValue;

        OperationEntry.IsVisible = otherButtonsValue;
        OperationLabel.IsVisible = otherButtonsValue;

        RandomEntryFrom.IsVisible = randomButtonsValue;
        RandomEntryTo.IsVisible = randomButtonsValue;
        RandomLabelFrom.IsVisible = randomButtonsValue;
        RandomLabelTo.IsVisible = randomButtonsValue;
    }

    /// <summary>
    /// Updates the last focused random entry to the random from entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RandomEntryFrom_Focused(object sender, FocusEventArgs e)
    {
        _randomEntryFromWasFocused = true;
        _randomEntryToWasFocused = false;
    }

    /// <summary>
    /// Updates the last focused random entry to the random to entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RandomEntryTo_Focused(object sender, FocusEventArgs e)
    {
        _randomEntryToWasFocused = true;
        _randomEntryFromWasFocused = false;
    }

    /// <summary>
    /// Switches the calculator to the random generator mode.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnRandomButtonClicked(object sender, EventArgs e)
    {
        CurrentValue = 0;
        LastOperation = "";
        OperationEntry.Text = "";

        if (RandomOn)
        {
            RandomOn = false;
            _randomEntryFromWasFocused = false;
            _randomEntryToWasFocused = false;
            RandomEntryFrom.Text = "";
            RandomEntryTo.Text = "";
            SwitchButtons(false, true);
        }
        else
        {
            RandomOn = true;
            SwitchButtons(true, false);
        }
    }
}
