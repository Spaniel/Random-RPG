using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class SkillDamageWithBuff : SkillDamage
  {
    Buff Buff { get; set; }

    double Percentage { get; set; }

    public SkillDamageWithBuff(string name, string description, int min, int max, Buff buff)
      : base(name, description, min, max)
    {
      Buff = buff;
    }

    public static void DoDamageWithEffect(Character source, Character target, int skillIndex)
    {
      if (source.CharacterListOfBuffs.Count() > 1 || target.CharacterListOfBuffs.Count() > 1)
        Buff.HandleBuffs(source, target, skillIndex);
    }
  }
}
