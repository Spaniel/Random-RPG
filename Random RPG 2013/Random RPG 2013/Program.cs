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
      Skill attack = new Skill("Attack", 5);
      Skill awesomeBlow = new Skill("Awesome Blow", 10);
      P.AddSkillToCharacter(spanieL, attack);
      P.AddSkillToCharacter(spanieL, awesomeBlow);

      //Skills for Rat
      Skill BasicAttack = new Skill("Basic Attack", 3);
      Skill SuperStrike = new Skill("Super Strike", 5);
      P.AddSkillToCharacter(Rat, BasicAttack);
      P.AddSkillToCharacter(Rat, SuperStrike);

      //Creates a combat with the hero and a creature. Limited to only two characters per fight atm.
      Combat combat1 = new Combat(spanieL, Rat);
      combat1.CombatStart();

      Console.ReadLine();
    }

    private void AddSkillToCharacter(Character character, Skill skill)
    {
      character.CharacterListOfSkills.Add(skill);
    }
  }
}
