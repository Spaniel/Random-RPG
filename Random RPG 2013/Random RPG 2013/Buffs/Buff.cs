using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  abstract class Buff
  {
    public SkillFireballEffect.EnumBuffType BuffType { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Effect { get; set; }
    public int Duration { get; set; }

    public Buff(string name, string description, int effect, int duration, SkillFireballEffect.EnumBuffType buffType)
    {
      Name = name;
      Description = description;
      Effect = effect;
      Duration = duration;

      BuffType = buffType;
    }
  }
}
