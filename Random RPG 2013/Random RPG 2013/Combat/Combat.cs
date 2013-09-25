using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Combat
  {
    public static Hero Hero { get; set; }
    public static Creature Creature { get; set; }

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
		Navigation.Navigator();

		/// I have removed the "switch (userInput)" and instead using the metode "(Skills)" from Navigation
		//int userInput = Utility.ValidateUserInput(Hero.CharacterListOfSkills.Count()); 

		EndTurn();
    }

    public static void DamagePhase(Character source, Character target, int skillIndex)
    {
      if (source.CharacterListOfSkills[skillIndex] is SkillDamage)
        DoDamageSkill(source, target, skillIndex);
    }

    private static void DoDamageSkill(Character source, Character target, int skillIndex)
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
