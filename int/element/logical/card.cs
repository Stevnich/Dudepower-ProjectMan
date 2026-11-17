using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using dpProject.Element.Logical.Method;

namespace dpProject.Element;

public partial class ProjectCard : UserControl
{
    public static readonly StyledProperty<string?> TitleProperty =
        AvaloniaProperty.Register<ProjectCard, string?>(nameof(Title));
    public static readonly StyledProperty<string?> DescriptionProperty =
        AvaloniaProperty.Register<ProjectCard, string?>(nameof(Description));
    public static readonly StyledProperty<ProjectStatus> StatusProperty =
        AvaloniaProperty.Register<ProjectCard, ProjectStatus>(nameof(Status), ProjectStatus.InProgress);
    public static readonly StyledProperty<IImage?> ThumbnailProperty =
        AvaloniaProperty.Register<ProjectCard, IImage?>(nameof(Thumbnail));
    public static readonly StyledProperty<double> PercentProperty =
        AvaloniaProperty.Register<ProjectCard, double>(nameof(Percent));
    public static readonly StyledProperty<double> ProgressProperty =
        AvaloniaProperty.Register<ProjectCard, double>(nameof(Progress));
    public static readonly StyledProperty<int> TasksDoneProperty =
        AvaloniaProperty.Register<ProjectCard, int>(nameof(TasksDone));
    public static readonly StyledProperty<int> TasksTotalProperty =
        AvaloniaProperty.Register<ProjectCard, int>(nameof(TasksTotal));
    public static readonly StyledProperty<int> CommentsProperty =
        AvaloniaProperty.Register<ProjectCard, int>(nameof(Comments));
    public static readonly StyledProperty<string?> DueDateProperty =
        AvaloniaProperty.Register<ProjectCard, string?>(nameof(DueDate));
    public static readonly StyledProperty<IBrush?> StatusBrushProperty =
        AvaloniaProperty.Register<ProjectCard, IBrush?>(nameof(StatusBrush));
    public static readonly StyledProperty<string> StatusTextProperty =
        AvaloniaProperty.Register<ProjectCard, string>(nameof(StatusText), "IN PROGRESS");
    public static readonly StyledProperty<double> RingSweepProperty =
        AvaloniaProperty.Register<ProjectCard, double>(nameof(RingSweep));

    public string? Title { get => GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
    public string? Description { get => GetValue(DescriptionProperty); set => SetValue(DescriptionProperty, value); }
    public ProjectStatus Status { get => GetValue(StatusProperty); set => SetValue(StatusProperty, value); }
    public IImage? Thumbnail { get => GetValue(ThumbnailProperty); set => SetValue(ThumbnailProperty, value); }
    public double Percent { get => GetValue(PercentProperty); set => SetValue(PercentProperty, value); }
    public double Progress { get => GetValue(ProgressProperty); set => SetValue(ProgressProperty, value); }
    public int TasksDone { get => GetValue(TasksDoneProperty); set => SetValue(TasksDoneProperty, value); }
    public int TasksTotal { get => GetValue(TasksTotalProperty); set => SetValue(TasksTotalProperty, value); }
    public int Comments { get => GetValue(CommentsProperty); set => SetValue(CommentsProperty, value); }
    public string? DueDate { get => GetValue(DueDateProperty); set => SetValue(DueDateProperty, value); }
    public IBrush? StatusBrush { get => GetValue(StatusBrushProperty); private set => SetValue(StatusBrushProperty, value); }
    public string StatusText { get => GetValue(StatusTextProperty); private set => SetValue(StatusTextProperty, value); }
    public double RingSweep { get => GetValue(RingSweepProperty); private set => SetValue(RingSweepProperty, value); }

    static ProjectCard()
    {
        StatusProperty.Changed.AddClassHandler<ProjectCard>((card, _) => card.UpdateStatus());
        PercentProperty.Changed.AddClassHandler<ProjectCard>((card, _) => card.UpdateRing());
    }

    public ProjectCard()
    {
        InitializeComponent();
        ActualThemeVariantChanged += (_, _) => UpdateStatus();
        UpdateStatus();
        UpdateRing();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        var (key, text) = ProjectCardAppearance.GetStatus(Status);
        StatusText = text;
        if (Application.Current is { } app &&
            app.TryGetResource(key, ActualThemeVariant, out var resource) &&
            resource is IBrush brush)
        {
            StatusBrush = brush;
        }
    }

    private void UpdateRing() =>
        RingSweep = ProjectCardAppearance.GetRingSweep(Percent);
}
