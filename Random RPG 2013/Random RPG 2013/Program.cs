using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Program
  {
      static void Main(string[] args)
      {

          /// Sets op the awsome box's for the console window
          //Interface.ConsoleSettings(60, 30);

          Program P = new Program();

          Hero spanieL = new Hero("spanieL", 100, 6, 5, 5, 5, 5);
          Creature Rat = new Creature("Rat", 50, 10);




          Statbuff Burn = new Statbuff("BURN", 3, -5, StatType.Health); // hvis det er DOT er det minus den skade der skal gøres
          SimpleSkill Burner = new SimpleSkill("Burner", "burns the enemy", false, Burn);
          Statbuff Heals = new Statbuff("healing", 3, 5, StatType.Health);
          AdvancedSkill BurnAndHeals = new AdvancedSkill("BurnAndHeals", "burns the enemy but heals you!!!", new Dictionary<IEffect, TargetOfEffect>() { {Burn, TargetOfEffect.Enemy }, {Heals, TargetOfEffect.Self}});
          SimpleSkill BasicAttak = new SimpleSkill("Basic Attack", "just a simple attack", false, new Offense(StatType.Health, 10));
          AdvancedSkill  HitMeHitYOU = new AdvancedSkill("DUMBATTACK", "pretty dumb", new Dictionary<IEffect,TargetOfEffect>() {{new Offense(StatType.Health, 70),TargetOfEffect.Self}, {new Offense(StatType.Health, 1),TargetOfEffect.Enemy}}); 
          spanieL.CharacterListOfSkills.Add(Burner);
          spanieL.CharacterListOfSkills.Add(BasicAttak);
          spanieL.CharacterListOfSkills.Add(BurnAndHeals);
          spanieL.CharacterListOfSkills.Add(HitMeHitYOU); 
          

          /*
        #region haX'd
        /// Hardcodet atm, shouldn't be, also need to specify hero and creature through classes and not string if possible
        Interface.HealthBarController("Hero", spanieL.Health, spanieL.Health);
        Interface.HealthBarController("Creature", Rat.Health, Rat.Health);
        #endregion
          */

          //Skills for spanieL

          //NegativeBuff burn = new NegativeBuff("Burn", 3, 5);
          //SkillWithBuff burnattack = new SkillWithBuff("Burner", "hot", burn); 
          //SkillDamageWithBuff Fireball = new SkillDamageWithBuff("Fireball", "Mediocre hit and applies a damage over time effect", 1, 4, new NegativeBuff("Burn", "Damage over time", 3, 5, Buff.EnumTargetOfBuff.Target, Buff.EnumTypeOfBuff.Hp));

          //spanieL.CharacterListOfSkills.Add(burnattack); 

          // P.AddSkillToCharacter(spanieL, Fireball);

          //Skills for Rat


          //Used this to test wether or not the DecayBuffs method worked - it did.
          // PositiveBuff HoT = new PositiveBuff("Renew", "Heal over time", 5, 3, Buff.EnumTargetOfBuff.Source, Buff.EnumTypeOfBuff.Hp);
          //spanieL.CharacterListOfBuffs.Add(HoT);

          //Creates a combat with the hero and a creature. Limited to only two characters per fight atm.

          Combat combat1 = new Combat(spanieL, Rat);
          combat1.CombatStart();

          Console.ReadLine();


      } 
  }
}
