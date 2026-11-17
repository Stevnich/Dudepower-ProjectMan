using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Svg.Skia;
using dpProject.Element;

namespace dpProject;

public partial class MainWindow : Window
{
    private const string MaximizeIcon = "/asset/ico/maximize.svg";
    private const string RestoreIcon = "/asset/ico/restore.svg";

    private readonly Dictionary<AppTab, Control> _pages = new();
    private bool _ready;
    private AppTab _currentTab = AppTab.Home;

    public MainWindow()
    {
        InitializeComponent();
        if (!OperatingSystem.IsMacOS())
        {
            using var iconStream = AssetLoader.Open(
                new Uri("avares://dpProject/asset/icon.ico"));
            Icon = new WindowIcon(iconStream);
        }

        _pages[AppTab.Home] = new HomeView();
        PageHost.Content = _pages[AppTab.Home];
        SetupTopBar();
        _ready = true;
    }

    private void SetupTopBar()
    {
        if (OperatingSystem.IsMacOS())
        {
            ExtendClientAreaChromeHints =
                Avalonia.Platform.ExtendClientAreaChromeHints.PreferSystemChrome;
            ExtendClientAreaTitleBarHeightHint = -1;
            MacInset.IsVisible = true;
        }
        else
        {
            WinControls.IsVisible = true;
        }
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (!_ready)
            return;

        if (change.Property == WindowStateProperty)
        {
            MaxIcon.Path = WindowState == WindowState.Maximized
                ? RestoreIcon
                : MaximizeIcon;
        }
        else if (change.Property == OffScreenMarginProperty)
        {
            RootGrid.Margin = OffScreenMargin;
        }
    }

    private void TopBar_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            return;

        if (e.ClickCount == 2)
            ToggleMaximize();
        else
            BeginMoveDrag(e);
    }

    private void Sidebar_TabSelected(object? sender, AppTabEventArgs e)
    {
        var tab = e.Tab;
        if (!_pages.TryGetValue(tab, out var page))
        {
            page = CreatePage(tab);
            _pages.Add(tab, page);
        }

        PageHost.IsTransitionReversed = (int)tab < (int)_currentTab;
        PageHost.Content = page;
        _currentTab = tab;
    }

    private static Control CreatePage(AppTab tab) => tab switch
    {
        AppTab.RecentProjects => new RecentProjectsView(),
        AppTab.WorkStatistics => new WorkStatisticsView(),
        AppTab.YoutubeStudio => new YoutubeStudioView(),
        AppTab.Notifications => new NotificationsView(),
        AppTab.Settings => new SettingsView(),
        AppTab.UserProfile => new UserProfileView(),
        _ => new HomeView()
    };

    private void TogglePanel_Click(object? sender, RoutedEventArgs e) =>
        SidebarPanel.SetExpanded(!SidebarPanel.IsExpanded);

    private void Minimize_Click(object? sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void Maximize_Click(object? sender, RoutedEventArgs e) =>
        ToggleMaximize();

    private void Close_Click(object? sender, RoutedEventArgs e) =>
        Close();

    private void ToggleMaximize() =>
        WindowState = WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
}
