using Avalonia.Controls;
using dpProject.Element.Logical.Method;

namespace dpProject.Element;

public partial class WorkStatisticsView : UserControl
{
    public WorkStatisticsView()
    {
        InitializeComponent();
        ProgressList.ItemsSource = ProjectCatalog.GetAll();
    }
}
