using mike_notepads_app.ViewModels;
using mike_notepads_app.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace mike_notepads_app;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        // 返回一个窗体，从容器中解析
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
        containerRegistry.RegisterForNavigation<MainWindow, MainWindowModel>();
        containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
        containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
        containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
        containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
    }
}

