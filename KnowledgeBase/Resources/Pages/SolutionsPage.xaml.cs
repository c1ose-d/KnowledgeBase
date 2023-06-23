namespace KnowledgeBase.Resources.Pages;

public partial class SolutionsPage : Page
{
    public SolutionsPage()
    {
        InitializeComponent();

        using KnowledgeBaseContext db = new();
        Solutions.ItemsSource = db.Solutions.Include(s => s.Tag).ToList();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e) { }
}