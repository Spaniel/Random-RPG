using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Buff
  {
    public enum EnumTargetOfBuff { Source, Target }
    public enum EnumTypeOfBuff { Damage, Hp, Status }
    //public SkillFireballEffect.EnumBuffType BuffType { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public EnumTargetOfBuff TargetOfBuff { get; set; }
    public EnumTypeOfBuff TypeOfBuff { get; set; }

    public Buff(string name, string description, int duration, EnumTargetOfBuff targetOfBuff, EnumTypeOfBuff typeOfBuff)
    {
      Name = name;
      Description = description;
      Duration = duration;
      TargetOfBuff = targetOfBuff;
      TypeOfBuff = typeOfBuff;
    }
  }
}
