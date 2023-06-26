namespace KnowledgeBase.Tags
{
    /// <summary>
    /// Логика взаимодействия для AddStep.xaml
    /// </summary>
    public partial class AddStep : Window
    {
        public AddStep()
        {
            InitializeComponent();
            using KnowledgeBaseContext db = new();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (KnowledgeBaseContext db = new())
            {
                db.Steps.Add(new Step
                {
                    Title = Step_Title.Text,
                    Description = Step_Description.Text,
                    SolutionId = 0
                });
            }
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
