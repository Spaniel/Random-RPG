﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013.Skills
{
  class StatusEffectSkill : Skill
  {
    Buff Buff { get; set; }

    public StatusEffectSkill(string name, string description, Buff buff)
      : base(name, description)
    {
      Buff = buff;
    }
  }
}
