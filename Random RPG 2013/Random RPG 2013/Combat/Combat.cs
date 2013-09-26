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

    public Combat() { }

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

    public void DamagePhase(Character source, Character target, int skillIndex)
    {
      if (source.CharacterListOfBuffs.Count() > 1 || target.CharacterListOfBuffs.Count() > 1)
        HandleBuffs(source, target, skillIndex);

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
      
    }

    private void HandleBuffs(Character source, Character target, int skillIndex)
    {
      string statusEffect = "";

      for (int i = 0; i < source.CharacterListOfBuffs.Count(); i++)
      {
        List<Buff> b = source.CharacterListOfBuffs;

        if (source.CharacterListOfBuffs[i] is PositiveBuff)
        {
          if (b[i].TargetOfBuff == Buff.EnumTargetOfBuff.Source)
          {
            if (b[i].TypeOfBuff == Buff.EnumTypeOfBuff.Hp)
            {
              source.Health += ((PositiveBuff)b[i]).Effect;
            }
          }
        }
        else if (source.CharacterListOfBuffs[i] is NegativeBuff)
        {
          if (b[i].TargetOfBuff == Buff.EnumTargetOfBuff.Source)
          {
            if (b[i].TypeOfBuff == Buff.EnumTypeOfBuff.Hp)
            {
              source.Health -= ((NegativeBuff)b[i]).Effect;
            }
          }
        }
        else
        {
          if (b[i].TargetOfBuff == Buff.EnumTargetOfBuff.Source)
          {
            if (b[i].TypeOfBuff == Buff.EnumTypeOfBuff.Status)
            {
              statusEffect = FindStatusEffect(source);

              if (statusEffect == "stun")
              {
                //Do nothing
              }
              else if (statusEffect == "slow")
              {
                //Do something
              }
              else
              {
                //Do something
              }
            }
          }
        }
      }
    }

    private string FindStatusEffect(Character character)
    {
      string statusEffect = "";

      foreach (Buff b in character.CharacterListOfBuffs)
      {
        if (b is StatusEffect)
        {
          if (((StatusEffect)b).Status == StatusEffect.EnumStatus.Stun)
            statusEffect = "stun";
          else if (((StatusEffect)b).Status == StatusEffect.EnumStatus.Slow)
            statusEffect = "slow";
          else
            statusEffect = "confuse";
        }
      }
      return statusEffect;
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
