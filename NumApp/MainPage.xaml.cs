using NumApp.Helpers;

namespace NumApp;

public partial class MainPage : ContentPage
{
    public double CurrentValue { get; set; }

    private bool _moreOptionsShown = false;
    private List<Button> moreOptionsButtons = new List<Button>();

    public MainPage()
    {
        InitializeComponent();
        moreOptionsButtons = new List<Button>() { SaveButton, RandomButton, HexButton, BinaryButton };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        this.Window.Height = 470;
        this.Window.Width = 300;

        this.Window.MinimumHeight = 470;
        this.Window.MinimumWidth = 300;
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
        ButtonActions.DisplayButtonAction(ZeroButton, OperationDisplay, false);
    }

    private void OnOneButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(OneButton, OperationDisplay, false);
    }

    private void OnTwoButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(TwoButton, OperationDisplay, false);
    }

    private void OnThreeButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(ThreeButton, OperationDisplay, false);
    }

    private void OnFourButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(FourButton, OperationDisplay, false);
    }

    private void OnFiveButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(FiveButton, OperationDisplay, false);
    }

    private void OnSixButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(SixButton, OperationDisplay, false);
    }

    private void OnSevenButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(SevenButton, OperationDisplay, false);
    }

    private void OnEightButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(EightButton, OperationDisplay, false);
    }

    private void OnNineButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(NineButton, OperationDisplay, false);
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(AddButton, OperationDisplay, true);
    }

    private void OnSubtractButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(SubtractButton, OperationDisplay, true);
    }

    private void OnMultiplyButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(MultiplyButton, OperationDisplay, true);
    }

    private void OnDivideButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(DivideButton, OperationDisplay, true);
    }

    private void OnEqualsButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(EqualsButton, OperationDisplay, true);
    }

    private void OnPointButtonClicked(object sender, EventArgs e)
    {
        ButtonActions.DisplayButtonAction(PointButton, OperationDisplay, true);
    }
}
