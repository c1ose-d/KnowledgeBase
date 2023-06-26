using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
