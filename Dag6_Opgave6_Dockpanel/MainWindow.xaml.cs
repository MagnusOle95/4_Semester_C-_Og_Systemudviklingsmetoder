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

namespace Dag6_Opgave6_Dockpanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bNord.Click += b_Click;
            bSyd.Click += b_Click;
            bOest.Click += b_Click;
            bVest.Click += b_Click;
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {

            tCenter.Text += "\n" + ((Button)sender).Content;
        }

    }
}
