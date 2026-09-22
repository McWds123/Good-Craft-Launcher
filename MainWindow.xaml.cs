using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GCL3.Gui.Pages;
using GCL3.Gui.Widgets;

namespace GCL3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Buttons();
        MainContent.Navigate(new HomePage());
    }

    public void Buttons()
    {
        // 启动游戏按钮
        Button RunGame = new Button();
        RunGame.Content = "启动游戏";
        RunGame.Width = 150;
        RunGame.Height = 75;
        RunGame.HorizontalAlignment = HorizontalAlignment.Left;
        RunGame.VerticalAlignment = VerticalAlignment.Bottom;
        RunGame.Margin = new Thickness(10, 0, 0, 10);
        ButtonStyle.SetStyle(RunGame);
        RootGrid.Children.Add(RunGame);

        // 导航栏
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

        ButtonStyle.SetGoTabStyle(GoTab, HomePageBtn, DownloadPageBtn, SettingsPageBtn, AboutPageBtn);
    }
}