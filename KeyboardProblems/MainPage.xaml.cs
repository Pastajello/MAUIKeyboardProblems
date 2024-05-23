namespace KeyboardProblems;
#if __IOS__
using CoreGraphics;
using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
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
            scrollView.Content.Margin = new Thickness(0, 0, 0, (keyboardSize.Height - 97));
            var a = this.Handler.PlatformView as Microsoft.Maui.Platform.ContentView;

            int asd = 3;
        });
        UIKeyboard.Notifications.ObserveWillHide((s, e) =>
        {
            scrollView.Content.Margin = new Thickness(0);
        });
#endif

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
#if IOS || MACCATALYST

            var stack = new VerticalStackLayout()
            {
                BackgroundColor = Colors.Red,
                Padding = new Thickness(32, 8, 32, 24),
                HeightRequest = 97,
                WidthRequest = App.Current.MainPage.Width,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            stack.Add(new Button()
            {
                HorizontalOptions = LayoutOptions.End,
                Text = "Save",
                BackgroundColor = Colors.Red
            });
            var uiView = new UIView() { BackgroundColor = Colors.Gray.ToPlatform() };
            uiView.Frame = new CGRect(0, 0, App.Current.MainPage.Width, 97);
            uiView.AddSubview(stack.ToPlatform(this.Handler.MauiContext));
            uiView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
            handler.PlatformView.InputAccessoryView = uiView;
#endif
        });


    }

    private void OnCounterClicked(object sender, EventArgs e)
    {

    }
}


