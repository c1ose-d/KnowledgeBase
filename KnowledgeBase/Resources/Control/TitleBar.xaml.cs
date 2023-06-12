namespace KnowledgeBase.Resources.Control;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();

        MainWindow = Application.Current.MainWindow;
        MainWindow.SizeChanged += MainWindow_SizeChanged;
    }

    private Window MainWindow { get; set; } = null!;

    private void Min_Click(object sender, RoutedEventArgs e) =>
        MainWindow.WindowState = WindowState.Minimized;

    private void Max_Click(object sender, RoutedEventArgs e)
    {
        switch (MainWindow.WindowState)
        {
            case WindowState.Normal:
                MainWindow.WindowState = WindowState.Maximized;
                break;
            case WindowState.Maximized:
                MainWindow.WindowState = WindowState.Normal;
                break;
        }
    }

    private void Close_Click(object sender, RoutedEventArgs e) =>
        Application.Current.Shutdown();

    private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        switch (MainWindow.WindowState)
        {
            case WindowState.Normal:
                Max.Content = "";
                break;
            case WindowState.Maximized:
                Max.Content = "";
                break;
        }
    }
}