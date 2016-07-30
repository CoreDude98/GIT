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
            wpMeleeDataGridOutput.Loaded += SetMinWidths;
            


        }

        
        string currentFile = Environment.CurrentDirectory + "\\meleeData.csv";
        string[] meleeWeapons = new string[16];

        public void SetMinWidths(object source, EventArgs e)
        {
            foreach (var column in wpMeleeDataGridOutput.Columns)
            {
                column.MinWidth = column.ActualWidth;
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void displayGrid()
        {
            meleeWeapons = File.ReadAllLines(currentFile);
            //display contents of array in datagrid
            
            string[] weaponElement = new string[16];
            //Create new list (fileTopic = fileTopic.cs)
            List<weapons> weaponItem = new List<weapons>();
            //ListCollectionView collection = new ListCollectionView(weaponItem);
            wpMeleeDataGridOutput.ItemsSource = weaponItem;
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
                    critchance = double.Parse(weaponElement[10]) * 100,
                    critdamage = double.Parse(weaponElement[11]),
                    statuschance = double.Parse(weaponElement[12]) * 100,
                    masteryunlock = int.Parse(weaponElement[13]),
                    wpnpolarity = weaponElement[14],
                    stancepolarity = weaponElement[15],
                    addinfo = weaponElement[16]
                });
            }


           

            //DataGridTemplateColumn addInfoCol = new DataGridTemplateColumn();

            //addInfoCol.Header = "Additional Information";
            //addInfoCol.DisplayIndex = 17;






            FrameworkElementFactory but = new FrameworkElementFactory(typeof(Button));

            

            but.AddHandler(Button.ClickEvent, new RoutedEventHandler((o, e) => 
            {
                int dgIndex = wpMeleeDataGridOutput.SelectedIndex;
                string additionInfo = weaponItem[dgIndex].addinfo;

                MessageBox.Show(additionInfo);

            }));

            wpMeleeDataGridOutput.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = "Additional Information",
                    CellTemplate = new DataTemplate() { VisualTree = but },
                    DisplayIndex = 17
                    
                }
            );


            

        }


        private void wpSearchTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string searchValue = wpSearchTextInput.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(wpMeleeDataGridOutput.ItemsSource);
            cv.Filter = UserFilter;
            
            

        }

        private bool UserFilter(object item)
        {
            
            if (String.IsNullOrEmpty(wpSearchTextInput.Text))
                return true;
            else
                return ((item as weapons).name.ToUpper().StartsWith(wpSearchTextInput.Text.ToUpper()));
        }


        private void wpOptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            wpSettingsWindow settingswin = new wpSettingsWindow();
            settingswin.Show();

        }

        private void wpMeleeDataGridOutputLoaded(object sender, RoutedEventArgs e)
        {
            wpMeleeDataGridOutput.Columns[17].Visibility = Visibility.Collapsed;
            wpMeleeDataGridOutput.Columns[0].Header = "Extra Info";
            wpMeleeDataGridOutput.Columns[1].Header = "Weapon";
            wpMeleeDataGridOutput.Columns[2].Header = "Type";
            wpMeleeDataGridOutput.Columns[3].Header = "Element";
            wpMeleeDataGridOutput.Columns[4].Header = "Dmg";
            wpMeleeDataGridOutput.Columns[5].Header = "Impact";
            wpMeleeDataGridOutput.Columns[6].Header = "Punct";
            wpMeleeDataGridOutput.Columns[7].Header = "Slash";
            wpMeleeDataGridOutput.Columns[8].Header = "Slide";
            wpMeleeDataGridOutput.Columns[9].Header = "Jump";
            wpMeleeDataGridOutput.Columns[10].Header = "Wall";
            wpMeleeDataGridOutput.Columns[11].Header = "Crit%";
            wpMeleeDataGridOutput.Columns[12].Header = "CritX";
            wpMeleeDataGridOutput.Columns[13].Header = "Proc%";
            wpMeleeDataGridOutput.Columns[14].Header = "Unlock";
            wpMeleeDataGridOutput.Columns[15].Header = "Weapon Pols";
            wpMeleeDataGridOutput.Columns[16].Header = "Stance Pols";
            //wpMeleeDataGridOutput.ColumnWidth. = true;

            //wpMeleeDataGridOutput.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Auto);
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
