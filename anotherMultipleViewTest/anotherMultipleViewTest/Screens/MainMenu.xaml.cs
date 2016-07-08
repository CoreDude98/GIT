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
using PageSelector;

namespace anotherMultipleViewTest.Screens
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl, ISwitchable
    {
        public MainMenu()
        {
            InitializeComponent();
        }



        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void button1Click(object sender, RoutedEventArgs e)
        {
            pageSelector.messageBox("mum");
        }

        private void comboBoxLoaded(object sender, RoutedEventArgs e)
        {
            List<string> menu = new List<string>();
            menu.Add("TestScreen1");
            menu.Add("TestScreen2");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = menu;
            comboBox.SelectedIndex = -1;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var comboBox = sender as ComboBox;
            
            if (comboBox.SelectedIndex != -1)
            {
                string selectedItem = comboBox.SelectedItem.ToString();
                if (selectedItem == "TestScreen1")
                {
                    pageSelector.messageBox("Loading Test Screen 1");
                    Switcher.Switch(new TestScreen1());
                }
                else
                {
                    if (selectedItem == "TestScreen2")
                    {
                        pageSelector.messageBox("Loading Test Screen 2");
                        Switcher.Switch(new TestScreen2());
                    }
                }
            }
            
            
            
        }
    }
}
