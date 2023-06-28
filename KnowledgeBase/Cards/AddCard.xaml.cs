namespace KnowledgeBase.Cards;
using KnowledgeBase.Tags;

public partial class AddCard : Window
{
    public AddCard()
    {
        InitializeComponent();
        using KnowledgeBaseContext db = new();
        Solution_Tag.ItemsSource = db.Tags.ToList();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        using KnowledgeBaseContext db = new();
        db.Solutions.Add(new Solution
        {
            Title = Solution_Title.Text,
            Description = Solution_Description.Text,
            TagId = ((Tag)Solution_Tag.SelectedItem).Id
        });
        int solutionId = db.Solutions.Last().Id;
        foreach (Step step in Steps.Items)
        {
            step.SolutionId = solutionId;
            db.Steps.Add(step);
        }
        db.SaveChanges();

        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e) =>
        Close();

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Properties["Step"] = new Step();
        AddStep window = new();
        window.Show();
        window.Closed += Window_Closed;
    }

    private void Window_Closed(object? sender, EventArgs e) =>
        Steps.Items.Add(Application.Current.Properties["Step"] as Step);

    private void Delete_Click(object sender, RoutedEventArgs e) =>
        Steps.Items.Remove(Steps.SelectedItem as Step);
}