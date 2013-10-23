using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class SkillDamage : Skill
  {
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    public override void effect(Character target)
    {
        target.Health -= MaxDamage; 
    }

    public SkillDamage(string name, string description, int minDamage, int maxDamage)
      : base(name, description)
    {
      Name = name;
      MinDamage = minDamage;
      MaxDamage = maxDamage;
    }
  }
}
