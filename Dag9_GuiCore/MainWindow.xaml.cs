using Dag9_BusinessLogicCore.BLL;
using Dag9_DTOCore.Model;
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

namespace Dag9_GuiCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        MageBll bll = new MageBll();
        Mage emp;

        private void bSeach_Click(object sender, RoutedEventArgs e)
        {
            emp = bll.GetMage(Int32.Parse(txfSeachId.Text));
            LabSeachNavn.Content= emp.Name;
            LabSeachDark.Content = emp.IsDark.ToString();
        }
    }
}
