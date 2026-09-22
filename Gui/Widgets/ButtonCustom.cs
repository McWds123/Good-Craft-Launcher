using System.Windows;
using System.Windows.Controls;
using GCL3.Gui.Pages;

namespace GCL3.Gui.Widgets;

public class ButtonCustom
{
    public static void GoToHome(ContentControl mainContent,object sender, RoutedEventArgs e)
    {
        mainContent.Content = new MainWindow();
    }
    public static void GoToDownloadPage(ContentControl mainContent,object sender, RoutedEventArgs e)
    {
        mainContent.Content = new DownloadPage();
    }
    public static void GoToSettingsPage(ContentControl mainContent,object sender, RoutedEventArgs e)
    {
        mainContent.Content = new SettingsPage();
    }
    public static void GoToAboutPage(ContentControl mainContent,object sender, RoutedEventArgs e)
    {
        mainContent.Content = new AboutPage();
    }
}