using System.Windows;
using System.Windows.Controls;
using GCL3.Gui.Pages;

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

        HomePageBtn.Click += (sender, args) => NavigationService?.Navigate(new HomePage());
        DownloadPageBtn.Click += (sender, args) => NavigationService?.Navigate(new DownloadPage());
        SettingsPageBtn.Click += (sender, args) => NavigationService?.Navigate(new SettingsPage());
        AboutPageBtn.Click += (sender, args) => NavigationService?.Navigate(new AboutPage());
    }
}