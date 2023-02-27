using Dag8_Opgave1_MinFørste_EF_App.DAL;
using Dag8_Opgave1_MinFørste_EF_App.Model;
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

namespace Dag8_Opgave1_MinFørste_EF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BilContext context = new BilContext();
        public MainWindow()
        {
            InitializeComponent();
            //context.Database.EnsureDeleted();
            bool created = context.Database.EnsureCreated();
            if (created)
            {
                initBilerOgPersoner();
                MessageBox.Show("Database created");
            }
        }

        private void initBilerOgPersoner()
        {
            //Laver biler. 
            context.Biler.Add(new Bil("Mazda", 2000, true));
            context.Biler.Add(new Bil("Mercedes", 1800, false));
            context.Biler.Add(new Bil("BMW", 2500, false));

            //Laver personer. 
            context.Persons.Add(new Person("Per",22));
            context.Persons.Add(new Person("Morten", 45));

            context.SaveChanges();
        }


        private void bVisListe_Click(object sender, RoutedEventArgs e)
        {
            Liste1.Items.Clear();
            foreach (Bil bil in context.Biler)
            {
                Liste1.Items.Add(bil);
            }
        }

        private void bOpretbil_Click(object sender, RoutedEventArgs e)
        {

            context.Biler.Add(new Bil("Mazda", 2000,true));
            context.SaveChanges();
        }

        private void bSeach_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<Bil> result = context.Biler.Where(x => x.Name == txfSøg.Text);
            Liste1.Items.Clear();
            foreach (Bil bil in result)
            {
                Liste1.Items.Add(bil);
            }

        }
    }
}
