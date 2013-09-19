using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Combat
  {
    public Hero Hero { get; set; }
    public Creature Creature { get; set; }

    public Combat(Hero hero, Creature creature)
    {
      Hero = hero;
      Creature = creature;
    }

    public Character CombatStart()
    {
      //Keeps combat going while both hero and creature is above 0 health.
      while (Hero.Health > 0 && Creature.Health > 0)
        CombatPhase();

      return Hero;
    }

    private void CombatPhase()
    {
      Console.WriteLine("Choose action:");

      for (int i = 0; i < Hero.CharacterListOfSkills.Count(); i++)
        Console.WriteLine("{0}. {1}", i + 1, Hero.CharacterListOfSkills[i].Name);

      int userInput = Utility.ValidateUserInput(Hero.CharacterListOfSkills.Count());

      //Would like to get rid of this switch, and do something smarter instead.
      switch (userInput)
      {
        case 1:
          DamagePhase(Hero, Creature, userInput - 1);
          break;
        case 2:
          DamagePhase(Hero, Creature, userInput - 1);
          break;
        case 3:
          DamagePhase(Hero, Creature, userInput - 1);
          break;
        case 4:
          DamagePhase(Hero, Creature, userInput - 1);
          break;
        case 5:
          DamagePhase(Hero, Creature, userInput - 1);
          break;
      }

      DamagePhase(Creature, Hero, 1);
    }

    private void DamagePhase(Character source, Character target, int skillIndex)
    {
      if (source.CharacterListOfSkills[skillIndex] is SkillDamage)
        SkillDamage.DoDamageSkill(source, target, skillIndex);
    }
  }
}
