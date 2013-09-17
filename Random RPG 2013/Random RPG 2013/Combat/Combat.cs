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
      while (Hero.Health > 0 && Creature.Health > 0)
      {
        Console.WriteLine("Choose action:");

        for (int i = 0; i < Hero.CharacterListOfSkills.Count(); i++)
          Console.WriteLine("{0}. {1}", i + 1, Hero.CharacterListOfSkills[i].Name);

        string _userInput = Console.ReadLine();
        int userInput;
        int.TryParse(_userInput, out userInput);

        switch (userInput)
        {
          case 1:
            DamagePhase(Hero, Creature, userInput);
            break;
          case 2:
            //Incomplete.
            DamagePhase(Hero, Creature, userInput);
            break;
          case 3:
            DamagePhase(Hero, Creature, userInput);
            break;
          case 4:
            DamagePhase(Hero, Creature, userInput);
            break;
          case 5:
            DamagePhase(Hero, Creature, userInput);
            break;
        }

        DamagePhase(Creature, Hero, 1);
      }
      return Hero;
    }

    private void DamagePhase(Character source, Character target, int skillIndex)
    {
      //Health of target cant be reduced below zero.
      if (source.CharacterListOfSkills[skillIndex - 1] is Skill)
        target.Health = source.CharacterListOfSkills[skillIndex - 1].Damage < target.Health ? target.Health = target.Health - source.CharacterListOfSkills[skillIndex - 1].Damage : 0;

      Console.WriteLine("{0} did {1} damage to {2}. {3} has {4} health left.", source.Name, source.CharacterListOfSkills[skillIndex - 1].Damage, target.Name, target.Name, target.Health);
    }

  }
}
