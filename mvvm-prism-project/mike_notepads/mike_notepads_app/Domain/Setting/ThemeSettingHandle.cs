using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using mike_notepads_app.Comom.Models.AppConfig.Setting;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Media;

namespace mike_notepads_app.Domain.Setting
{
    public static class ThemeSettingHandle
    {
        public static void SaveThemeSetting(Theme theme)
        {
            var json = JsonConvert.SerializeObject(new ThemeModel()
            {
                IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark,
                Color = theme.PrimaryMid.Color
            });
            var themeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppConfig", "Setting", "theme.json");
            Directory.CreateDirectory(Path.GetDirectoryName(themeFilePath)!);
            File.WriteAllText(themeFilePath, json);
        }

        public static void SetTheme()
        {
            PaletteHelper _paletteHelper = new();
            var themeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppConfig", "Setting", "theme.json");
            if (File.Exists(themeFilePath))
            {
                var themeFileContent = File.ReadAllText(themeFilePath);
                var themeModel = JsonConvert.DeserializeObject<ThemeModel>(themeFileContent)!;

                Theme theme = _paletteHelper.GetTheme();
                theme.SetBaseTheme(themeModel.IsDarkTheme ? BaseTheme.Dark : BaseTheme.Light);

                if (themeModel.Color != null)
                {
                    var color = (Color)themeModel.Color;
                    theme.PrimaryLight = new ColorPair(color.Lighten());
                    theme.PrimaryMid = new ColorPair(color);
                    theme.PrimaryDark = new ColorPair(color.Darken());
                }

                _paletteHelper.SetTheme(theme);
            }
        }
    }
}
