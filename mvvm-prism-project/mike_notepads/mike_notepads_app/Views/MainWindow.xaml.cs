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

namespace mike_notepads_app;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 窗体按下鼠标跟随跟着移动
        this.colorZoneMaterialDesign.MouseMove += (s, e) =>
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        };

        // 最小化
        this.minBtn.Click += (s, e) =>
        {
            this.WindowState = WindowState.Minimized;
        };

        // 最大化和正常显示
        this.maxBtn.Click += (s, e) =>
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        };

        // 关闭
        this.closeBtn.Click += (s, e) =>
        {
            this.Close();
        };

        this.menuBar.SelectionChanged += (s, e) =>
        {
            // 选中对应的内容
            this.drawerHost.IsLeftDrawerOpen = false;
        };
    }
}