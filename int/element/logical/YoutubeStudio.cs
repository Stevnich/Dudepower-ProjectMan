using System;
using System.ComponentModel;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace dpProject.Element;

public partial class YoutubeStudioView : UserControl
{
    private static readonly Uri StudioUri = new("https://studio.youtube.com/");

    public YoutubeStudioView()
    {
        InitializeComponent();
    }

    private void OpenStudio_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo(StudioUri.AbsoluteUri)
            {
                UseShellExecute = true
            });
        }
        catch (Exception exception) when (
            exception is Win32Exception or InvalidOperationException or PlatformNotSupportedException)
        {
            StatusMessage.Text = $"Couldn't open YouTube Studio: {exception.Message}";
        }
    }
}
