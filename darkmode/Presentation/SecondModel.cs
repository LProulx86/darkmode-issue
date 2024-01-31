
using System.ComponentModel;
using Uno.Extensions.Toolkit;

namespace darkmode.Presentation;

public class SecondModel
{
    private readonly IThemeService _themeService;

    private bool _isDark;

    public SecondModel(IThemeService themeService)
    {
        _themeService = themeService;
    }

    public bool IsDark
    {
        get { return _isDark; }
        set
        {
            if (_isDark != value)
            {
                _isDark = value;
            }
        }
    }

    public ICommand ChangeTheme => Command.Create(b => b.Then(async ct => await SetIsDark()));

    private async ValueTask SetIsDark()
    {
        IsDark = !IsDark;
        await _themeService.SetThemeAsync(IsDark ? AppTheme.Dark : AppTheme.Light);
    }
}
