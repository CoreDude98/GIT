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

namespace DRAFT_StanceView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            displayGrid();

            //Image i = new Image();
            //BitmapImage source = new BitmapImage();

            //src.BeginInit();
            //src.UriSource = new Uri("picture.jpg", UriKind.Relative);
            //src.EndInit();

            stancePol.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Madurai_Pol.png"));


        }

        string currentFile = Environment.CurrentDirectory + "\\meleeData.csv";
        string[] meleeWeapons = new string[16];




        public void displayGrid()
        {
            meleeWeapons = File.ReadAllLines(currentFile);
            //display contents of array in datagrid

            string[] weaponElement = new string[16];
            //Create new list (fileTopic = fileTopic.cs)
            List<weapons> weaponItem = new List<weapons>();
            //ListCollectionView collection = new ListCollectionView(weaponItem);
            //split csv into arrays
            for (int i = 0; i < meleeWeapons.Length; i++)
            {
                weaponElement = meleeWeapons[i].Split(',');
                //Add array elements to list
                weaponItem.Add(new weapons()
                {
                    //Item for each column item
                    name = weaponElement[0],
                    weaponpolarity = weaponElement[14],
                    stancepolarity = weaponElement[15],
                });
                weaponsListBox.Items.Add(weaponElement[0]);
            }
        }

        private void weaponsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string item = listBox.SelectedItem.ToString();
            int index = listBox.SelectedIndex;
            /*weaponsListBox*/;
        }
    }
}
