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
    public int Damage { get; set; }

    public Skill(string name, int damage)
    {
      Name = name;
      Damage = damage;
    }
  }
}
