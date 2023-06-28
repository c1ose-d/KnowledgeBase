using KnowledgeBase.Cards;
using KnowledgeBase.Resources.Pages;
using DatabaseLibrary;

namespace KnowledgeBase.Tags
{
    public partial class ViewSolution : Window
    {
        Solution? solution;
        public ViewSolution(Solution? solution = null)
        {
            this.solution = solution;
            InitializeComponent();
            using KnowledgeBaseContext db = new();
            Solution_Title.Text = solution?.Title;
            Solution_Tag.Text = solution?.Tag.Kind;
            Solution_Description.Text = solution?.Description;
            StepList.ItemsSource = db.Steps.Where(x => x.SolutionId == solution.Id).ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using KnowledgeBaseContext db = new();
            db.Solutions.Remove(solution);
            db.SaveChanges(); //он говорит, что нихуя не затрагивается, что он несет, блять
        }
    }
}
