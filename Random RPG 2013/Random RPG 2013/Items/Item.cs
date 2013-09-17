using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Item
  {
     
      public string ItemName { get; set; }

      public int Price { get; set; }
      public int SellPrice; 

      public string Description { get; set; }

      public Item(string itemName, int price)
      {
          this.ItemName = itemName;
          this.Price = price;
          SellPrice = (int)((double)Price * 0.5);  // halv pris 
      }

  }
}
