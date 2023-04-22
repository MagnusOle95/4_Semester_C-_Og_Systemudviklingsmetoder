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
            lbMages.SelectionChanged += ListBox_SelectionChanged;
            //Sætter alle mages.
            updateMageList();

        }

        MageBll bll = new MageBll();
        Mage TempMage;

        private void bSeach_Click(object sender, RoutedEventArgs e)
        {
            Mage tempMage = bll.GetMage(Int32.Parse(txfSeachId.Text));
            TempMage = tempMage;
            tbName.Text= tempMage.Name;
            tbIsDark.Text =tempMage.IsDark.ToString();

            updateMageSpellList(tempMage.MageId);

        }

        private void bUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            TempMage.Name = tbName.Text;
            TempMage.IsDark = bool.Parse(tbIsDark.Text);
            bll.updateMage(TempMage);
            updateMageList();
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            bll.deleteMage(TempMage);
            updateMageList();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            Mage mage = new Mage(tbName.Text, Boolean.Parse(tbIsDark.Text));
            bll.addMage(mage);
            updateMageList();
        }

        public void updateMageList()
        {
            lbMages.Items.Clear();
            List<Mage> mageList = bll.getMages();
            foreach (Mage m in mageList)
            {
                lbMages.Items.Add(m);
            }
        }

        public void updateMageSpellList(int id)
        {
            lbSpells.Items.Clear();
            List<Spell> MageSpellList = bll.getMageSpells(id);
            foreach (Spell s in MageSpellList)
            {
                lbSpells.Items.Add(s);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Her finder jeg id,en. 
            var listBox = (ListBox)sender;
            var selectedItem = listBox.SelectedItem;
            string s = selectedItem.ToString();
            string[] stringSplit = s.Split();

            //Samme kode som i søg. 
            Mage tempMage = bll.GetMage(Int32.Parse(stringSplit[1]));
            TempMage = tempMage;
            tbName.Text = tempMage.Name;
            tbIsDark.Text = tempMage.IsDark.ToString();

            updateMageSpellList(tempMage.MageId);

            //Dette fjernes. 
        }




    }
}

