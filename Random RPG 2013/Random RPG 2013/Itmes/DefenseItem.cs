using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class DefenseItem : Item 
    {
        public enum DefenseKind { Helmet, Gloves, Boots, ChestArmor };

        int Defense;

        public DefenseItem(string itemName, int price, int defense) : this(itemName, price, defense, new Dictionary<string, int> ()) { }

        public DefenseItem(string itemName, int price, int defense, Dictionary<string, int> properties)
            :base(itemName, price)
        {
            Defense = defense; 
        }


    }
}
