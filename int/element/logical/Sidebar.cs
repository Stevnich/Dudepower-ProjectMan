using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace dpProject.Element;

public enum AppTab
{
    Home,
    RecentProjects,
    WorkStatistics,
    YoutubeStudio,
    Notifications,
    Settings,
    UserProfile
}

public sealed class AppTabEventArgs(AppTab tab) : EventArgs
{
    public AppTab Tab { get; } = tab;
}

public partial class SidebarView : UserControl
{
    private const double ExpandedWidth = 238;

    public bool IsExpanded { get; private set; } = true;

    public event EventHandler<AppTabEventArgs>? TabSelected;

    public SidebarView()
    {
        InitializeComponent();
    }

    public void SetExpanded(bool expanded)
    {
        IsExpanded = expanded;
        SidebarRoot.Width = expanded ? ExpandedWidth : 0;
    }

    private void Navigation_Checked(object? sender, RoutedEventArgs e)
    {
        if (!IsLoaded)
            return;

        if (sender is RadioButton { Tag: string tabName } &&
            Enum.TryParse<AppTab>(tabName, out var tab))
        {
            TabSelected?.Invoke(this, new AppTabEventArgs(tab));
        }
    }
}
