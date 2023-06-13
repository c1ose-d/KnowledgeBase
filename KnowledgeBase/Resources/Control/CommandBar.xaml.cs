using KnowledgeBase.Cards;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Navigation;

namespace KnowledgeBase.Resources.Control;

public partial class CommandBar : UserControl
{
    public CommandBar() =>
        InitializeComponent();

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        AddCard window = new AddCard();
        window.Show();
    }
}