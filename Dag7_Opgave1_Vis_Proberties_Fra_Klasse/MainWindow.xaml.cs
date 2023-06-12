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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dag7_Opgave1_Vis_Proberties_Fra_Klasse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person p = new Person();
        public MainWindow()
        {
            InitializeComponent();

            p.Name = "Ulla";
            p.Age = 52;
            p.Weight = 48;
            p.Score = 107;
            p.Accepted = true;

            this.DataContext = p;

        }

        private void bChancePerson_Click(object sender, RoutedEventArgs e)
        {
            p.Name = "Mette Frederiksen";
            p.Age = 80;
            p.Weight = 100;
            p.Score = 0;
            p.Accepted = false;
        }

        private void bPrintPerson_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(p.ToString());
        }
    }
}
