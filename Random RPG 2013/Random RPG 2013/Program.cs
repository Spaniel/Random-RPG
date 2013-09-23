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
        
      #region haX'd
      /// Sets op the awsome box's for the console window
      Interface.ConsoleSettings();
      #endregion

      Program P = new Program();

      Hero spanieL = new Hero("spanieL", 100, 6);
      Creature Rat = new Creature("Rat", 50, 10);

      #region haX'd
      /// Hardcodet atm, shouldn't be, also need to specify hero and creature through classes and not string if possible
      Health.HealthBarController("Hero", spanieL.Health, spanieL.Health);
      Health.HealthBarController("Creature", Rat.Health, Rat.Health);
      #endregion

      //Skills for spanieL
      SkillDamage attack = new SkillDamage("Attack", "", 1, 5);
      SkillDamage awesomeBlow = new SkillDamage("Awesome Blow", "", 2, 10);
      SkillDamageWithBuff Fireball = new SkillDamageWithBuff("Fireball", "Mediocre hit and applies a damage over time effect", 1, 3, new NegativeBuff("Burn", "Damage over time", 3, 5, SkillFireballEffect.EnumBuffType.Hp));
      P.AddSkillToCharacter(spanieL, attack);
      P.AddSkillToCharacter(spanieL, awesomeBlow);
      P.AddSkillToCharacter(spanieL, Fireball);

      //Skills for Rat
      SkillDamage BasicAttack = new SkillDamage("Basic Attack", "", 1, 2);
      SkillDamage SuperStrike = new SkillDamage("Super Strike", "", 2, 5);
      P.AddSkillToCharacter(Rat, BasicAttack);
      P.AddSkillToCharacter(Rat, SuperStrike);

      //Used this to test wether or not the DecayBuffs method worked - it did.
      PositiveBuff HoT = new PositiveBuff("Renew", "Heal over time", 5, 3, SkillFireballEffect.EnumBuffType.Hp);
      spanieL.CharacterListOfBuffs.Add(HoT);
      
      //Creates a combat with the hero and a creature. Limited to only two characters per fight atm.
      Combat combat1 = new Combat(spanieL, Rat);
      combat1.CombatStart();

      Console.ReadLine();
    }

    private void AddSkillToCharacter(Character character, SkillDamage skill)
    {
      character.CharacterListOfSkills.Add(skill);
    }
  }
}
