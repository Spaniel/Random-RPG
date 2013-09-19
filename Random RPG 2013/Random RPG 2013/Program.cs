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
      Program P = new Program();

      Hero spanieL = new Hero("spanieL", 100, 6);
      Creature Rat = new Creature("Rat", 50, 3);

      //Skills for spanieL
      SkillDamage attack = new SkillDamage("Attack", "", 1, 5);
      SkillDamage awesomeBlow = new SkillDamage("Awesome Blow", "", 2, 10);
      P.AddSkillToCharacter(spanieL, attack);
      P.AddSkillToCharacter(spanieL, awesomeBlow);

      //Skills for Rat
      SkillDamage BasicAttack = new SkillDamage("Basic Attack", "", 1, 3);
      SkillDamage SuperStrike = new SkillDamage("Super Strike", "", 2, 5);
      P.AddSkillToCharacter(Rat, BasicAttack);
      P.AddSkillToCharacter(Rat, SuperStrike);

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
