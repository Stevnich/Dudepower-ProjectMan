using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using dpProject.Element.Logical.Method;

namespace dpProject.Element;

public partial class HomeView : UserControl
{
    private readonly IReadOnlyList<ProjectItem> _projects = ProjectCatalog.GetAll();

    public HomeView()
    {
        InitializeComponent();
        CardGrid.ItemsSource = _projects;
        ListGrid.ItemsSource = _projects;
    }

    private void Filter_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is not ToggleButton clicked)
            return;

        foreach (var filter in FilterBar.Children.OfType<ToggleButton>())
            filter.IsChecked = filter == clicked;

        var status = clicked.Tag is string tag &&
                     System.Enum.TryParse<ProjectStatus>(tag, out var selectedStatus)
            ? selectedStatus
            : (ProjectStatus?)null;
        var filteredProjects = ProjectCatalog.FilterByStatus(_projects, status);
        CardGrid.ItemsSource = filteredProjects;
        ListGrid.ItemsSource = filteredProjects;
    }

    private void ViewType_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is not ToggleButton clicked)
            return;

        CardViewButton.IsChecked = clicked == CardViewButton;
        ListViewButton.IsChecked = clicked == ListViewButton;

        CardGrid.IsVisible = Equals(clicked.Tag, "Cards");
        ListGrid.IsVisible = !CardGrid.IsVisible;
    }
}
