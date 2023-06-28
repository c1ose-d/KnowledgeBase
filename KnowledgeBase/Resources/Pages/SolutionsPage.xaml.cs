using KnowledgeBase.Tags;
namespace KnowledgeBase.Resources.Pages;

public partial class SolutionsPage : Page
{
    public SolutionsPage()
    {
        InitializeComponent();

        using KnowledgeBaseContext db = new();
        Solutions.ItemsSource = db.Solutions.Include(s => s.Tag).ToList();
    }

    private void Solutions_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        ViewSolution window = new();
        window.Show();
        window.Closed += Window_Closed;
    }
    private void Window_Closed(object? sender, EventArgs e)
    {
        using KnowledgeBaseContext db = new();
        Solutions.ItemsSource = db.Solutions.Include(s => s.Tag).ToList();

    }
}