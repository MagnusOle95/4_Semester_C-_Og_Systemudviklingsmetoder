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
        Mage TempMage;

        private void bSeach_Click(object sender, RoutedEventArgs e)
        {
            Mage tempMage = bll.GetMage(Int32.Parse(txfSeachId.Text));
            TempMage = tempMage;
            tbName.Text= tempMage.Name;
            tbIsDark.Text =tempMage.IsDark.ToString();
            
        }

        private void bUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            TempMage.Name = tbName.Text;
            TempMage.IsDark = bool.Parse(tbIsDark.Text);
            bll.updateMage(TempMage);
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            bll.deleteMage(TempMage);
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            Mage mage = new Mage(tbName.Text, Boolean.Parse(tbIsDark.Text));
            bll.addMage(mage);
        }
    }
}

