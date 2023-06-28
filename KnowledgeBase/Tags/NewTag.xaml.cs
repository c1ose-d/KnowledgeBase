namespace KnowledgeBase.Tags;

public partial class NewTag : Window
{
    public NewTag(Tag? tag = null)
    {
        Tag = tag;

        InitializeComponent();
    }

    private new Tag? Tag { get; set; }

    private void Cancel_Click(object sender, RoutedEventArgs e) =>
        Close();

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        using KnowledgeBaseContext db = new();
        if (Tag == null)
        {
            db.Tags.Add(new Tag
            {
                Kind = Tag_Title.Text
            });
            db.SaveChanges();
        }
        else
        {
            Tag def = db.Tags.Where(t => t.Id == Tag.Id).First();
            def.Kind = Tag_Title.Text;
            db.SaveChanges();
        }
        Close();
    }

}