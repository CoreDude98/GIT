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

namespace WarframeWeaponTool.Pages
{
    /// <summary>
    /// Interaction logic for stancepolarity.xaml
    /// </summary>
    public partial class stancepolarity : UserControl, ISwitchable
    {
        public stancepolarity()
        {
            InitializeComponent();
        }
        //set screen index
        int screenIndex = 4;

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

        //create array template for file.Read
        string[] meleeWeapons = new string[0];
        //Create new list
        List<weaponData> weaponItem = new List<weaponData>();

        //GLOBAL VARIABLES//
        string selectedStancePolarity = null;
        string selectedWeaponPolarity = null;
        string selectedWeaponType = null;
        string polDirectory = @"pack://application:,,,/Resources/Polarities/";


        //Reads CSV and displays the ListBox contents
        public void displayListBox()
        {
            //Read CSV file
            meleeWeapons = File.ReadAllLines(@"Data/meleeData.csv");
            //create Array for attributes
            string[] weaponElement = new string[0];
            //split csv into arrays
            for (int i = 0; i < meleeWeapons.Length; i++)
            {
                //Split comma-seperated-values into weaponElement array.
                weaponElement = meleeWeapons[i].Split(',');
                //Add array elements to list
                weaponItem.Add(new weaponData()
                {
                    //get;set; weapon attributes
                    name = weaponElement[0],
                    type = weaponElement[1],
                    wpnpolarity = weaponElement[14],
                    stancepolarity = weaponElement[15],
                });
                //Adds name to list box                
                weaponsListBox.Items.Add(weaponElement[0]);
            }
        }

        public void displayStancePolImages()
        {
            //If weapon has a stance polarity 
            if (!String.IsNullOrEmpty(selectedStancePolarity))
            {
                //Set margin, find image file, set image source to image filename
                Thickness m = stancePolLbl.Margin;
                m.Left = 223;
                stancePolLbl.Margin = m;

                stancePolLbl.Content = selectedStancePolarity;
                string stancePol = selectedStancePolarity.Trim().Replace(" ", "_");
                stancePolImg.Source = new BitmapImage(new Uri(polDirectory + stancePol + ".png"));
            }
            //Else say 'no stance polarity', set margin to align with title, delete any previous images
            else
            {
                Thickness m = stancePolLbl.Margin;
                m.Left = 189;
                stancePolLbl.Margin = m;
                stancePolImg.Source = null;
                stancePolLbl.Content = "No Stance Polarity";
            }
        }

        public void displayWpnPolImages()
        {
            //If weapon has a polarity
            if (selectedWeaponPolarity != "")
            {
                //VARIABLES//
                string wpnPols = selectedWeaponPolarity;
                string wpnPol1 = null;
                string wpnPol2 = null;
                string wpnPol1FileName = null;
                string wpnPol2FileName = null;

                //If weapon polarity string contains ';' (If 2 polarities this will be true, otherwise false)
                if (wpnPols.Contains(";"))
                {
                    //split the phrase either side the ';', set filenames
                    string[] split = wpnPols.Split(new char[] { ';' });
                    wpnPol1 = split[0].Trim();
                    wpnPol2 = split[1].Trim();
                    wpnPol1FileName = split[0].Trim().Replace(" ", "_");
                    wpnPol2FileName = split[1].Trim().Replace(" ", "_");

                    //if weapon polarities are the same
                    if (wpnPol1FileName == wpnPol2FileName)
                    {
                        //Show '2 x POLARITY'
                        wpnPol1MultiplierLbl.Content = "2";
                        x1.Content = "x";
                        wpnPol1Lbl.Content = wpnPol1;
                        wpnPol2MultiplierLbl.Content = null;
                        x2.Content = null;
                        wpnPol2Lbl.Content = null;
                    }
                    //if weapon polarities are unique
                    else
                    {
                        //show '1 x POLARITY A' and '1 x POLARITY B'.
                        wpnPol1MultiplierLbl.Content = "1";
                        x1.Content = "x";
                        wpnPol1Lbl.Content = wpnPol1;
                        wpnPol2MultiplierLbl.Content = "1";
                        x2.Content = "x";
                        wpnPol2Lbl.Content = wpnPol2;
                    }
                }
                //if only 1 weapon polarity
                else
                {
                    //show '1 x POLARITY'
                    wpnPol1MultiplierLbl.Content = "1";
                    x1.Content = "x";
                    wpnPol1Lbl.Content = selectedWeaponPolarity;
                    wpnPol1FileName = selectedWeaponPolarity.Trim().Replace(" ", "_");
                    //Clear previous 2nd images and labels
                    wpnPol2Img.Source = null;
                    x2.Content = null;
                    wpnPol2Lbl.Content = null;
                    wpnPol2MultiplierLbl.Content = null;

                }

                //show 1st wepaon polarity image
                wpnPol1Img.Source = new BitmapImage(new Uri(polDirectory + wpnPol1FileName + ".png"));
                //If wpnPol2 exists and is unique
                if (wpnPol2 != null && wpnPol1 != wpnPol2)
                {
                    //show 2nd weapon polarity image
                    wpnPol2Img.Source = new BitmapImage(new Uri(polDirectory + wpnPol2FileName + ".png"));
                }
                //Set label margins
                Thickness m = wpnPol1Lbl.Margin;
                m.Left = 370;
                wpnPol1Lbl.Margin = m;
            }
            //If no weapon polarities
            else
            {
                //set label margin, clear all other labels/images
                Thickness m = wpnPol1Lbl.Margin;
                m.Left = 315;
                wpnPol1Lbl.Margin = m;
                wpnPol1Lbl.Content = "No Weapon Polarity";
                wpnPol1Img.Source = null;
                wpnPol2Img.Source = null;
                x1.Content = null;
                x2.Content = null;
                wpnPol2Lbl.Content = null;
                wpnPol1MultiplierLbl.Content = null;
                wpnPol2MultiplierLbl.Content = null;
            }
        }


