using mike_notepads_app.Comom.Models.MainWindow;
using mike_notepads_app.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mike_notepads_app.ViewModels
{
    public class SettingViewModel : BindableBase
    {
        private ObservableCollection<MenuBar> menuBars;
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; }
        }

        public DelegateCommand<MenuBar> MenuNavigationCommand { get; set; }
        private readonly IRegionManager _regionManager;

        public SettingViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            MenuNavigationCommand = new DelegateCommand<MenuBar>(MenuNavigation);
            menuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
        }
            
        void CreateMenuBar()
        {
            menuBars.Add(new MenuBar() { Icon = "add", Name = "个性化", NameSpace = "PersonalizeView" });
            menuBars.Add(new MenuBar() { Icon = "add", Name = "系统设置", NameSpace = "SystemSettingsView" });
            menuBars.Add(new MenuBar() { Icon = "add", Name = "关于", NameSpace = "AboutView" });
        }

        void MenuNavigation(MenuBar menuBar)
        {
            _regionManager.RequestNavigate(PrismManager.SettingViewContentRegionName, menuBar.NameSpace, parameters => { });
        }
    }
}
