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
      int turnCounter = 1;

      //Keeps combat going while both hero and creature is above 0 health.
      while (Hero.Health > 0 && Creature.Health > 0)
      {
        CombatPhase(turnCounter);
        turnCounter++;
      }
      return Hero;
    }

    private void CombatPhase(int turn)
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
        DoDamageSkill(source, target, skillIndex);
    }

    private void DoDamageSkill(Character source, Character target, int skillIndex)
    {
      int damage = Utility.GenerateRandomNumber(source.CharacterListOfSkills[skillIndex].MinDamage,
        source.CharacterListOfSkills[skillIndex].MaxDamage);

      target.Health = damage < target.Health ? target.Health = target.Health - damage : 0;

      Utility.CombatLog(source.Name, damage, target.Name, target.Health);
    }

    private void DoDamageWithEffect(Character source, Character target)
    {
      if (source.CharacterListOfBuffs.Count() > 1 || target.CharacterListOfBuffs.Count() > 1)
        HandleBuffs(source, target);
    }

    private void HandleBuffs(Character source, Character target)
    {
      foreach (Buff b in source.CharacterListOfBuffs)
      {
        if (b.TargetOfBuff == Buff.EnumTargetOfBuff.Self)
        {
          if (b.TypeOfBuff == Buff.EnumTypeOfBuff.Hp)
            source.Health += b.Effect;
        }
      }

      foreach (Buff b in target.CharacterListOfBuffs)
      {

      }
    }

    //Decrements or removes buffs from characters based on duration.
    public void DecayBuffs()
    {
      for (int i = Hero.CharacterListOfBuffs.Count() - 1; i >= 0; i--)
        if (Hero.CharacterListOfBuffs[i].Duration > 1)
          Hero.CharacterListOfBuffs[i].Duration--;
        else
          Hero.CharacterListOfBuffs.Remove(Hero.CharacterListOfBuffs[i]);

      for (int i = Creature.CharacterListOfBuffs.Count() - 1; i >= 0; i--)
        if (Creature.CharacterListOfBuffs[i].Duration > 1)
          Creature.CharacterListOfBuffs[i].Duration--;
        else
          Creature.CharacterListOfBuffs.Remove(Creature.CharacterListOfBuffs[i]);
    }

    private void EndTurn()
    {
      if (Hero.CharacterListOfBuffs.Count() > 0 || Hero.CharacterListOfBuffs.Count() > 0)
        DecayBuffs();
    }
  }
}
