using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class PositiveBuff : Buff
  {
    public PositiveBuff(string name, string description, int effect, EnumBuffType buffType)
      : base(name, description, effect, buffType) { }
  }
}
