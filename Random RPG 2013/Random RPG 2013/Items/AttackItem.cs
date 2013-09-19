using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class AttackItem : Item 
    {
        //Some Enum that includes what type of weapon (axe, sword, etc).

        public int Damage { get; set; }

        public AttackItem(string itemName, int price, int damage)
            : base(itemName, price)
        {
            this.Damage = damage; 
        }
        
    }
}
