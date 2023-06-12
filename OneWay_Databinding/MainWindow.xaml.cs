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

namespace OneWay_Databinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person;
        public MainWindow()
        {
            InitializeComponent();

            person = new Person { Name = "John Doe", Age = 30 };
            this.DataContext = person;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            person.Age = 80;
            person.Name = "Frank";
        }
    }
}
