using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialTraining
{
    public class FlowControl
    {
        public bool IsFavColorBlue(string color)
        {
            return color.ToLower() == "blue";
        }

        public bool IsFavColorRed(string color)
        {
            return color.ToLower() == "red";
        }

        public bool IsFavColorGreen(string color)
        {
            return color.ToLower() == "green";
        }

        public string PrimaryOrSecondary(string color)
        {
            return
                (
                color.ToLower() == "red" || 
                color.ToLower() == "yellow" ||
                color.ToLower() == "blue" ? "Is Primary" : "Is Secondary"
                );
        }
    }
}
