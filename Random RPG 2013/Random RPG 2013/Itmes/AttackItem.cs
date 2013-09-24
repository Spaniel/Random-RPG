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


    public AttackItem(string ItemName, int price, int damage) : this(ItemName, price, damage, new Dictionary<string,int>()) {} 
   

    public AttackItem(string itemName, int price, int damage, Dictionary<string,int> properties)
      : base(itemName, price)
    {
      Damage = damage;
      Properties = properties; 
       
    }
  }
}
