using Avalonia.Controls;
using dpProject.Element.Logical.Method;

namespace dpProject.Element;

public partial class RecentProjectsView : UserControl
{
    public RecentProjectsView()
    {
        InitializeComponent();
        RecentGrid.ItemsSource = ProjectCatalog.GetAll();
    }
}
