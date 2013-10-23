using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class Stat: System.Object
    {
        string Name { get; set; }
        int Amount { get; set; }

        public Stat(string name, int amount)
        {
            Name = name;
            Amount = amount; 
        }

        public void ChangeAmount(int change)
        {
            Amount += change; 
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Stat i = obj as Stat;
            if ((System.Object)i == null)
                return false;

            return Name == i.Name; 
        }

        public override int GetHashCode()
        {
          return Name.GetHashCode(); 
        }
    }
}
