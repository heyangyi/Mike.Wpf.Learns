using mike_notepads_app.Comom.Models;
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
        public MainWindowModel()
        {
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
        }

        private ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        private void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "HomePlus", Name = "首页", NameSpace = "HomeView" });
            MenuBars.Add(new MenuBar() { Icon = "ReceiptTextCheckOutline", Name = "待办事项", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Icon = "BookmarkMultiple", Name = "备忘录", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Icon = "CogTransferOutline", Name = "设置", NameSpace = "SettingView" });
        }
    }
}
