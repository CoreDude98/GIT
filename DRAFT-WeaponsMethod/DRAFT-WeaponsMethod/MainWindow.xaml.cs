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

namespace DRAFT_WeaponsMethod
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
        }

        string currentFile = Environment.CurrentDirectory + "\\meleeData.csv";
        string[] meleeWeapons = new string[16];

        private void displayGrid()
        {
            meleeWeapons = File.ReadAllLines(currentFile);
            //display contents of array in datagrid
            //Create array to hold items from csv, size of 5 as there are 5 comma seperated items in each line
            string[] weaponElement = new string[16];
            //Create new list (fileTopic = fileTopic.cs)
            List<weapons> weaponItem = new List<weapons>();
            //split csv into arrays
            for (int i = 0; i < meleeWeapons.Length; i++)
            {
                weaponElement = meleeWeapons[i].Split(',');
                //Add array elements to list
                weaponItem.Add(new weapons()
                {
                    //Item for each column item
                    name = weaponElement[0],
                    type = weaponElement[1],
                    elementaltype = weaponElement[2],
                    damage = double.Parse(weaponElement[3]),
                    impactdmg = double.Parse(weaponElement[4]),
                    puncturedmg = double.Parse(weaponElement[5]),
                    slashdmg = double.Parse(weaponElement[6]),
                    slidedmg = double.Parse(weaponElement[7]),
                    jumpdmg = double.Parse(weaponElement[8]),
                    walldmg = double.Parse(weaponElement[9]),
                    critchance = double.Parse(weaponElement[10])*100,
                    critdamage = double.Parse(weaponElement[11]),
                    statuschance = double.Parse(weaponElement[12])*100,
                    masteryunlock = int.Parse(weaponElement[13]),
                    wpnpolarity = weaponElement[14],
                    stancepolarity = weaponElement[15],
                    addinfo = weaponElement[16]
                });
            }
            //datagrid grabs the list
            wpMeleeDataGridOutput.ItemsSource = weaponItem;
            
        }
    }
}
