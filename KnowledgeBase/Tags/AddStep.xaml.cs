namespace KnowledgeBase.Tags;

public partial class AddStep : Window
{
    public AddStep()
    {
        InitializeComponent();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (Application.Current.Properties["Step"] as Step != null)
        {
            ((Step)Application.Current.Properties["Step"]).Title = Step_Title.Text;
            ((Step)Application.Current.Properties["Step"]).Description = Step_Description.Text;
        }
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e) =>
        Close();
}