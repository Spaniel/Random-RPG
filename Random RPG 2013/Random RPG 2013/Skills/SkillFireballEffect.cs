using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class SkillFireballEffect //Temp name
  {
    string Name { get; set; }
    int MinDamage { get; set; }
    int MaxDamage { get; set; }

    public SkillFireballEffect(string name, int minDamage, int maxDamage)
    {
      Name = name;
      MinDamage = minDamage;
      MaxDamage = maxDamage;
    }
  }
}
