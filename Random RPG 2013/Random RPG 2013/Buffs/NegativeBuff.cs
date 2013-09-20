using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class NegativeBuff : Buff
  {
    public NegativeBuff(string name, string description, int effect, int duration, SkillFireballEffect.EnumBuffType buffType)
      : base(name, description, effect, duration, buffType) { }
  }
}
