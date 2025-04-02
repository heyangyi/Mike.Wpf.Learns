using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism_Base.Events
{
    public class AddUserSuccessEvent : PubSubEvent<AddUserSuccessArg>
    {
    }
    public class AddUserSuccessArg
    {
        public int Id { get; set; }
        public string Name {  get; set; }
    }
}
