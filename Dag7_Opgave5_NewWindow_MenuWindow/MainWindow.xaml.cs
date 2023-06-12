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
using System.Xml.Linq;

namespace Dag7_Opgave5_NewWindow_MenuWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> People = new ObservableCollection<Person>();
        public MainWindow()
        {
            InitializeComponent();
            People.Add(new Person("Frank", 22, 120, 2, false));
            People.Add(new Person("Morten", 23, 90, 0, false));
            People.Add(new Person("Lasse", 23, 89, 1000, true));

            this.DataContext = People;

            liste.ItemsSource = People;

        }

        private void createNewPerson(object sender, RoutedEventArgs e)
        {
            People.Add(new Person());
        }

        private void newWindowEditPerson(object sender, RoutedEventArgs e)
        {
          var edit = new Window1((Person)liste.SelectedItem);
          //edit.Closed += Edit_Dialog_Closed; //Bruges ikke i denne opgave
          edit.ShowDialog();

        }

        ////Bruges ikke i dette tilfælde.
        //private void Edit_Dialog_Closed(object sender, EventArgs e)
        //{
        //    liste.Items.Refresh();
        //}

    }
}
