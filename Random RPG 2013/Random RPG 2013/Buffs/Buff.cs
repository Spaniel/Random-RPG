using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Buff
  {
    //Reduce/inrease hp ie. doing damage or healing.
    //Reduce/increase damage ie. reducing/increasing the amount of damage a character does.
    public enum EnumBuffType { Hp, Dmg }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Effect { get; set; }

    public EnumBuffType BuffType { get; set; }

    public Buff(string name, string description, int effect, EnumBuffType buffType)
    {
      Name = name;
      Description = description;
      Effect = effect;
      BuffType = buffType;
    }
  }
}
