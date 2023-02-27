using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BilerOgEjere
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
                MessageBox.Show("Database created");
            }
        }

        private void VisBtn_Click(object sender, RoutedEventArgs e)
        {
            BilerListe.Items.Clear();
            foreach (Bil bil in context.Biler)
            {
                BilerListe.Items.Add(bil);
                //if (bil.Firma != null)
                //{
                //    MessageBox.Show(bil.Firma.Navn);
                //}
            }
        }

        private void TilfoejBtn_Click(object sender, RoutedEventArgs e)
        {
            Bil b = new Bil("Kia", 750);
            context.Biler.Add(b);
            context.SaveChanges();
        }

        private void RedigerBtn_Click(object sender, RoutedEventArgs e)
        {
            Bil b = (Bil)BilerListe.SelectedItem;
            b.Name = "Tesla";
            context.SaveChanges();
        }

        private void SoegBtn_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<Bil> fundet = context.Biler.Where(x => x.Name == NameSearch.Text);
            BilerListe.Items.Clear();
            foreach (var bil in fundet)
            {
                BilerListe.Items.Add(bil);
            }
        }

        private void OpretFirma_Click(object sender, RoutedEventArgs e)
        {
            //Firma firma = new Firma();
            //firma.Adresse = "Gaden 2";
            //firma.Navn = "JB";
            //firma.Biler.Add(new Bil("Ford", 555));
            //firma.Biler.Add(new Bil("Chevrolet", 555));
            //context.Firmaer.Add(firma);

            //context.SaveChanges();
        }

        private void Vis_firmaer_Click(object sender, RoutedEventArgs e)
        {
            //FirmaListe.Items.Clear();
            //foreach (Firma f in context.Firmaer)
            //{
            //    FirmaListe.Items.Add(f);
            //}
        }

        private void FirmaListe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //BilerListe.Items.Clear();
            //foreach (Bil b in ((Firma)FirmaListe.SelectedItem).Biler)
            //{
            //    BilerListe.Items.Add(b);
            //}
            ////Eller brug databinding
            //EjerListe.Items.Clear();
            //Firma f = context.Firmaer.Where(fi => fi.FirmaId ==1).FirstOrDefault();
            ////foreach (Ejer ejer in ((Firma)FirmaListe.SelectedItem).Ejere)
            //    foreach (Ejer ejer in f.Ejere)
            //{
            //    EjerListe.Items.Add(ejer);
            //}
        }

        private void OpretEjer_Click(object sender, RoutedEventArgs e)
        {
            Ejer ejer = new Ejer("Jesper Buch");
            ((Firma)FirmaListe.SelectedItem).Ejere.Add(ejer);
            context.SaveChanges();
        }

        private void VisFirmaerPlusBiler_Click(object sender, RoutedEventArgs e)
        {
            //duer ikke
            //mere end en reader
            //foreach (Firma firma in context.Firmaer)
            //{
            //    MessageBox.Show(firma.Navn);
            //    foreach (Bil b in firma.Biler)
            //    {
            //        MessageBox.Show(b.Name);
            //    }
            //}


            //List<Firma> f = new List<Firma>();
            //foreach (Firma firma in context.Firmaer)
            //{
            //    f.Add(firma);
            //}
            //foreach (Firma firma in f)
            //{
            //    MessageBox.Show(firma.Navn);
            //    foreach (Bil bil in firma.Biler)
            //    {
            //        MessageBox.Show(bil.Name);
            //        MessageBox.Show(bil.Firma.Navn);
            //    }
            //}
        }

        private void VisEjersFirmaer_Click(object sender, RoutedEventArgs e)
        {
            foreach (Firma firma in ((Ejer)EjerListe.SelectedItem).Firmaer)
            {
                MessageBox.Show(firma.Navn);
            }
        }

        private void VisBilPlusFirma_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((Bil)BilerListe.SelectedItem).Firma.Navn + ((Bil)BilerListe.SelectedItem).Firma.FirmaId);
        }
    }
}
