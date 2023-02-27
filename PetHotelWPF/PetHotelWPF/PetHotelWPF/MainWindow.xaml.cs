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
using PetHotelWPF.DAL;
using System.Data.Entity;

namespace PetHotelWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private PetHotelContext context = new PetHotelContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource customerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("customerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            //System.Windows.Data.CollectionViewSource employeeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeeViewSource")));



            // After the data is loaded call the DbSet<T>.Local property
            // to use the DbSet<T> as a binding source.

            context.Customers.Load();
            customerViewSource.Source = context.Customers.Local;

            context.Employees.Load();
            comboBoxEmployees.ItemsSource = context.Employees.Local;


            context.Pets.Load();
            comboBoxPets.ItemsSource = context.Pets.Local;


        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var pet in context.Pets.ToList())
            {
                if (pet.Customer == null)
                {
                    context.Pets.Remove(pet);
                }
            }

            context.SaveChanges();
            // Refresh the grids so the database generated values show up.
            this.customerDataGrid.Items.Refresh();
            this.petsDataGrid.Items.Refresh();

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.context.Dispose();
        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void filter_button_Click(object sender, RoutedEventArgs e)
        {
            //filter the pets
            var minAge = -1; //no filter
            var maxAge = Int32.MaxValue; //no filter
            if (MinAgeBox.Text.Length>0)
                minAge = Int32.Parse(MinAgeBox.Text);
            if (MaxAgeBox.Text.Length>0)
            {
                maxAge = Int32.Parse(MaxAgeBox.Text);
            }
            bool isChecked = (bool)IsGuestCheckBox?.IsChecked;
            var s = from pet in context.Pets
                        where pet.Age>=minAge && pet.Age<=maxAge && pet.IsGuestNow==isChecked
                        orderby pet.PetName
                        select pet;
            petListBox.ItemsSource = s.ToList();
            petListBox.Items.Refresh();


            /*foreach (var pet in context.Pets.ToList())
            {

            }*/
        }

        private void AssignEmployee_Click(object sender, RoutedEventArgs e)
        {

            // cmbColors.SelectedItem = typeof(Colors).GetProperty("Blue");
            if (comboBoxEmployees.SelectedItem!=null && comboBoxPets.SelectedItem!=null)
            {
                Employee employee = (Employee) comboBoxEmployees.SelectedItem;
                Pet pet  = (Pet) comboBoxPets.SelectedItem;
                //the line below will do the same, but not neccessary, since entity framework
                //will save the changes automatically since the employee object is already
                //referring to an object in the database
                // context.Employees.Find(employee.ID).AddPet(pet);
                employee.AddPet(pet);
                context.SaveChanges();
                this.petsDataGrid.Items.Refresh();

            }
            else
            {
                MessageBox.Show("You must select both an employee and a Pet","Error");

            }


        }

        private void allPetsButton_Click(object sender, RoutedEventArgs e)
        {
            var s = from pet in context.Pets select pet;
            petListBox.ItemsSource = s.ToList();
            petListBox.Items.Refresh();
        }
    }
}
