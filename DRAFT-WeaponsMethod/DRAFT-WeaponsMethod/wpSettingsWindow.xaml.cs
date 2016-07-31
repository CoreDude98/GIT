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
using System.Windows.Shapes;

namespace DRAFT_WeaponsMethod
{
    /// <summary>
    /// Interaction logic for wpSettingsWindow.xaml
    /// </summary>
    public partial class wpSettingsWindow : Window
    {
        public wpSettingsWindow()
        {
            InitializeComponent();
        }

        public string[] columnChecked = new string[17];





        public void selectionChecked()
        {   
            
            columnChecked[0] = "True";

        }

        private void checkboxClick(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            columnChecked[1] = "True";

            if (checkbox.Name == "addinfoCheck")
            {
                columnChecked[0] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "typeCheck")
            {
                columnChecked[2] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "elementaltypeCheck")
            {
                columnChecked[3] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "damageCheck")
            {
                columnChecked[4] = checkbox.IsChecked.ToString();
                columnChecked[5] = columnChecked[4];
                columnChecked[6] = columnChecked[4];
                columnChecked[7] = columnChecked[4];
            }
            if (checkbox.Name == "slidejumpwallCheck")
            {
                columnChecked[8] = checkbox.IsChecked.ToString();
                columnChecked[9] = columnChecked[8];
                columnChecked[10] = columnChecked[8];
            }
            if (checkbox.Name == "critchanceCheck")
            {
                columnChecked[11] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "critdamageCheck")
            {
                columnChecked[12] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "statuschanceCheck")
            {
                columnChecked[13] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "masteryunlockCheck")
            {
                columnChecked[14] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "wpnpolarityCheck")
            {
                columnChecked[15] = checkbox.IsChecked.ToString();
            }
            if (checkbox.Name == "stancepolarityCheck")
            {
                columnChecked[16] = checkbox.IsChecked.ToString();
            }

            MainWindow main = new MainWindow();
            main.dataGridHideColumns(columnChecked, main.wpMeleeDataGridOutput);
        }

        //public void dataGridHideColumns()
        //{
        //    MainWindow main = new MainWindow();

        //    string[] prevColumnChecked = new string[16];
        //    prevColumnChecked = columnChecked;


        //    for (int i = 0; i < 17; i++)
        //    {
        //        if (columnChecked[i] == "False")
        //        {
        //            main.wpMeleeDataGridOutput.Columns[0].Visibility = Visibility.Collapsed;
        //        }
        //        if (columnChecked[i] == "True")
        //        {
        //            if (columnChecked[i] != prevColumnChecked[i])
        //            main.wpMeleeDataGridOutput.Columns[i].Visibility = Visibility.Visible;
        //        }
        //    }
        //}
    }
}
