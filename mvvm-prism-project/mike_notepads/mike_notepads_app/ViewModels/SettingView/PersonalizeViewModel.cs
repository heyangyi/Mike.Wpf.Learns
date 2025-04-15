using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using mike_notepads_app.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace mike_notepads_app.ViewModels.SettingView
{
    public class PersonalizeViewModel : BindableBase
    {
        private readonly PaletteHelper _paletteHelper = new();
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
        public DelegateCommand<object> ChangeHueCommand { get; set; }


        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
            }
        }

        public PersonalizeViewModel()
        {
            ChangeHueCommand = new DelegateCommand<object>(ChangeHue);
            Theme theme = _paletteHelper.GetTheme();
            var baseTheme = theme.GetBaseTheme();
            if (baseTheme == BaseTheme.Dark)
            {
                IsDarkTheme = true;
            }
            else
            {
                IsDarkTheme = false;
            }
        }

        private void ChangeHue(object? obj)
        {
            var hue = (System.Windows.Media.Color)obj!;

            Theme theme = _paletteHelper.GetTheme();

            theme.PrimaryLight = new ColorPair(hue.Lighten());
            theme.PrimaryMid = new ColorPair(hue);
            theme.PrimaryDark = new ColorPair(hue.Darken());

            _paletteHelper.SetTheme(theme);
        }

        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }
    }
}
