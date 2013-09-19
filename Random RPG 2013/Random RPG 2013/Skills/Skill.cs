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

    public static void DoDamage(Character source, Character target, int skillIndex)
    {
      int damage = Utility.GenerateRandomNumber(1, source.CharacterListOfSkills[skillIndex].Damage);

      target.Health = damage < target.Health ? target.Health = target.Health - damage : 0;

      Utility.CombatLog(source.Name, damage, target.Name, target.Health);
    }
  }
}
