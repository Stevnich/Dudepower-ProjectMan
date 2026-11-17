namespace dpProject.Element.Logical.Method;

public static class ProjectCardAppearance
{
    public static (string ResourceKey, string Label) GetStatus(ProjectStatus status) =>
        status switch
        {
            ProjectStatus.AtRisk => ("StatusAtRiskBrush", "AT RISK"),
            ProjectStatus.ReadyToUpload => ("StatusReadyBrush", "READY TO UPLOAD"),
            ProjectStatus.Delayed => ("StatusDelayedBrush", "DELAYED"),
            _ => ("StatusInProgressBrush", "IN PROGRESS")
        };

    public static double GetRingSweep(double percent) =>
        System.Math.Clamp(percent, 0, 100) * 3.6;
}
