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

namespace Dag6_Opgave8_C_R_Buttons_StackPanelv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CheckBox> chechBoxList = new List<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();
            cLemon.Checked += Check_in_checkboxes;
            cOrange.Checked += Check_in_checkboxes;
            cBanana.Checked += Check_in_checkboxes;

            cLemon.Unchecked += Check_in_checkboxes;
            cOrange.Unchecked += Check_in_checkboxes;
            cBanana.Unchecked += Check_in_checkboxes;

            rNorth.Checked += Check_in_Radiobuttons;
            rSouth.Checked += Check_in_Radiobuttons;
            rEast.Checked += Check_in_Radiobuttons;
            rVest.Checked += Check_in_Radiobuttons;

            chechBoxList.Add(cLemon);
            chechBoxList.Add(cOrange);
            chechBoxList.Add(cBanana);

        }

        private void Check_in_checkboxes(object sender, RoutedEventArgs e)
        {          
            string s = "Status: ";
            foreach (CheckBox cb in chechBoxList)
            {
                if (cb.IsChecked == true)
                {
                    s += cb.Content + ",";
                }
            }
            cStatusResult.Text = s;
        }

        private void Check_in_Radiobuttons(object sender, RoutedEventArgs e)
        {
            rStatusResult.Text = "Status: " + ((RadioButton)sender).Content;
        }


    }
}
