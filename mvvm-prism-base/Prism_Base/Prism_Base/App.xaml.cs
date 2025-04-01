using Prism_Base.ViewModels;
using Prism_Base.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Prism_Base;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
        containerRegistry.RegisterForNavigation<CustomerManagerControl, CustomerManagerControlViewModel>();
        containerRegistry.RegisterForNavigation<SkuManagerControl, SkuManagerControlViewModel>();
        containerRegistry.RegisterForNavigation<SystemManagerControl, SystemManagerControlViewModel>();
        
        // 注册对话服务
        containerRegistry.RegisterDialog<SwitchAccountDialogControl, SwitchAccountDialogControlViewModel>();
    }
}

