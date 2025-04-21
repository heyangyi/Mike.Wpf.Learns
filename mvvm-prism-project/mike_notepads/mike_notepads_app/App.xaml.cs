using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using mike_notepads_app.Comom;
using mike_notepads_app.Comom.Models.AppConfig.Setting;
using mike_notepads_app.Domain.Setting;
using mike_notepads_app.ViewModels;
using mike_notepads_app.ViewModels.SettingView;
using mike_notepads_app.Views;
using mike_notepads_app.Views.SettingViews;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace mike_notepads_app;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        // 设置主题
        ThemeSettingHandle.SetTheme();

        // 返回一个窗体，从容器中解析
        return Container.Resolve<MainWindow>();
    }

    protected override void OnInitialized()
    {
        //var dialogService = Container.Resolve<IDialogService>();
        //dialogService.ShowDialog("LoginView", callback =>
        //{
        //    if (callback.Result == ButtonResult.OK)
        //    {
        var service = App.Current.MainWindow.DataContext as IConfigureService;
        if (service != null)
            service.ConfigMenu();

        base.OnInitialized();
        //    }
        //    else
        //    {
        //        Application.Current.Shutdown();
        //    }
        //});
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // 首页
        containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
        // 登录
        containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
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

