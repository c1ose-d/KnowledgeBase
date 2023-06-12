namespace KnowledgeBase;

public partial class MainWindow : Window
{
    public MainWindow() =>
        InitializeComponent();

    private void Window_Loaded(object sender, RoutedEventArgs e) =>
        MainFrame.Navigate(new SolutionsPage());
}