using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows;

namespace Prism_Base.ViewModels
{
    /// <summary>
    /// BindableBase 是 Prism 提供的基类，实现了 INotifyPropertyChanged 接口，用于在 MVVM 模式中自动通知 UI 层属性的变更。
    /// 通过继承 BindableBase，ViewModel 中的属性可以轻松触发属性变更事件，无需手动编写样板代码
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand SwitchAccountCommand { get; private set; }

        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
            SwitchAccountCommand = new DelegateCommand(SwitchAccount);

            _regionManager = regionManager;
            _dialogService = dialogService;
        }

        public void Navigate(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }

        public void SwitchAccount()
        {
            var parameters = new DialogParameters();
            parameters.Add("param1", "value1");

            _dialogService.Show("SwitchAccountDialogControl", parameters, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    // 确定
                    Application.Current.Shutdown();
                }
                else
                {
                    // 取消
                }
            });
        }
    }
}
