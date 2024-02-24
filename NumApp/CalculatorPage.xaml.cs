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

    private void OnZeroButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(ZeroButton.Text, OperationEntry, OperationLabel);
    }

    private void OnOneButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(OneButton.Text, OperationEntry, OperationLabel);
    }

    private void OnTwoButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(TwoButton.Text, OperationEntry, OperationLabel);
    }

    private void OnThreeButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(ThreeButton.Text, OperationEntry, OperationLabel);
    }

    private void OnFourButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(FourButton.Text, OperationEntry, OperationLabel);
    }

    private void OnFiveButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(FiveButton.Text, OperationEntry, OperationLabel);
    }

    private void OnSixButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(SixButton.Text, OperationEntry, OperationLabel);
    }

    private void OnSevenButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(SevenButton.Text, OperationEntry, OperationLabel);
    }

    private void OnEightButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(EightButton.Text, OperationEntry, OperationLabel);
    }

    private void OnNineButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(NineButton.Text, OperationEntry, OperationLabel);
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(AddButton.Text, OperationEntry, OperationLabel);
    }

    private void OnSubtractButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(SubtractButton.Text, OperationEntry, OperationLabel);
    }

    private void OnMultiplyButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(MultiplyButton.Text, OperationEntry, OperationLabel);
    }

    private void OnDivideButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyOperator(DivideButton.Text, OperationEntry, OperationLabel);
    }

    private void OnPointButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayNumber(PointButton.Text, OperationEntry, OperationLabel);
    }

    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayResult(OperationEntry, OperationLabel);
    }
}
