using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;

namespace dpProject.Element
{
    public enum ProjectStatus
    {
        InProgress,
        AtRisk,
        ReadyToUpload,
        Delayed
    }
}

namespace dpProject
{
    public sealed record ProjectItem(
        string Title,
        string Description,
        dpProject.Element.ProjectStatus Status,
        double Percent,
        double Progress,
        int TasksDone,
        int TasksTotal,
        int Comments,
        string DueDate,
        IImage? Thumbnail = null);
}

namespace dpProject.Element.Logical.Method
{
    using dpProject;
    using dpProject.Element;

    public static class ProjectCatalog
    {
        private static readonly IReadOnlyList<ProjectItem> Projects = new[]
        {
            new ProjectItem("Infinite Flow — New", "An experimental world of endless possibilities and creative flow.",
                ProjectStatus.AtRisk, 45, 38, 4, 10, 3, "Jul 02"),
            new ProjectItem("Dragon Chase — Ep. 03", "Full action sequence with fire VFX, 4 animators, 12 scenes total.",
                ProjectStatus.InProgress, 78, 75, 9, 12, 5, "Jul 12"),
            new ProjectItem("Neon City — Walk Cycle", "Character locomotion library for NPC set. 6 unique walk cycles.",
                ProjectStatus.ReadyToUpload, 92, 100, 6, 6, 2, "Jun 28"),
            new ProjectItem("Solstice Short Film", "Award submission short. Rigging pass complete, lip sync pending.",
                ProjectStatus.Delayed, 31, 28, 5, 18, 8, "Jun 20"),
            new ProjectItem("Vex Robot — Rig & Anim", "Mechanical rig with IK/FK switching and 9 constraint-driven sub-meshes.",
                ProjectStatus.InProgress, 60, 60, 6, 10, 1, "Aug 03"),
            new ProjectItem("Lumina — VFX Sims", "Fluid and cloth simulation passes for Act 2. Arnold lighting WIP.",
                ProjectStatus.InProgress, 19, 14, 2, 14, 4, "Aug 21")
        };

        public static IReadOnlyList<ProjectItem> GetAll() => Projects;

        public static IReadOnlyList<ProjectItem> FilterByStatus(
            IEnumerable<ProjectItem> projects,
            ProjectStatus? status)
        {
            if (status is null)
                return projects.ToArray();

            return projects.Where(project => project.Status == status.Value).ToArray();
        }
    }
}
