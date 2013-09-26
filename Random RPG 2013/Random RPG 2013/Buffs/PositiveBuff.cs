﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class PositiveBuff : Buff
  {
    public int Effect { get; set; }

    public PositiveBuff(string name, string description, int effect, int duration, Buff.EnumTargetOfBuff targetOfBuff, Buff.EnumTypeOfBuff typeOfBuff)
      : base(name, description, duration, targetOfBuff, typeOfBuff) 
    {
      Effect = effect;
    }
  }
}
