namespace NumApp.Helpers;

internal class ButtonActions
{
    internal static void DisplayButtonAction(Button button, Entry entry, bool isSymbol)
    {
        if (isSymbol)
            entry.Text += $" {button.Text} ";
        else
            entry.Text += $"{button.Text}";
    }
}
