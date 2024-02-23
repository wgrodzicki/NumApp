using NumApp.Helpers;

namespace NumApp;

public partial class CalculatorPage : ContentPage
{
    public static double CurrentValue { get; set; }
    public static string CurrentOperation {  get; set; }

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
        ButtonActions.ApplyButtonAction(ZeroButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnOneButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(OneButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnTwoButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(TwoButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnThreeButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(ThreeButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnFourButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(FourButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnFiveButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(FiveButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnSixButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(SixButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnSevenButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(SevenButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnEightButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(EightButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnNineButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(NineButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(AddButton.Text, OperationEntry, OperationLabel, true);
    }

    private void OnSubtractButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(SubtractButton.Text, OperationEntry, OperationLabel, true);
    }

    private void OnMultiplyButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(MultiplyButton.Text, OperationEntry, OperationLabel, true);
    }

    private void OnDivideButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(DivideButton.Text, OperationEntry, OperationLabel, true);
    }

    private void OnPointButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.ApplyButtonAction(PointButton.Text, OperationEntry, OperationLabel, false);
    }

    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayResult(OperationEntry, OperationLabel);
    }
}
