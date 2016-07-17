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
            displayImages();
            


        }

        string currentFile = Environment.CurrentDirectory + "\\meleeData.csv";
        string[] meleeWeapons = new string[16];
        




        public void displayGrid()
        {
            meleeWeapons = File.ReadAllLines(currentFile);
            //display contents of array in datagrid

            string[] weaponElement = new string[2];
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

        public void displayImages()
        {
            string selectedStancePolarity = null; //STANCE POLARITY NAME NEEDS TO GO HERE//
            string selectedWeaponPolarity = null; //STANCE POLARITY NAME NEEDS TO GO HERE//
            string imageName = null;

            string stancePols = selectedStancePolarity;
            //string wpnPol = selectedWeaponPolarity;
            string wpnPol = "Naramon Pol; Mad; ";

            if (wpnPol.Contains(";"))
            {
                wpnPol.Trim();
                string[] split = wpnPol.Split(new char[] { ';' });
                string wpnPol1 = split[0].Trim();
                string wpnPol2 = split[1].Trim();
            }



            //stancePolImg.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\" + imageName + ".png"));
            //wpnPol1Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\" + imageName + ".png"));
            //wpnPol2Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\" + imageName + ".png"));


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
