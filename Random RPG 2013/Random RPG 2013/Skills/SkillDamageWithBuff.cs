using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013.Skills
{
    class SkillDamageWithBuff : SkillDamage
    {
        Buff Buff { get; set; }

        double Percentage { get; set; }

        public SkillDamageWithBuff(string des, string name,int min,int max,Buff buff)
            :base(des,name, min, max)
        {
            this.Buff = buff; 
        }
    }
}
