using mike_notepads_app.Comom.Models;
using mike_notepads_app.Comom.Models.MainWindow;
using mike_notepads_app.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace mike_notepads_app.ViewModels
{
    public class MainWindowModel : BindableBase
    {
        private ObservableCollection<MenuBar> menuBars = new ObservableCollection<MenuBar>();
        /// <summary>
        /// 菜单集合
        /// </summary>
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 系统导航菜单
        /// </summary>
        public DelegateCommand<MenuBar> MenuNavigationCommand { get; private set; }
        /// <summary>
        /// 返回命令
        /// </summary>
        public DelegateCommand GoBackCommand { get; private set; }
        /// <summary>
        /// 前进命令
        /// </summary>
        public DelegateCommand GoForwardCommand { get; private set; }

        private IRegionManager _regionManager;
        private IRegionNavigationJournal _regionNavigationJournal;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="regionManager"></param>
        public MainWindowModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            MenuNavigationCommand = new DelegateCommand<MenuBar>(MenuNavigation);
            GoBackCommand = new DelegateCommand(GoBack);
            GoForwardCommand = new DelegateCommand(GoForward);

            // 生成菜单
            CreateMenuBar();
        }

        /// <summary>
        /// 生成菜单
        /// </summary>
        private void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "HomePlus", Name = "首页", NameSpace = "HomeView" });
            MenuBars.Add(new MenuBar() { Icon = "ReceiptTextCheckOutline", Name = "待办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "BookmarkMultiple", Name = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "CogTransferOutline", Name = "设置", NameSpace = "SettingView" });
        }

        /// <summary>
        /// 菜单导航
        /// </summary>
        /// <param name="menuBar"></param>
        private void MenuNavigation(MenuBar menuBar)
        {
            if (menuBar == null || string.IsNullOrWhiteSpace(menuBar.NameSpace))
                return;

            _regionManager.RequestNavigate(PrismManager.MainWindowContentRegionName, menuBar.NameSpace, parameters =>
            {
                if (parameters.Success)
                {
                    _regionNavigationJournal = parameters.Context!.NavigationService.Journal;
                }
            });
        }

        /// <summary>
        /// 返回
        /// </summary>
        private void GoBack()
        {
            if (_regionNavigationJournal != null && _regionNavigationJournal.CanGoBack)
            {
                _regionNavigationJournal.GoBack();
            }
        }

        /// <summary>
        /// 前进
        /// </summary>
        private void GoForward()
        {
            if (_regionNavigationJournal != null && _regionNavigationJournal.CanGoForward)
            {
                _regionNavigationJournal.GoForward();
            }
        }
    }
}
