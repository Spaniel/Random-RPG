using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class Consumable : Item 
    {
        public Consumable(string itemName, int price)
            : base(itemName, price)
        { }
    }
}
