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

    private List<MyBuff> HeroBuffs;
    private List<MyBuff> CreatureBuffs; 

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

        
	
    }
/*
    public void DamagePhase(Character source, Character target, int skillIndex)
    {
      if (source.CharacterListOfBuffs.Count() > 1 || target.CharacterListOfBuffs.Count() > 1)
        HandleBuffs(source, target, skillIndex);

      if (source.CharacterListOfSkills[skillIndex] is SkillDamage)
        DoDamageSkill(source, target, skillIndex);
    }
 * */

    private void DoDamageSkill(Character source, Character target, int skillIndex)
    {

        SkillDamage x = (SkillDamage)source.CharacterListOfSkills[skillIndex];

        int damage = Utility.GenerateRandomNumber(x.MinDamage, x.MaxDamage); 

        

      target.Health = damage < target.Health ? target.Health = target.Health - damage : 0;

      Utility.CombatLog(source.Name, damage, target.Name, target.Health);
    }

    private void DoDamageWithEffect(Character source, Character target)
    {
      
    }

      /*private void HandleBuffs(Character source, Character target, int skillIndex)
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
       * */
    #region Mads

    private void BuffHandler()
    {
        EffectAndDuration(Hero.CharacterListOfBuffs, Hero);
        EffectAndDuration(Creature.CharacterListOfBuffs, Creature); 
    }

    private void EffectAndDuration(List<MyBuff> BuffList, Character target)
    {
        int k = target.Health; 
        for (int i = 0; i < BuffList.Count; i++)
        {
            BuffList[i].effect(target);
            if (BuffList[i].duration() == 1)
                BuffList.Remove(BuffList[i]);
            
        }
        
    }

    private void Spellcast(Skill spell, Character source, Character enemy)
    {
        if (spell is SkillWithBuff)
            SpellEffectWithBuff((SkillWithBuff)spell, source, enemy);
        else
            Spellwithoutbuff(spell, source, enemy); 

    }

    private void SpellEffectWithBuff(SkillWithBuff spell, Character source, Character enemy)
    {
        if (spell.Selfcast)
        {
            spell.effect(source);
            source.CharacterListOfBuffs.Add(spell.SkillBuff); 
        }
        else
        {
            spell.effect(enemy);
            enemy.CharacterListOfBuffs.Add(spell.SkillBuff); 
        }
    }

    private void Spellwithoutbuff(Skill spell, Character source, Character enemy)
    {
        if (spell.Selfcast)
            spell.effect(source);
        else
            spell.effect(enemy); 
    }

    public void DMGPhase(Character source, Character target, int skillIndex)
    {
        if(source.IsStunned)
            //nothing 

        if (source.CharacterListOfBuffs.Count() > 0 || target.CharacterListOfBuffs.Count() > 0)
            BuffHandler();

        if (source.CharacterListOfSkills[skillIndex] is SkillDamage)
            DoDamageSkill(source, target, skillIndex);
        else 
            Spellcast(source.CharacterListOfSkills[skillIndex], source,target); 

        // der skal så være noget her med abillities 

    }
    #endregion
      /*
    private void EndTurn()
    {
      if (Hero.CharacterListOfBuffs.Count() > 0 || Hero.CharacterListOfBuffs.Count() > 0)
        DecayBuffs();
    }
       * */
  }
}
