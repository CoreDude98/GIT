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
using System.IO;
using System.ComponentModel;

namespace button_SearchDataGrid
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
        List<weapons> weaponList;

        private void weaponsDataGridLoaded(object sender, RoutedEventArgs e)
        {
            
            displayGrid();
        }

        public void displayGrid()
        {
            string filePath = "C:\\Users\\coreyu\\Source\\Repos\\GIT\\button+SearchDataGrid\\button+SearchDataGrid\\bin\\Debug\\meleeData.csv";
                 var weapon = new List<weapons>();


            using (StreamReader reader = new StreamReader(filePath))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    weapon.Add(new weapons(line));
                }
            }
            // set field
            this.weaponList = weapon;

            // populate datagrid
            weaponsDataGrid.ItemsSource = weapon;
        }

        private void addInfoButtonClick(object sender, RoutedEventArgs e)
        {
            int index = weaponsDataGrid.SelectedIndex;
            MessageBox.Show(addInfoList[index]);
        }
    }

}
