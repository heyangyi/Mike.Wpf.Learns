using mike_notepads_app.ViewModels;
using mike_notepads_app.ViewModels.SettingView;
using mike_notepads_app.Views;
using mike_notepads_app.Views.SettingViews;
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
        // 首页
        containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
        //主窗体
        containerRegistry.RegisterForNavigation<MainWindow, MainWindowModel>();
        // 备忘录
        containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();

        // 设置
        containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
        // - 关于
        containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();
        // - 个性化
        containerRegistry.RegisterForNavigation<PersonalizeView, PersonalizeViewModel>();
        // - 系统设置
        containerRegistry.RegisterForNavigation<SystemSettingsView, SystemSettingsViewModel>();

        // 待办事项
        containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
    }
}

