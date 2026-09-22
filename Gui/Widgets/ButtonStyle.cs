using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GCL3.Gui.Widgets;

public class ButtonStyle
{
    // 主题色
    private static readonly Color NormalColor  = (Color)ColorConverter.ConvertFromString("#FFFFFF");
    private static readonly Color HoverColor   = (Color)ColorConverter.ConvertFromString("#E8F4FF");
    private static readonly Color PressedColor = (Color)ColorConverter.ConvertFromString("#CDE7FF");
    private static readonly Color BorderColor  = (Color)ColorConverter.ConvertFromString("#87CEEB"); // LightSkyBlue
    
    private static readonly SolidColorBrush BorderColor_ = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#87CEEB"));
    private static readonly SolidColorBrush GoTabBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F5F5F5"));
    private static readonly SolidColorBrush NavForeground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
    private static readonly SolidColorBrush NavHoverBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E8F0FE"));
    private static readonly SolidColorBrush NavCheckedBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D0E4FF"));

    public static void SetStyle(Button btn)
    {
        btn.Foreground = new SolidColorBrush(ColorConverter.ConvertFromString("#4A90E2") is Color c
            ? c
            : Colors.LightSkyBlue);
        btn.BorderBrush = new SolidColorBrush(BorderColor);
        btn.Background  = new SolidColorBrush(NormalColor);
        btn.BorderThickness = new Thickness(1);
        btn.Padding     = new Thickness(16, 8, 16, 8);
        btn.FontSize    = 14;
        btn.Cursor      = System.Windows.Input.Cursors.Hand;
        btn.HorizontalContentAlignment = HorizontalAlignment.Center;
        btn.VerticalContentAlignment   = VerticalAlignment.Center;
        btn.RenderTransformOrigin = new Point(0.5, 0.5);
        btn.RenderTransform = new ScaleTransform(1, 1);

        // ---- 圆角 + 悬停/按下 模板 ----
        btn.Template = BuildTemplate();
    }
    private static ControlTemplate BuildTemplate()
    {
        var template = new ControlTemplate(typeof(Button));

        // Border（承载圆角与背景）
        var border = new FrameworkElementFactory(typeof(Border), "border");
        border.SetValue(Border.CornerRadiusProperty, new CornerRadius(8));
        border.SetValue(Border.BorderThicknessProperty, new Thickness(1));
        border.SetValue(Border.SnapsToDevicePixelsProperty, true);
        border.SetValue(FrameworkElement.RenderTransformOriginProperty, new Point(0.5, 0.5));
        border.SetValue(FrameworkElement.RenderTransformProperty, new ScaleTransform(1, 1));

        // 用 TemplateBinding 绑定到 Button 的属性
        border.SetBinding(Border.BackgroundProperty,
            new System.Windows.Data.Binding(nameof(Control.Background))
            { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });
        border.SetBinding(Border.BorderBrushProperty,
            new System.Windows.Data.Binding(nameof(Control.BorderBrush))
            { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });
        border.SetBinding(Border.BorderThicknessProperty,
            new System.Windows.Data.Binding(nameof(Control.BorderThickness))
            { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });

        // ContentPresenter（显示文字）
        var cp = new FrameworkElementFactory(typeof(ContentPresenter));
        cp.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
        cp.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
        cp.SetBinding(ContentPresenter.MarginProperty,
            new System.Windows.Data.Binding(nameof(Control.Padding))
            { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });

        border.AppendChild(cp);
        template.VisualTree = border;

        // ---- 悬停 ----
        var hover = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
        hover.Setters.Add(new Setter(Border.BackgroundProperty,
            new SolidColorBrush(HoverColor), "border"));
        hover.EnterActions.Add(BuildScaleAction(1.04, TimeSpan.FromSeconds(0.15)));
        hover.ExitActions.Add(BuildScaleAction(1.0, TimeSpan.FromSeconds(0.15)));
        template.Triggers.Add(hover);

        // ---- 按下 ----
        var pressed = new Trigger { Property = Button.IsPressedProperty, Value = true };
        pressed.Setters.Add(new Setter(Border.BackgroundProperty,
            new SolidColorBrush(PressedColor), "border"));
        pressed.EnterActions.Add(BuildScaleAction(0.96, TimeSpan.FromSeconds(0.08)));
        pressed.ExitActions.Add(BuildScaleAction(1.0, TimeSpan.FromSeconds(0.08)));
        template.Triggers.Add(pressed);

        // ---- 禁用 ----
        var disabled = new Trigger { Property = UIElement.IsEnabledProperty, Value = false };
        disabled.Setters.Add(new Setter(Border.BackgroundProperty,
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0F0F0")), "border"));
        disabled.Setters.Add(new Setter(Control.ForegroundProperty,
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AAAAAA"))));
        disabled.Setters.Add(new Setter(UIElement.OpacityProperty, 0.7));
        template.Triggers.Add(disabled);

        return template;
    }
    // 生成缩放动画
    private static BeginStoryboard BuildScaleAction(double to, TimeSpan duration)
    {
        var sb = new Storyboard();

        var sx = new DoubleAnimation(to, duration);
        Storyboard.SetTargetName(sx, "border");
        Storyboard.SetTargetProperty(sx, new PropertyPath("RenderTransform.ScaleX"));

        var sy = new DoubleAnimation(to, duration);
        Storyboard.SetTargetName(sy, "border");
        Storyboard.SetTargetProperty(sy, new PropertyPath("RenderTransform.ScaleY"));

        sb.Children.Add(sx);
        sb.Children.Add(sy);

        return new BeginStoryboard { Storyboard = sb };
    }
    
    public static void SetGoTabStyle(UniformGrid GoTab, Button HomePageBtn, Button DownloadPageBtn, Button SettingsPageBtn, Button AboutPageBtn)
    {
        GoTab.Background = GoTabBackground;
        GoTab.HorizontalAlignment = HorizontalAlignment.Center;  
        GoTab.VerticalAlignment = VerticalAlignment.Bottom;     
        GoTab.Height = 60;     
        GoTab.Margin = new Thickness(0, 0, 0, 2);
        var buttons = new[] { HomePageBtn, DownloadPageBtn, SettingsPageBtn, AboutPageBtn };
        foreach (var btn in buttons)
        { 
            btn.Margin = new Thickness(2.5, 0, 2.5, 15);      
            btn.Foreground = BorderColor_;                    
            btn.Background = Brushes.Transparent;          
            btn.BorderThickness = new Thickness(0.5);
            btn.Width = 65;
            btn.Height = 25;
            btn.FontSize = 14;
            btn.BorderBrush = BorderColor_;
            btn.Cursor = System.Windows.Input.Cursors.Hand;   
            btn.HorizontalContentAlignment = HorizontalAlignment.Center; 
            btn.VerticalContentAlignment = VerticalAlignment.Center;     
            btn.Template = BuildNavButtonTemplate(10);   // 圆角半径 8
        }
        foreach (var btn in buttons)
        {
            btn.MouseEnter += (s, e) =>
            {
                var b = (Button)s;
                b.Background = NavHoverBackground;  // 设置鼠标悬停时的背景色
            };
            btn.MouseLeave += (s, e) =>
            {
                var b = (Button)s;
                b.Background = Brushes.Transparent;  // 恢复按钮背景为透明
            };
        }
    }
    
    private static ControlTemplate BuildNavButtonTemplate(double radius)
    {
        var template = new ControlTemplate(typeof(Button));

        var border = new FrameworkElementFactory(typeof(Border), "bg");
        border.SetValue(Border.CornerRadiusProperty, new CornerRadius(radius));
        border.SetValue(Border.BorderThicknessProperty,
            new System.Windows.Data.Binding(nameof(Control.BorderThickness))
                { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });
        border.SetValue(Border.BorderBrushProperty,
            new System.Windows.Data.Binding(nameof(Control.BorderBrush))
                { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });
        border.SetValue(Border.BackgroundProperty,
            new System.Windows.Data.Binding(nameof(Control.Background))
                { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });

        var cp = new FrameworkElementFactory(typeof(ContentPresenter));
        cp.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
        cp.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
        cp.SetBinding(ContentPresenter.MarginProperty,
            new System.Windows.Data.Binding(nameof(Control.Padding))
                { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });

        border.AppendChild(cp);
        template.VisualTree = border;

        // 悬停
        var hover = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
        hover.Setters.Add(new Setter(Border.BackgroundProperty, NavHoverBackground, "bg"));
        template.Triggers.Add(hover);

        // 按下
        var pressed = new Trigger { Property = Button.IsPressedProperty, Value = true };
        pressed.Setters.Add(new Setter(Border.BackgroundProperty, NavCheckedBackground, "bg"));
        template.Triggers.Add(pressed);

        return template;
    }
    
}