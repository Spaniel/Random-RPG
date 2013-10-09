using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class SkillWithBuff : Skill 
    {
        public MyBuff SkillBuff { get; set; }

        public SkillWithBuff(string name, string des, MyBuff buff) :
            base(name, des)
        {
            SkillBuff = buff; 
        }
        
    }
}
