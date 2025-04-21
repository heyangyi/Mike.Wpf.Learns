using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mike_notepads_app.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private string userName;
        private string password;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DialogResult dialogResult { get; private set; }
        public DelegateCommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        public DialogCloseListener RequestClose { get; }
        
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose.Invoke(dialogResult);
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        public void Login()
        {
            if (UserName == "admin")
            {
                dialogResult = new DialogResult(ButtonResult.OK);
                var parameters = new DialogParameters();
                parameters.Add("isLogin", "ok");
                dialogResult.Parameters = parameters;

                OnDialogClosed();
            }
        }
    }
}
