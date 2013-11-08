using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    public enum TargetOfEffect { Self, Enemy }

    class AdvancedSkill : Skill
    {
        Dictionary<IEffect, TargetOfEffect> EffectsOfSkill;

        public override void DoEffect(Character enemy, Character caster)
        {
            foreach (KeyValuePair<IEffect, TargetOfEffect> k in EffectsOfSkill)
                if (k.Key is MyBuff)
                {
                    MyBuff s = (MyBuff)k.Key;
                    if (k.Value == TargetOfEffect.Enemy)
                        enemy.CharacterListOfBuffs.Add(s);
                    else
                        caster.CharacterListOfBuffs.Add(s);
                }
                else if (k.Key is Offense)
                {
                    Offense b = (Offense)k.Key;
                    if (k.Value == TargetOfEffect.Self)
                        b.effect(caster, caster);
                    else
                        b.effect(enemy, caster);
                }
                else
                    k.Key.effect(caster); 
        }

        public AdvancedSkill(string name, string des, Dictionary<IEffect, TargetOfEffect> effects)
            : base(name, des)
        {
            EffectsOfSkill = effects;
        }

        public override bool CheckSkill()
        {
            int i = 0;
            foreach (KeyValuePair<IEffect, TargetOfEffect> k in EffectsOfSkill)
            {
                if (!(k.Key is MyBuff))
                    i++;
            }

            if (i == 0)
                return false;
            else
                return true; 

        }

    }
}
