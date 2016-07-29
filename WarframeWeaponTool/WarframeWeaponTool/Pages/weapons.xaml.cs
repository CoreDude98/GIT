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
using WarframeWeaponTool.Classes;
using System.IO;
using System.ComponentModel;

namespace WarframeWeaponTool.Pages
{
    /// <summary>
    /// Interaction logic for weapons.xaml
    /// </summary>
    public partial class weapons : UserControl, ISwitchable
    {
        public weapons()
        {
            InitializeComponent();

            displayGrid();
            //List<weaponData> weaponItem;

        }
        int screenIndex = 0;

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void menuSelectLoaded(object sender, RoutedEventArgs e)
        {
            var menu = sender as ComboBox;
            menu.SelectedIndex = screenIndex;
            menu.ItemsSource = sharedMethods.createMenu(sender);
        }

        private void menuSelectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menu = sender as ComboBox;
            int selectedIndex = menu.SelectedIndex;
            int currentIndex = screenIndex;
            sharedMethods.MenuSelect(sender, selectedIndex, currentIndex);
        }

        string[] meleeWeapons = new string[16];

        public void SetMinWidths(object source, EventArgs e)
        {
            foreach (var column in meleeDataGridOutput.Columns)
            {
                column.MinWidth = column.ActualWidth;
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void displayGrid()
        {
            meleeWeapons = File.ReadAllLines(Environment.CurrentDirectory + "//Data//meleeData.csv");
            //display contents of array in datagrid

            string[] weaponElement = new string[16];
            //Create new list (fileTopic = fileTopic.cs)
            List<weaponData> weaponItem = new List<weaponData>();
            
            meleeDataGridOutput.ItemsSource = weaponItem;
            //split csv into arrays
            for (int i = 0; i < meleeWeapons.Length; i++)
            {
                weaponElement = meleeWeapons[i].Split(',');
                //Add array elements to list
                weaponItem.Add(new weaponData()
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
                    critchance = double.Parse(weaponElement[10]) * 100,
                    critdamage = double.Parse(weaponElement[11]),
                    statuschance = double.Parse(weaponElement[12]) * 100,
                    masteryunlock = int.Parse(weaponElement[13]),
                    wpnpolarity = weaponElement[14],
                    stancepolarity = weaponElement[15],
                    addinfo = weaponElement[16]
                });
            }

            FrameworkElementFactory but = new FrameworkElementFactory(typeof(Button));



            but.AddHandler(Button.ClickEvent, new RoutedEventHandler((o, e) =>
            {
                int dgIndex = meleeDataGridOutput.SelectedIndex;
                string additionInfo = weaponItem[dgIndex].addinfo;

                MessageBox.Show(additionInfo);

            }));

            meleeDataGridOutput.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = "Additional Information",
                    CellTemplate = new DataTemplate() { VisualTree = but },
                    DisplayIndex = 17

                }
            );

            


        }


        private void searchTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string searchValue = searchTextInput.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(meleeDataGridOutput.ItemsSource);
            //if (searchValue == "Search")
            //{
            //    return;
            //}
            cv.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {

            if (String.IsNullOrEmpty(searchTextInput.Text))
                return true;
            else
                return ((item as weaponData).name.ToUpper().StartsWith(searchTextInput.Text.ToUpper()));
        }


        private void wpOptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            //wpOptionsBtn settingswin = new wpOptionsBtn();
            //settingswin.Show();

        }

        private void meleeDataGridOutputLoaded(object sender, RoutedEventArgs e)
        {
            
            
            meleeDataGridOutput.Columns[17].Visibility = Visibility.Collapsed;
            meleeDataGridOutput.Columns[0].Header = "Extra Info";
            meleeDataGridOutput.Columns[1].Header = "Weapon";
            meleeDataGridOutput.Columns[2].Header = "Type";
            meleeDataGridOutput.Columns[3].Header = "Element";
            meleeDataGridOutput.Columns[4].Header = "Dmg";
            meleeDataGridOutput.Columns[5].Header = "Impact";
            meleeDataGridOutput.Columns[6].Header = "Punct";
            meleeDataGridOutput.Columns[7].Header = "Slash";
            meleeDataGridOutput.Columns[8].Header = "Slide";
            meleeDataGridOutput.Columns[9].Header = "Jump";
            meleeDataGridOutput.Columns[10].Header = "Wall";
            meleeDataGridOutput.Columns[11].Header = "Crit%";
            meleeDataGridOutput.Columns[12].Header = "CritX";
            meleeDataGridOutput.Columns[13].Header = "Proc%";
            meleeDataGridOutput.Columns[14].Header = "Unlock";
            meleeDataGridOutput.Columns[15].Header = "Weapon Pols";
            meleeDataGridOutput.Columns[16].Header = "Stance Pols";

            
            
            //meleeDataGridOutput.ColumnWidth. = true;

            //meleeDataGridOutput.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Auto);
        }

       
        public void dataGridHideColumns(string[] viewArray, object sender)
        {
            string[] prevColumnChecked = new string[17];
            prevColumnChecked = viewArray;

            DataGrid datagrid = (DataGrid)sender;

            for (int i = 0; i < 17; i++)
            {
                if (viewArray[i] == "False")
                {

                    datagrid.Columns[i].Visibility = Visibility.Collapsed;
                }
                if (viewArray[i] == "True")
                {
                    datagrid.Columns[i].Visibility = Visibility.Visible;
                }
            }
        }
    }

}
