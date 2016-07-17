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

namespace DRAFT_StanceView
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
            displayStancePolImages();
            displayWpnPolImages();
            displayStanceImages();
            


        }

        string currentFile = Environment.CurrentDirectory + "\\meleeData.csv";
        string[] meleeWeapons = new string[16];
        




        public void displayGrid()
        {
            meleeWeapons = File.ReadAllLines(currentFile);
            //display contents of array in datagrid

            string[] weaponElement = new string[2];
            //Create new list (fileTopic = fileTopic.cs)
            List<weapons> weaponItem = new List<weapons>();
            //ListCollectionView collection = new ListCollectionView(weaponItem);
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
                    weaponpolarity = weaponElement[14],
                    stancepolarity = weaponElement[15],
                });
                weaponsListBox.Items.Add(weaponElement[0]);


            }
        }

        public void displayStancePolImages()
        {
            string selectedStancePolarity = "Vazarin Pol"; //STANCE POLARITY NAME NEEDS TO GO HERE//

            if (selectedStancePolarity != null)
            {
                stancePolLbl.Content = selectedStancePolarity;
                string stancePol = selectedStancePolarity.Trim().Replace(" ", "_");
                stancePolImg.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\" + stancePol + ".png"));
            }
            else
            {
                Thickness m = stancePolLbl.Margin;
                m.Left = 176;
                stancePolLbl.Margin = m;
                stancePolLbl.Content = "No Stance Polarity";
            }




        }

        public void displayWpnPolImages()
        {
            string selectedWeaponPolarity = null; //STANCE POLARITY NAME NEEDS TO GO HERE//
            if (selectedWeaponPolarity != null)
            {
                //string wpnPols = "Naramon Pol; Naramon Pol".Trim();
                string wpnPols = selectedWeaponPolarity;
                string wpnPol1 = null;
                string wpnPol2 = null;
                string wpnPol1FileName = null;
                string wpnPol2FileName = null;

                if (wpnPols.Contains(";"))
                {
                    string[] split = wpnPols.Split(new char[] { ';' });
                    wpnPol1 = split[0].Trim();
                    wpnPol2 = split[1].Trim();
                    wpnPol1FileName = split[0].Trim().Replace(" ", "_");
                    wpnPol2FileName = split[1].Trim().Replace(" ", "_");
                    if (wpnPol1FileName == wpnPol2FileName)
                    {
                        wpnPol1MultiplierLbl.Content = "2";
                        x1.Content = "x";
                        wpnPol1Lbl.Content = wpnPol1;
                        wpnPol2MultiplierLbl.Content = null;
                        x2.Content = null;
                        wpnPol2Lbl.Content = null;
                    }
                    else
                    {
                        wpnPol1MultiplierLbl.Content = "1";
                        x1.Content = "x";
                        wpnPol1Lbl.Content = wpnPol1;
                        wpnPol2MultiplierLbl.Content = "1";
                        x2.Content = "x";
                        wpnPol2Lbl.Content = wpnPol2;
                    }
                }
                else
                {
                    wpnPol1MultiplierLbl.Content = "1";
                    x1.Content = "x";
                    wpnPol1Lbl.Content = selectedWeaponPolarity;
                    wpnPol1FileName = selectedWeaponPolarity.Trim().Replace(" ", "_");
                    
                }



                wpnPol1Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\" + wpnPol1FileName + ".png"));

                if (wpnPol2 != null && wpnPol1 != wpnPol2)
                {
                    wpnPol2Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\" + wpnPol2FileName + ".png"));

                }
            }
            else
            {
                Thickness m = wpnPol1Lbl.Margin;
                m.Left = 294;
                wpnPol1Lbl.Margin = m;
                wpnPol1Lbl.Content = "No Weapon Polarity";
            }
            //string wpnPols = selectedWeaponPolarity.Trim();
            


        }

        public void displayStanceImages()
        {
            string selectedWeaponType = "Whips";
            string wpnType = selectedWeaponType.Trim().Replace(" ", "_");
            string stance1FileName = null;
            string stance2FileName = null;
            string stance3FileName = null;
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
            if (wpnType == "Fist")
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
            if (wpnType == "Rapier")
            {
                stance1FileName = "VlupineMask";
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
            if (wpnType == "Swords_and_Shield")
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

            if (stance1FileName != null)
            {
                wpnTypeStance1Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Melee_Stances\\" + wpnType + "\\" + stance1FileName + ".png"));
            }
            if (stance2FileName != null)
            {
                wpnTypeStance2Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Melee_Stances\\" + wpnType + "\\" + stance2FileName
                 + ".png"));
            }
            if (stance3FileName != null)
            {
                wpnTypeStance3Img.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Melee_Stances\\" + wpnType + "\\" + stance3FileName + ".png"));
            }
        }

        private void weaponsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string item = listBox.SelectedItem.ToString();
            int index = listBox.SelectedIndex;
            
            /*weaponsListBox*/;
        }
    }
}
