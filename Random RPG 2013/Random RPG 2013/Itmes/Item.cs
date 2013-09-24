using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  abstract class Item : System.Object
  {
    public string ItemName { get; set; }

    public int Price { get; set; }
    public int SellPrice;

    public string Description { get; set; }

    public int NumberOfItems = 1;

    internal Dictionary<string, int> Properties; 
  

    public Item(string itemName, int price)
    {
      this.ItemName = itemName;
      this.Price = price;
      SellPrice = (int)((double)Price * 0.5);  //Half price.
         
    }



    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      

      Item i = obj as Item;
      if ((System.Object)i == null)
        return false;
      
      return ItemName == i.ItemName;
    }

    public override int GetHashCode()
    {
      return ItemName.GetHashCode();
    }
  }
}