        public void displayStanceImages()
        {
            //VARIABLES//
            //set wpnType to the selectedWeaponType. 
            string wpnType = selectedWeaponType.Trim().Replace(" ", "_"); //"Sword and Shield" => "Sword_and_Shield"
            wpnTypeStance1Img.Source = null;
            wpnTypeStance2Img.Source = null;
            wpnTypeStance3Img.Source = null;
            string stance1FileName = null;
            string stance2FileName = null;
            string stance3FileName = null;

            //If wpnType = "specificweapontype", set fileNames
            if (wpnType == "Blade_and_Whip")
            {
                stance1FileName = "DefiledSnapdragon";
            }
            if (wpnType == "Claws")
            {
                stance1FileName = "FourRiders";
                stance2FileName = "MaliciousRaptor";
                stance3FileName = "VermillionStorm";
            }
            if (wpnType == "Daggers")
            {
                stance1FileName = "HomingFang";
                stance2FileName = "PointedWind";
            }
            if (wpnType == "Dual_Daggers")
            {
                stance1FileName = "GnashingPayara";
                stance2FileName = "SinkingTalon";
            }
            if (wpnType == "Dual_Swords")
            {
                stance1FileName = "CrossingSnakes";
                stance2FileName = "SwirlingTiger";
            }
            if (wpnType == "Fists")
            {
                stance1FileName = "FracturingWind";
                stance2FileName = "GaiasTragedy";
                stance3FileName = "SeismicPalm";
            }
            if (wpnType == "Glaives")
            {
                stance1FileName = "AstralTwilight";
                stance2FileName = "GleamingTalon";
            }
            if (wpnType == "Gunblade")
            {
                stance1FileName = "HighNoon";
            }
            if (wpnType == "Hammers")
            {
                stance1FileName = "CrushingRuin";
                stance2FileName = "ShatteringStorm";
            }
            if (wpnType == "Heavy_Blade")
            {
                stance1FileName = "CleavingWhirlwind";
                stance2FileName = "RendingCrane";
                stance3FileName = "TempoRoyale";
            }
            if (wpnType == "Machetes")
            {
                stance1FileName = "SunderingWeave";
            }
            if (wpnType == "Nikanas")
            {
                stance1FileName = "BlindJustice";
                stance2FileName = "DecisiveJudgement";
                stance3FileName = "TranquilCleave";
            }
            if (wpnType == "Nunchaku")
            {
                stance1FileName = "AtlantisVulcan";
            }
            if (wpnType == "Polearms")
            {
                stance1FileName = "BleedingWillow";
                stance2FileName = "ShimmeringBlight";
            }
            if (wpnType == "Rapiers")
            {
                stance1FileName = "VulpineMask";
            }
            if (wpnType == "Scythes")
            {
                stance1FileName = "ReapingSpiral";
                stance2FileName = "StalkingFan";
            }
            if (wpnType == "Sparring")
            {
                stance1FileName = "BrutalTide";
                stance2FileName = "GrimFury";
            }
            if (wpnType == "Staves")
            {
                stance1FileName = "ClashingForest";
                stance2FileName = "FlailingBranch";
            }
            if (wpnType == "Swords")
            {
                stance1FileName = "CrimsonDervish";
                stance2FileName = "IronPhoenix";
                stance3FileName = "VengefulRevenant";
            }
            if (wpnType == "Sword_and_Shield")
            {
                stance1FileName = "EleventhStorm";
                stance2FileName = "Harbinger";
            }
            if (wpnType == "Tonfas")
            {
                stance1FileName = "GeminiCross";
            }
            if (wpnType == "Whips")
            {
                stance1FileName = "BurningWasp";
                stance2FileName = "CoilingViper";
            }

            string stanceDirectory = @"pack://application:,,,/Resources/Melee_Stances/" + wpnType + "/";

            //If stances exist, display images
            if (stance1FileName != null)
            {
                wpnTypeStance1Img.Source = new BitmapImage(new Uri(stanceDirectory + stance1FileName + ".png"));
            }
            if (stance2FileName != null)
            {
                wpnTypeStance2Img.Source = new BitmapImage(new Uri(stanceDirectory + stance2FileName + ".png"));
            }
            if (stance3FileName != null)
            {
                wpnTypeStance3Img.Source = new BitmapImage(new Uri(stanceDirectory + stance3FileName + ".png"));
            }
        }

        private void weaponsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Grab listbox from sender
            ListBox listBox = (ListBox)sender;
            //grab current Index from listbox
            int index = listBox.SelectedIndex;

            //Set global variables
            selectedStancePolarity = weaponItem[index].stancepolarity;
            selectedWeaponPolarity = weaponItem[index].wpnpolarity;
            selectedWeaponType = weaponItem[index].type;

            //launch image/data methods
            displayStancePolImages();
            displayWpnPolImages();
            displayStanceImages();
        }

        private void weaponsListBoxLoaded(object sender, RoutedEventArgs e)
        {

            //Set index an launch displayListBox method.
            ListBox listBox = (ListBox)sender;
            listBox.SelectedIndex = 0;
            displayListBox();

        }
    }

}