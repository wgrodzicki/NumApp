using NumApp.Helpers;

namespace NumApp;

public partial class CalculatorPage : ContentPage
{
    public static double CurrentValue { get; set; }
    public static string LastOperation { get; set; }

    private bool _moreOptionsShown = false;
    private List<Button> moreOptionsButtons = new List<Button>();

    public CalculatorPage()
    {
        InitializeComponent();
        CurrentValue = 0;
        moreOptionsButtons = new List<Button>() { SaveButton, RandomButton, HexButton, BinaryButton };
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
            _moreOptionsShown = true;
            MoreButton.Text = "↑";
            ShowMoreOptions(true);
        }
        else
        {
            this.Window.Height -= SaveButton.MinimumHeightRequest;
            _moreOptionsShown = false;
            MoreButton.Text = "↓";
            ShowMoreOptions(false);
        }
    }

    /// <summary>
    /// Resets current calculator state.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ClearCalculator(OperationEntry, OperationLabel, true);
    }

    /// <summary>
    /// Resets current entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClearEntryButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ClearCalculator(OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Removes the last input.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.Delete(OperationEntry);
    }

    /// <summary>
    /// Applies addition of the content of the operation label and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(AddButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Applies subtraction of the content of the operation label and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSubtractButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(SubtractButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Applies multiplication of the content of the operation label and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMultiplyButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(MultiplyButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Applies division of the content of the operation label and the operation label.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDivideButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(DivideButton.Text, OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Shows the value of the current operation and ends it.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayResult(OperationEntry, OperationLabel);
    }

    /// <summary>
    /// Inverts the sign of the value in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ChangeSign(OperationEntry);
    }

    /// <summary>
    /// Displays the floating point in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnPointButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(PointButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 0 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnZeroButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(ZeroButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 1 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnOneButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(OneButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 2 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnTwoButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(TwoButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 3 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnThreeButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(ThreeButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 4 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnFourButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(FourButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 5 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnFiveButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(FiveButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 6 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSixButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(SixButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 7 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSevenButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(SevenButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 8 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnEightButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(EightButton.Text, OperationEntry);
    }

    /// <summary>
    /// Displays 9 in the operation entry.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnNineButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(NineButton.Text, OperationEntry);
    }
}
