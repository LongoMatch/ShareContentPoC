using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;

namespace ShareContentPoC.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void OnShareText(object? sender, RoutedEventArgs e)
    {
        App.ShareService.SharePlainText("hello world");
    }

    private void OnSharePdfFile(object? sender, RoutedEventArgs e)
    {
        var stream = AssetLoader.Open(new Uri($"avares://ShareContentPoC/Assets/TestFile.pdf"));
        var tempFilePath = Path.Combine(Path.GetTempPath(), "TestFile.pdf");
        using (var fileStream = File.Create(tempFilePath))
        {
            stream.CopyTo(fileStream);
        }

        App.ShareService.SharePdf(tempFilePath);
    }
}