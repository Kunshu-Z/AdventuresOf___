using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventuresOf___
{
    public class Area
    {
        //Fields
        public string areaName { get; set; }
        public string areaDisplay { get; set; }
        public string areaDescription { get; set; }
        public string optionOne { get; set; }   
        public string optionTwo { get; set; }

        //Constructor for Area
        public Area(string areaname, string areadisplay, string areadescription, string optionone, string optiontwo)
        {
            areaName = areaname;
            areaDisplay = areadisplay;
            areaDescription = areadescription;
            optionOne = optionone;
            optionTwo = optiontwo;
        }
    }
}
