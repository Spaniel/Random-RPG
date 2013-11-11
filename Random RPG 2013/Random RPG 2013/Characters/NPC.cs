using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class NPC
  {
      public string Name { get; set; }
      List<string> Messages { get; set; }

      public NPC(string name)
      {
          this.Name = name; 
      }

  }

  class Merchant : NPC
  {
      int Money { get; set; }
      List<Item> item { get; set; }

      public Merchant(string name)
          : base(name) { }
      
      
      

  }
}
