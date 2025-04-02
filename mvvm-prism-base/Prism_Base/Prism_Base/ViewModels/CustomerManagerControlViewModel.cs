using Prism_Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Base.ViewModels
{
    public class CustomerManagerControlViewModel
    {
        public DelegateCommand AddUserCommand {  get; private set; }
        private IEventAggregator _eventAggregator;
        public CustomerManagerControlViewModel(IEventAggregator eventAggregator)
        {
            AddUserCommand = new DelegateCommand(AddUserHandle);
            _eventAggregator = eventAggregator;
        }

        private void AddUserHandle()
        {
            // TO DO ： 添加客户

            // 发布添加客户成功消息
            _eventAggregator.GetEvent<AddUserSuccessEvent>().Publish(new AddUserSuccessArg() { Id = 1, Name = "张三" });
        }
    }
}
