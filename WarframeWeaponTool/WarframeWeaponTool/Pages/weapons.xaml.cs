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
            //display menu grid
            displayGrid();
        }
        //index for menu
        int screenIndex = 0;

        //User control code
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        //loads menu and respective code to change menu item
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

        //GlobalVars
        string[] meleeWeapons = new string[0];

        //display grid method
        private void displayGrid()
        {
            //Puts line into meleeWeapons array
            meleeWeapons = File.ReadAllLines(@"Data/meleeData.csv");
            //create array for each attribute of each weapon.
            string[] weaponElement = new string[16];
            //Create new list
            List<weaponData> weaponItem = new List<weaponData>();
            //set dataGrid source
            meleeDataGridOutput.ItemsSource = weaponItem;
            //split csv into arrays
            for (int i = 0; i < meleeWeapons.Length; i++)
            {
                //Split csv s into array
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

            //Create button element.
            FrameworkElementFactory but = new FrameworkElementFactory(typeof(Button));
            
            //Add handler for button click
            but.AddHandler(Button.ClickEvent, new RoutedEventHandler((o, e) =>
            {
                //grab index of button
                int dgIndex = meleeDataGridOutput.SelectedIndex;
                //grab additional info from weaponItem List.
                string additionInfo = weaponItem[dgIndex].addinfo;
                //if there is no additional info:
                if (String.IsNullOrEmpty(additionInfo))
                {
                    //Show message then break
                    MessageBox.Show("There is no additional information to be displayed about this weapon.","No Additional Weapon Information",MessageBoxButton.OK);
                    return;
                }
                //Else show additional info
                MessageBox.Show(additionInfo,"Additional Information",MessageBoxButton.OK);

            }));

            //Add button column to dataGrid.
            meleeDataGridOutput.Columns.Add(
                new DataGridTemplateColumn()
                {
                    //Set celltemplate and viewing index.
                    CellTemplate = new DataTemplate() { VisualTree = but },
                    DisplayIndex = 17

                }
            );

            


        }


        private void searchTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //grab textbox
            TextBox t = (TextBox)sender;
            //grab text from searchbox
            string searchValue = searchTextInput.Text;
            //create ICollectionView for filter and activate filtering method.
            ICollectionView cv = CollectionViewSource.GetDefaultView(meleeDataGridOutput.ItemsSource);
            cv.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            //if string is null/empty, activate no filter.
            if (String.IsNullOrEmpty(searchTextInput.Text))
                return true;
            //else apply filter.
            else
                return ((item as weaponData).name.ToUpper().StartsWith(searchTextInput.Text.ToUpper()));
        }


        

        private void meleeDataGridOutputLoaded(object sender, RoutedEventArgs e)
        {
            //Hide autogenerated column for additional information.
            meleeDataGridOutput.Columns[17].Visibility = Visibility.Collapsed;
            //Set custom Headers
            meleeDataGridOutput.Columns[0].Header = "Extra Info";
            meleeDataGridOutput.Columns[1].Header = "Weapon";
            meleeDataGridOutput.Columns[2].Header = "Type";
            meleeDataGridOutput.Columns[3].Header = "Element";
            meleeDataGridOutput.Columns[4].Header = "Damage";
            meleeDataGridOutput.Columns[5].Header = "Impact";
            meleeDataGridOutput.Columns[6].Header = "Puncture";
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
        }

        //WIP PROGRESS (WIP method launched)
            //public void dataGridHideColumns(string[] viewArray, object sender)
            //{
            //    string[] prevColumnChecked = new string[17];
            //    prevColumnChecked = viewArray;
            //    DataGrid datagrid = (DataGrid)sender;
            //    for (int i = 0; i < 17; i++)
            //    {
            //        if (viewArray[i] == "False")
            //        {
            //            datagrid.Columns[i].Visibility = Visibility.Collapsed;
            //        }
            //        if (viewArray[i] == "True")
            //        {
            //            datagrid.Columns[i].Visibility = Visibility.Visible;
            //        }
            //    }
            //}
        private void wpOptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            //wpOptionsBtn settingswin = new wpOptionsBtn();
            //settingswin.Show();
            sharedMethods.WIP();
        }
        private void filterBtn_Click(object sender, RoutedEventArgs e)
        {
            sharedMethods.WIP();
        }
    }

}
