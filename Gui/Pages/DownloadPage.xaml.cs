using System.Windows;
using System.Windows.Controls;
using GCL3.Gui.Widgets;

namespace GCL3;

public partial class DownloadPage : Page
{
    public DownloadPage()
    {
        InitializeComponent();
        Buttons();
    }

    public void Buttons()
    {
        GoTab.HorizontalAlignment = HorizontalAlignment.Center;
        GoTab.VerticalAlignment = VerticalAlignment.Bottom;
        
        HomePageBtn.Margin = new Thickness(2.5, 0, 2.5, 15);
        DownloadPageBtn.Margin = new Thickness(2.5, 0, 2.5, 15);
        SettingsPageBtn.Margin = new Thickness(2.5, 0, 2.5, 15);
        AboutPageBtn.Margin = new Thickness(2.5, 0, 2.5, 15);

        HomePageBtn.Click += (sender, args) => ButtonCustom.GoToHome(MainContent, sender, args);
        DownloadPageBtn.Click += (sender, args) => ButtonCustom.GoToDownloadPage(MainContent, sender, args);
        SettingsPageBtn.Click += (sender, args) => ButtonCustom.GoToSettingsPage(MainContent, sender, args);
        AboutPageBtn.Click += (sender, args) => ButtonCustom.GoToAboutPage(MainContent, sender, args);

    }
}