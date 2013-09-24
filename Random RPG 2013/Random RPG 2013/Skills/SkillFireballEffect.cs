//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Random_RPG_2013
//{
//  class SkillFireballEffect : SkillDamage//Temp name
//  {
//    //Reduce/inrease hp ie. doing damage or healing.
//    //Reduce/increase damage ie. reducing/increasing the amount of damage a character does.
//    public enum EnumBuffType { Hp, Dmg }

//    //Applies buff/debuff to self.
//    //Applies buff/debuff to target.
//    public enum EnumTarget { Self, Target }

//    EnumBuffType BuffType { get; set; }
//    EnumTarget Target { get; set; }

//    int Effect { get; set; }
//    int Duration { get; set; }

//    public SkillFireballEffect(string name, string description, int minDamage, int maxDamage, int effect, int duration, EnumTarget target, EnumBuffType buffType)
//      : base(name, description, minDamage, maxDamage)
//    {
//      Effect = effect;
//      Duration = duration;
//      Target = target;
//      BuffType = buffType;
//    }

//    public static void DoDamageWithEffect(Character source, Character target, int skillIndex)
//    {
//      int damage = Utility.GenerateRandomNumber(source.CharacterListOfSkills[skillIndex].MinDamage, source.CharacterListOfSkills[skillIndex].MaxDamage);
//      int buffDamage = 0;
//      int totalDamage = 0;

//      if (target.CharacterListOfBuffs.Count() > 0)
//      {
//        foreach (Buff b in target.CharacterListOfBuffs)
//          if (b.BuffType == EnumBuffType.Hp)
//            buffDamage += b.Effect;

//        totalDamage = damage + buffDamage;

//        target.Health = totalDamage < target.Health ? target.Health = target.Health - totalDamage : 0;
//      }
//      else
//        target.Health = damage < target.Health ? target.Health = target.Health - damage : 0;

//      PositiveBuff positiveBuff;
//      NegativeBuff negativeBuff;

//      if (((SkillFireballEffect)source.CharacterListOfSkills[skillIndex]).Target == EnumTarget.Self)
//      {
//        positiveBuff =
//          new PositiveBuff(source.CharacterListOfSkills[skillIndex].Name + " " + "Buff", "",
//            ((SkillFireballEffect)source.CharacterListOfSkills[skillIndex]).Effect, ((SkillFireballEffect)source.CharacterListOfSkills[skillIndex]).Duration,
//            ((SkillFireballEffect)source.CharacterListOfSkills[skillIndex]).BuffType);

//        if (source.CharacterListOfBuffs.Count() > 0)
//          for (int i = 0; i < source.CharacterListOfBuffs.Count(); i++)
//          {
//            if (source.CharacterListOfBuffs[i].Name == positiveBuff.Name)
//              source.CharacterListOfBuffs[i].Duration = positiveBuff.Duration;
//            else
//              source.CharacterListOfBuffs.Add(positiveBuff);
//          }
//        else
//          source.CharacterListOfBuffs.Add(positiveBuff);
//      }
//    }
//  }
//}
