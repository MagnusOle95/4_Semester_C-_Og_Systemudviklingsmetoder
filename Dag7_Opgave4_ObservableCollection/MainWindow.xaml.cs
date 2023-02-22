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

namespace Dag7_Opgave4_ObservableCollection
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

            People.Add(new Person("Frank", 22 ,120 ,2 , false));
            People.Add(new Person("Morten", 23, 90, 0, false));
            People.Add(new Person("Lasse", 23, 89, 1000, true));

            tfName.DataContext = People;
            tfAge.DataContext = People;
            tfWeight.DataContext = People;
            tfScore.DataContext = People;
            cbAccepted.DataContext = People;

            liste.ItemsSource = People;

        }

        private void bAddPerson_Click(object sender, RoutedEventArgs e)
        {
            People.Add(new Person());
        }
    }
}
