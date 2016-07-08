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



namespace anotherMultipleViewTest.AppTest
{
    /// <summary>
    /// Interaction logic for weapons.xaml
    /// </summary>
    public partial class weapons : UserControl, ISwitchable
    {
        public weapons()
        {
            InitializeComponent();
        }



        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void menuSelectLoaded(object sender, RoutedEventArgs e)
        {
            sharedMethods.createMenu((object)sender, 0);




            //List<string> menuList = new List<string>();
            //menuList.Add("Melee Weapon Grid");
            //menuList.Add("Comparison Grid");
            //menuList.Add("Comparison Side by Side");
            //menuList.Add("Inventory");
            //menuList.Add("Stance & Polarity");
            //menuList.Add("About");

            var menu = sender as ComboBox;
            menu.ItemsSource = menuList;
            menu.SelectedIndex = 0;
        }

        private void menuSelectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menu = sender as ComboBox;
            int selectedIndex = menu.SelectedIndex;
            int currentIndex = 0;
            sharedMethods.MenuSelect(sender, selectedIndex, currentIndex);


            //var menu = sender as ComboBox;
            //int selectedIndex = menu.SelectedIndex;
            //if (menu.SelectedIndex != -1)
            //{

            //    if (selectedIndex == 0)
            //    {
            //        Switcher.Switch(new weapons());
            //    }
            //    else
            //    {
            //        if (selectedItem == "TestScreen2")
            //        {
            //            Switcher.Switch(new comparisongrid());
            //        }
            //        else
            //        {
            //            if (selectedItem == "TestScreen2")
            //            {
            //                Switcher.Switch(new comparisonSide());
            //            }
            //            else
            //            {
            //                if (selectedItem == "TestScreen2")
            //                {
            //                    Switcher.Switch(new inventory());
            //                }
            //                else
            //                {
            //                    if (selectedItem == "TestScreen2")
            //                    {
            //                        Switcher.Switch(new stancepolarity());
            //                    }
            //                    else
            //                    {
            //                        if (selectedItem == "TestScreen2")
            //                        {
            //                            Switcher.Switch(new about());
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }

}
