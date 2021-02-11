using System;
using System.Collections.Generic;

namespace EssentialTraining
{
    public class SimpleArray
    {
        public string[] GroceryList;
        public List<string> Sauses { get; set; }

        public SimpleArray()
        {
            GroceryList = new string[4] { "bread", "milk", "egg", "cheese" };
            Sauses = new List<string>();
            Sauses.Add("Red Sauce");
        }

        public string makeString()
        {
            return "There are " + GroceryList.Length + " and there are: " + GroceryList.ToString();
        }

        public bool isSauceAwesome(string sauce) {
            return Sauses.Contains(sauce);
        }

        static void Main(string[] args) 
        {
        }
    }

    public class Dictionary
    {
        public Dictionary<string, string> Contacts { get; set; }

        public Dictionary()
        {
            Contacts = new Dictionary<string, string>();
        }

        public string getNumber(string name)
        {
            return Contacts[name];
        }
    }
}


