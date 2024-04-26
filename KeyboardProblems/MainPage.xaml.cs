namespace KeyboardProblems;
#if __IOS__
using CoreGraphics;
using Foundation;
using UIKit;
#endif
public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
#if __IOS__
        UIKeyboard.Notifications.ObserveWillShow((s, e) =>
        {
            NSValue result = (NSValue)e.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));
            CGSize keyboardSize = result.RectangleFValue.Size;
            keyboardView.Margin = new Thickness(0, 0, 0, (keyboardSize.Height));
        });
        UIKeyboard.Notifications.ObserveWillHide((s, e) =>
        {
            keyboardView.Margin = new Thickness(0);
        });
#endif
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}


