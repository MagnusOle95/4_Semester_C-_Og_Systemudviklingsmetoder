using Dag9_BusinessLogicCore.BLL;
using Dag9_DTOCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Dag9_GuiCore
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MageBll Bll = new MageBll();
        Mage TempMage;
        List<Spell> LeanedSpellList;
        Spell tempSelectedSpell;

        public Window1(Mage mage, MageBll bll)
        {
            TempMage= mage;
            Bll = bll;
            LeanedSpellList= new List<Spell>();
            LeanedSpellList = Bll.getMageSpells(TempMage);
            InitializeComponent();
            showAllLeanedSpells();
            showAllNotLeanedSpells();
            lbLeanedSpells.SelectionChanged += ListBox_SelectionChanged;
            LbNotLeanedSpells.SelectionChanged += ListBox_SelectionChanged;
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            Bll.updateMageLeanedSPells(TempMage, LeanedSpellList);
            this.Close();
        }

        public void showAllLeanedSpells()
        {
            //lbLeanedSpells.Items.Clear();
            foreach (Spell s in LeanedSpellList)
            {
                lbLeanedSpells.Items.Add(s);
            }
        }

        public void showAllNotLeanedSpells()
        {
            List<Spell> SpellList = Bll.getSpells();

            SpellList.Where(spell => !LeanedSpellList.Any(learnedSpell => learnedSpell.SpellID == spell.SpellID)).ToList().
                ForEach(spell => LbNotLeanedSpells.Items.Add(spell));
        }

        private void btForgetSpell_Click(object sender, RoutedEventArgs e)
        {
            if(tempSelectedSpell != null)
            {
                lbLeanedSpells.Items.Remove(tempSelectedSpell);
                LbNotLeanedSpells.Items.Add(tempSelectedSpell);
                LeanedSpellList.Remove(tempSelectedSpell);
                tempSelectedSpell = null;

            }
        }

        private void btLeanSpell_Click(object sender, RoutedEventArgs e)
        {
            if (tempSelectedSpell != null)
            {
                lbLeanedSpells.Items.Add(tempSelectedSpell);
                LbNotLeanedSpells.Items.Remove(tempSelectedSpell);
                LeanedSpellList.Add(tempSelectedSpell);
                tempSelectedSpell = null;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Her finder jeg id,en. 
            var listBox = (ListBox)sender;
            Spell selectedItem = (Spell)listBox.SelectedItem;
            if (selectedItem != null)
            {
                tempSelectedSpell = selectedItem;
            }
        }








    }

}
