using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Creature : Character
  {
    public Creature(string name, int enemyHealth, int enemyDamage)
      : base(name, enemyHealth, enemyDamage) { }
  }
}
