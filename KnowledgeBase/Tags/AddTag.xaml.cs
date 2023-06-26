using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KnowledgeBase.Tags
{
    /// <summary>
    /// Логика взаимодействия для AddTag.xaml
    /// </summary>
    public partial class AddTag : Window
    {
        public AddTag()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!TagExists())
            {
                using (KnowledgeBaseContext db = new())
                {
                    db.Tags.Add(new Tag
                    { 
                        Kind = Tag_Title.Text
                    });
                    db.SaveChanges();
                    Close();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool TagExists()
        {
            using (KnowledgeBaseContext db = new())
            {
                if (db.Tags.Where(x => x.Kind == Tag_Title.Text).Count() != 0)
                {
                    MessageBox.Show("Тег уже существует", "какой уебищный дизайн окна");
                    return true;
                }
            }
            return false;
        }
    }
}
