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
            List<weapons> weaponItem;
            

        }


        wpSettingsWindow win1 = new wpSettingsWindow();
        string currentFile = Environment.CurrentDirectory + "\\meleeData.csv";
        string[] meleeWeapons = new string[16];



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

            }
            ));



            //wpMeleeDataGridOutput.Columns.Remove("addinfo");



            wpMeleeDataGridOutput.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = "Additional Information",
                    CellTemplate = new DataTemplate() { VisualTree = but },
                    DisplayIndex = 17
                    
                }
            );

            



            //addInfoCol.CellTemplate.Template(but);

            //datagrid grabs the list
            //wpMeleeDataGridOutput.ItemsSource = weaponItem;

            //if (cvWeapons != null)
            //{
            //    wpMeleeDataGridOutput.AutoGenerateColumns = true;
            //    wpMeleeDataGridOutput.ItemsSource = cvWeapons;
            //    cvWeapons.Filter = TextFilter;
            //}
        }

        //public bool TextFilter(object o)
        //{
        //    weapons p = (o as weapons);
        //    if (p == null)
        //        return false;

        //    if (p.name.Contains(wpSearchTextInput.Text))
        //        return true;
        //    else
        //        return false;
        //}


        private void wpSearchTextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string searchValue = wpSearchTextInput.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(wpMeleeDataGridOutput.ItemsSource);
            cv.Filter = UserFilter;


            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    cv.Filter = o =>
            //    {
            //        /* change to get data row value */
            //        weapons p = o as weapons;
            //        return (p.name.ToUpper().StartsWith(searchValue.ToUpper()));
            //        /* end change to get data row value */
            //    };
            //}
            //else
            //{

            //}
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(wpSearchTextInput.Text))
                return true;
            else
                return ((item as weapons).name.ToUpper().StartsWith(wpSearchTextInput.Text.ToUpper()));
        }


        //cv.Filter = o =>
        //{
        //    weapons p = o as weapons;
        //    if (t.Name == null)
        //        return false;

        //    if (t.Name.Contains(wpSearchTextInput.Text))
        //        return true;
        //    else
        //        return false;
        //};





        private void wpOptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            
            win1.Show();

        }
    }
}
