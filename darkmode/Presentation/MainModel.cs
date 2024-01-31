using Uno.Extensions.Navigation;
using Uno.Extensions.Toolkit;

namespace darkmode.Presentation;

public partial record MainModel
{
    private INavigator _navigator;
    private IThemeService _themeService;

    public MainModel(
        INavigator navigator,
        IThemeService themeService)
    {
        _navigator = navigator;
        _themeService = themeService;
        Title = "Main Page";

    }

    public string? Title { get; }

    public async Task GoToSecond()
    {
        await _navigator.NavigateRouteForResultAsync<SecondModel>(this, "Second", qualifier: Qualifiers.Dialog);
    }

}
