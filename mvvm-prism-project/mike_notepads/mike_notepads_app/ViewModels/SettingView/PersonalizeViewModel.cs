using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using mike_notepads_app.Comom.Models.AppConfig.Setting;
using mike_notepads_app.Domain.Setting;
using Newtonsoft.Json;
using System.IO;
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
            IsDarkTheme = baseTheme == BaseTheme.Dark;
        }

        void ChangeHue(object? obj)
        {
            var hue = (System.Windows.Media.Color)obj!;

            Theme theme = _paletteHelper.GetTheme();

            theme.PrimaryLight = new ColorPair(hue.Lighten());
            theme.PrimaryMid = new ColorPair(hue);
            theme.PrimaryDark = new ColorPair(hue.Darken());

            _paletteHelper.SetTheme(theme);
            ThemeSettingHandle.SaveThemeSetting(theme);
        }

        void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
            ThemeSettingHandle.SaveThemeSetting(theme);
        }
    }
}
