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
      #region haX'd
      Console.SetCursorPosition(Console.WindowWidth - 30, Console.WindowHeight - 10);
      #endregion haX'd

      Console.WriteLine("Choose action:");

      for (int i = 0; i < Hero.CharacterListOfSkills.Count(); i++)
      {
        #region haX'd
        Console.SetCursorPosition(Console.WindowWidth - 30, Console.WindowHeight - (9 - i));
        #endregion haX'd
        Console.WriteLine("{0}. {1}", i + 1, Hero.CharacterListOfSkills[i].Name);
      }

      #region haX'd
      //// Center the cursor
      Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2 - 1);
      Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
      Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 1);
      #endregion

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

      EndTurn();
    }

    private void DamagePhase(Character source, Character target, int skillIndex)
    {
      if (source.CharacterListOfSkills[skillIndex] is SkillDamage)
        SkillDamage.DoDamageSkill(source, target, skillIndex);
    }

    //Decrements or removes buffs from characters based on duration.
    private void DecayBuffs()
    {
      foreach (Buff b in Hero.CharacterListOfBuffs)
        if (b.Duration > 1)
          b.Duration--;
        else
          Hero.CharacterListOfBuffs.Remove(b);

      foreach (Buff b in Creature.CharacterListOfBuffs)
        if (b.Duration > 1)
          b.Duration--;
        else
          Creature.CharacterListOfBuffs.Remove(b);
    }

    private void EndTurn()
    {
      if (Hero.CharacterListOfBuffs.Count() > 0 || Hero.CharacterListOfBuffs.Count() > 0)
        DecayBuffs();

      //Count turns up
    }
  }
}
