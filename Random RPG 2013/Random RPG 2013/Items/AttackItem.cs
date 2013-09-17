using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class AttackItem : Item 
    {
        // Some Enum with types

        public int Damage { get; set; }

        public AttackItem(string itemname, int price,int damage)
            : base(itemname, price)
        {
            this.Damage = damage; 
        }
        
    }
}
