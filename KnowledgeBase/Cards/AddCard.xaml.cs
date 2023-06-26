namespace KnowledgeBase.Cards;
using KnowledgeBase.Tags;

public partial class AddCard : Window
{
    Step SelectedStep;
    public AddCard()
    {
        InitializeComponent();
        using KnowledgeBaseContext db = new();
        Solution_Tag.ItemsSource = db.Tags.ToList();
        //if (db.Steps is not null) Steps.ItemsSource = db.Steps.ToList();

        db.Tags.Add(new Tag
        {
            Kind = "хуе",
        });
        db.SaveChanges();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        using (KnowledgeBaseContext db = new())
        {
            db.Solutions.Add(new Solution
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

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {

    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        AddStep window = new AddStep();
        window.Show();
        window.Closed += Window_Closed;
    }

    private void Window_Closed(object? sender, EventArgs e)
    {
        using KnowledgeBaseContext db = new();
        Steps.ItemsSource = db.Steps.Where(s => s.SolutionId == 0).ToList();

    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        AddStep window = new AddStep();
        window.Show();
        window.Closed += Window_Closed;
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Steps_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if ((Step)Steps.SelectedItem != null)
        {
            SelectedStep = (Step)Steps.SelectedItem;
        }
    }

    public Step GetSelectedStep()
    {
        return SelectedStep;
    }
}