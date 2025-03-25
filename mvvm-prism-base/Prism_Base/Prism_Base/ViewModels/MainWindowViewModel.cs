using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace Prism_Base.ViewModels
{
    /// <summary>
    /// BindableBase 是 Prism 提供的基类，实现了 INotifyPropertyChanged 接口，用于在 MVVM 模式中自动通知 UI 层属性的变更。
    /// 通过继承 BindableBase，ViewModel 中的属性可以轻松触发属性变更事件，无需手动编写样板代码
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _regionManager = regionManager;
        }

        public void Navigate(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
