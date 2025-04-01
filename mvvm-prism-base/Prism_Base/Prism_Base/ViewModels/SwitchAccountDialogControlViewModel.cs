using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Base.ViewModels
{
    public class SwitchAccountDialogControlViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand confirmCommand { get; private set; }
        public DelegateCommand cancelCommand { get; private set; }
        public DialogResult dialogResult { get; private set; }

        public SwitchAccountDialogControlViewModel()
        {
            confirmCommand = new DelegateCommand(Confirm);
            cancelCommand = new DelegateCommand(OnDialogClosed);
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
            if (parameters.ContainsKey("param1"))
            {
                var param1 = parameters["param1"];
            }
        }

        public void Confirm()
        {
            dialogResult = new DialogResult(ButtonResult.OK);
            var parameters = new DialogParameters();
            parameters.Add("result", "ok");
            dialogResult.Parameters = parameters;

            OnDialogClosed();
        }

        public void cancel()
        {
            dialogResult = new DialogResult(ButtonResult.No);
            var parameters = new DialogParameters();
            parameters.Add("result", "ok");
            dialogResult.Parameters = parameters;

            OnDialogClosed();
        }
    }
}
