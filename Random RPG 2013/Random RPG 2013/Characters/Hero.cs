﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Hero : Character
  {
    public List<Skill> HeroListSkills = new List<Skill>();



    public Hero(string name, int heroHealth, int heroDamage)
      : base(name, heroHealth, heroDamage) {}
  }
}
