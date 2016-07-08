using anotherMultipleViewTest.AppTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace anotherMultipleViewTest
{
    public static class sharedMethods
    {

        public static void messageBox(string text)
        {
            MessageBox.Show(text);
        }

        public static void MenuSelect(object sender, int selectedIndex, int currentIndex)
        {
            if (selectedIndex != -1)
            {

                if (selectedIndex == 0)
                {
                    Switcher.Switch(new weapons());
                }
                else
                {
                    if (selectedIndex == 1)
                    {
                        Switcher.Switch(new comparisongrid());
                    }
                    else
                    {
                        if (selectedIndex == 2)
                        {
                            Switcher.Switch(new comparisonSide());
                        }
                        else
                        {
                            if (selectedIndex == 3)
                            {
                                Switcher.Switch(new inventory());
                            }
                            else
                            {
                                if (selectedIndex == 4)
                                {
                                    Switcher.Switch(new stancepolarity());
                                }
                                else
                                {
                                    if (selectedIndex == 5)
                                    {
                                        Switcher.Switch(new about());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

       public static void createMenu(object sender, int selectedIndex)
        {
            List<string> menuList = new List<string>();
            menuList.Add("Melee Weapon Grid");
            menuList.Add("Comparison Grid");
            menuList.Add("Comparison Side by Side");
            menuList.Add("Inventory");
            menuList.Add("Stance & Polarity");
            menuList.Add("About");

            var menu = sender as ComboBox;
            menu.ItemsSource = menuList;
            menu.SelectedIndex = selectedIndex;
        }
    }
}
