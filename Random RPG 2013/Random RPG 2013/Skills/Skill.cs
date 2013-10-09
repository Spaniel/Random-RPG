using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Skill
  {
    public string Name { get; set; }
    public string Description { get; set; }
    //public int Cost { get; set; }
    public bool Selfcast = false; 
    public bool HasBuff; 

    public virtual void effect(Character target) { }

    public Skill(string name, string description)
    {
      Name = name;
      Description = description;
      //Cost = cost;
    }
  }
}
