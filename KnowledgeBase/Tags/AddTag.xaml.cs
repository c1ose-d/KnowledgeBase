namespace KnowledgeBase.Tags;

public partial class AddTag : Window
{
    public AddTag()
    {
        InitializeComponent();
        using KnowledgeBaseContext db = new();
        Tags.ItemsSource = db.Tags.ToList();
        db.SaveChanges();
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        NewTag window = new NewTag();
        window.Show();
        window.Closed += Window_Closed;
    }

    private void Window_Closed(object? sender, EventArgs e)
    {
        using KnowledgeBaseContext db = new();
        Tags.ItemsSource = db.Tags.ToList();
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        NewTag window = new((Tag)Tags.SelectedItem);
        window.Show();
        window.Closed += Window_Closed;
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        using KnowledgeBaseContext db = new();
        db.Tags.Remove((Tag)Tags.SelectedItem);
        db.SaveChanges();
        Tags.ItemsSource = db.Tags.ToList();
    }

    private void Tags_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        NewTag window = new((Tag)Tags.SelectedItem);
        window.Show();
        window.Closed += Window_Closed;
    }
}