using System;
using System.Collections.Generic;
using System.Windows;
using button_SearchDataGrid;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace button_SearchDataGrid
{
    public class weapons
    {
        

        public string name
        {
            get; set;
        }

        public string type
        { 
            get; set;
        }

        public string elementaltype
        {
            get; set;
        }

        public double damage
        {
            get; set;
        }

        public double impactdmg
        {
            get; set;
        }

        public double puncturedmg
        {
            get; set;
        }

        public double slashdmg
        {
            get; set;
        }

        public double slidedmg
        {
            get; set;
        }

        public double jumpdmg
        {
            get; set;
        }

        public double walldmg
        {
            get; set;
        }

        public double critchance
        {
            get; set;
        }

        public double critdamage
        {
            get; set;
        }

        public double statuschance
        {
            get; set;
        }

        public int masteryunlock
        {
            get; set;
        }

        public string wpnpolarity
        {
            get; set;
        }

        public string stancepolarity
        {
            get; set;
        }

        public string addinfo
        {
            get; set;
        }

        public weapons(string line)
        {
            string[] parts = line.Split(',');
            this.name = parts[0];
            this.type = parts[1];
            this.elementaltype = parts[2];
            this.damage = Double.Parse(parts[3]);
            this.impactdmg = Double.Parse(parts[4]);
            this.puncturedmg = Double.Parse(parts[5]);
            this.slashdmg = Double.Parse(parts[6]);
            this.slidedmg = Double.Parse(parts[7]);
            this.jumpdmg = Double.Parse(parts[8]);
            this.walldmg = Double.Parse(parts[9]);
            this.critchance = Double.Parse(parts[10]);
            this.critdamage = Double.Parse(parts[11]);
            this.statuschance = Double.Parse(parts[12]);
            this.masteryunlock = int.Parse(parts[13]);
            this.wpnpolarity = parts[14];
            this.stancepolarity = parts[15];
            addInfoList.Add(parts[16]);           
        }

        public static List<string> addInfoList = new List<string>();

        public static void findInfo(int index)
        {
            string addInfoText = addInfoList[index];
            MessageBox.Show(addInfoText);
            
        }
    }
}
