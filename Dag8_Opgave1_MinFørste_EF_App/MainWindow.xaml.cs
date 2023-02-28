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
        private Person TempPerson { get; set; }

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

            VisListe();
        }

        private void initBilerOgPersoner()
        {
            //Laver personer. 
            Person p1 = new Person("Per", 22);
            Person p2= new Person("Morten", 45);
            context.Persons.Add(p1);
            context.Persons.Add(p2);

            //Laver biler. 
            Bil b1 = new Bil("Mazda", 2000, true,p1);
            Bil b2 = new Bil("Mercedes", 1800, false,p2);
            Bil b3 = new Bil("BMW", 2500, false,p1);
            context.Biler.Add(b1);
            context.Biler.Add(b2);
            context.Biler.Add(b3);
           
            context.SaveChanges();

        }


        private void VisListe()
        {
            Liste1.Items.Clear();
            foreach (Bil bil in context.Biler)
            {
                Liste1.Items.Add(bil);
            }
            liste2.Items.Clear();
            foreach (Person p in context.Persons)
            {
                liste2.Items.Add(p);
            }

        }

        private void bOpretbil_Click(object sender, RoutedEventArgs e)
        {

            if(TempPerson != null)
            {
                Bil b = new Bil("Mazda", 2000, true, TempPerson);
                context.Biler.Add(b);
                context.SaveChanges();

                Liste1.Items.Add(b);
                }
            
            
        }

        private void bSeach_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<Bil> result;

            if (TempPerson == null)
            {
                result = context.Biler.Where(x => x.Name == txfSøg.Text);
            }
            else
            {
                result = context.Biler.Where(x => x.Name == txfSøg.Text && x.Ejer.PERSONID == TempPerson.PERSONID);
            }
            
            Liste1.Items.Clear();
            foreach (Bil bil in result)
            {
                Liste1.Items.Add(bil);
            }

        }

        private void bOpretPerson_Click(object sender, RoutedEventArgs e)
        {
            Person p = new Person("Frank", 89);
            context.Persons.Add(p);
            context.SaveChanges();
            liste2.Items.Add(p);    
        }

        private void liste2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox l = (ListBox)sender;
            Person p = (Person)l.SelectedItem;

            TempPerson = p;

            if (TempPerson != null)
            {
                IQueryable<Bil> result = context.Biler.Where(x => x.Ejer.PERSONID == p.PERSONID);
                Liste1.Items.Clear();
                foreach (Bil bil in result)
                {
                    Liste1.Items.Add(bil);
                }
            }
        }

        private void bResetLister_Click(object sender, RoutedEventArgs e)
        {
            TempPerson = null;
            VisListe();
        }

        //Tjek


    }
}
