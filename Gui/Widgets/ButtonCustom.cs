using System.Windows;
using System.Windows.Controls;
using GCL3.Gui.Pages;

namespace GCL3.Gui.Widgets;

public class ButtonCustom
{
    public static void GoToHome(Frame mainContent, object sender, RoutedEventArgs e)
    {
        mainContent.Navigate(new HomePage());
    }
    public static void GoToDownloadPage(Frame mainContent, object sender, RoutedEventArgs e)
    {
        mainContent.Navigate(new DownloadPage());
    }
    public static void GoToSettingsPage(Frame mainContent, object sender, RoutedEventArgs e)
    {
        mainContent.Navigate(new SettingsPage());
    }
    public static void GoToAboutPage(Frame mainContent, object sender, RoutedEventArgs e)
    {
        mainContent.Navigate(new AboutPage());
    }
}