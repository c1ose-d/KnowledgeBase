namespace KnowledgeBase.Tags
{
    /// <summary>
    /// Логика взаимодействия для NewTag.xaml
    /// </summary>
    public partial class NewTag : Window
    {
        public NewTag()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (KnowledgeBaseContext db = new())
            {
                db.Tags.Add(new Tag
                {
                    Kind = Tag_Title.Text
                });
                db.SaveChanges();
            }
            Close();
        }

    }
}
