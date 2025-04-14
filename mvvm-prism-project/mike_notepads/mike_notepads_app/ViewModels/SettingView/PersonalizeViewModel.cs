using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mike_notepads_app.ViewModels.SettingView
{
    public class PersonalizeViewModel : BindableBase
    {
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
    }
}
