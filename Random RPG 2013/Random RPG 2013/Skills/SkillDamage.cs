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

    public SkillDamage(string name, string description, int minDamage, int maxDamage)
      : base(name, description)
    {
      Name = name;
      MinDamage = minDamage;
      MaxDamage = maxDamage;
    }

    public static void DoDamageSkill(Character source, Character target, int skillIndex)
    {
      int damage = Utility.GenerateRandomNumber(source.CharacterListOfSkills[skillIndex].MinDamage, 
        source.CharacterListOfSkills[skillIndex].MaxDamage);

      target.Health = damage < target.Health ? target.Health = target.Health - damage : 0;

      Utility.CombatLog(source.Name, damage, target.Name, target.Health);
    }
  }
}
