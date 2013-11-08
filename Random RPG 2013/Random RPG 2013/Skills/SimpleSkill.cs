using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class SimpleSkill : Skill
    {
        bool selfcast { get; set; }
        IEffect SkillType { get; set; }

        public override void DoEffect(Character enemy, Character caster)
        {
            if (SkillType is MyBuff)
            {
                MyBuff k = (MyBuff)SkillType;
                if (selfcast)
                    caster.CharacterListOfBuffs.Add(k);
                else
                    enemy.CharacterListOfBuffs.Add(k);
            }
            else if (SkillType is Offense)
                SkillType.effect(enemy, caster);
            else
                SkillType.effect(caster);                   
         }

        public SimpleSkill(string name, string des, bool self, IEffect type)
            :base(name, des)
        {
            selfcast = self;
            SkillType = type; 
        }

        public override bool CheckSkill()
        {
            if (SkillType is MyBuff)
                return false;
            else
                return true; 
        }
    }
}
