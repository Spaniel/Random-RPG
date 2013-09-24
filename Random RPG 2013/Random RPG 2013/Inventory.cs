using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace Random_RPG_2013
{

    class Inventory  : IEnumerable<Item>
    {
        private List<Item> inventory = new List<Item>(); 

        public void Add(Item item)
        {
            if (inventory.Contains(item) && item is Consumable)
            {
                foreach (Item i in inventory)
                {
                    if (i.Equals(item))
                        i.NumberOfItems++;
                }
            }
            else 
                inventory.Add(item); 

        }

        public void Remove(Item item)
        {
            if (inventory.Contains(item))
            {
                foreach (Item i in inventory)
                {
                    if (i.Equals(item) && i.NumberOfItems > 1)
                        i.NumberOfItems--;
                    else
                        inventory.Remove(item);
                }
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            for (int i = 0; i < inventory.Count; i++)
                yield return inventory[i]; 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }


    }
}
