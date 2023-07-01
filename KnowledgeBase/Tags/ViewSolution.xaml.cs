namespace KnowledgeBase.Tags;

public partial class ViewSolution : Window
{
    public ViewSolution(Solution solution)
    {
        Solution = solution;

        InitializeComponent();

        using KnowledgeBaseContext db = new();
        Solution_Title.Text = Solution.Title;
        Solution_Tag.Text = Solution.Tag?.Kind;
        Solution_Description.Text = Solution.Description;
        StepList.ItemsSource = db.Steps.Where(s => s.SolutionId == Solution.Id).ToList();
    }

    private Solution Solution { get; set; }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        using KnowledgeBaseContext db = new();
        Solution def = db.Solutions.Where(s => s.Id == Solution.Id).First();
        db.Solutions.Remove(def);
        db.SaveChanges();
        Close();
    }
}