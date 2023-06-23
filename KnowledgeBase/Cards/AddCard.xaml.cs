namespace KnowledgeBase.Cards;

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
        using (KnowledgeBaseContext db = new())
        {
            db.Add(new Solution
            {
                Title = Solution_Title.Text,
                Description = Solution_Description.Text,
                TagId = ((Tag)Solution_Tag.SelectedItem).Id
            });
            db.SaveChanges();
        }

        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e) =>
        Close();
}