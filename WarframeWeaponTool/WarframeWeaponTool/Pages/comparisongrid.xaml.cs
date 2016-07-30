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

namespace WarframeWeaponTool.Pages
{
    /// <summary>
    /// Interaction logic for comparisongrid.xaml
    /// </summary>
    public partial class comparisongrid : UserControl, ISwitchable
    {
        public comparisongrid()
        {
            InitializeComponent();
            //Show that this feature is in development.
            sharedMethods.WIP();
        }
        //set screen index
        int screenIndex = 1;

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
    }

}
