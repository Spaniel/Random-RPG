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
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. " + Hero.HeroListSkills[0].Name);

        string _userInput = Console.ReadLine();
        int userInput;
        int.TryParse(_userInput, out userInput);


        switch (userInput)
        {
          case 1:
            DamagePhase(Hero, Creature);
            break;
          case 2:
            //Incomplete.
            DamagePhase(Hero, Creature);
            break;
        }

        DamagePhase(Creature, Hero);
      }
      return Hero;
    }

    private void DamagePhase(Character source, Character target)
    {
      //Health of target cant be reduced below zero.
      target.Health = source.Damage < target.Health ? target.Health = target.Health - source.Damage : 0;

      Console.WriteLine("Health of {0}: {1}\n{2} Damage: {3}", target.Name, target.Health, source.Name, source.Damage);
    }

  }
}
