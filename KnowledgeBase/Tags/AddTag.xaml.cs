namespace KnowledgeBase.Tags
{
    /// <summary>
    /// Логика взаимодействия для AddTag.xaml
    /// </summary>
    public partial class AddTag : Window
    {
        Tag SelectedTag;
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
            NewTag window = new NewTag();

            if (Tags_MouseDoubleClick() != null)
            {
                try
                {
                    window.Show();
                    using (KnowledgeBaseContext db = new())
                    {
                        db.Tags.Remove(GetSelectedTag());
                        db.SaveChanges();
                    }
                }
                catch { }
            }
            window.Closed += Window_Closed;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (KnowledgeBaseContext db = new())
            {
                db.Tags.Remove(GetSelectedTag());
                db.SaveChanges();
                Tags.ItemsSource = db.Tags.ToList();
            }
        }

        private Tag Tags_MouseDoubleClick()
        {
            if ((Tag)Tags.SelectedItem != null)
            {
                SelectedTag = (Tag)Tags.SelectedItem;
            }
            return SelectedTag;
        }

        public Tag GetSelectedTag()
        {
            SelectedTag = (Tag)Tags.SelectedItem;
            return SelectedTag;
        }
    }
}
