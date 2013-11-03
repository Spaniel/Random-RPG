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
      while (Hero.GetStat(StatType.Health) > 0 && Creature.GetStat(StatType.Health) > 0)
      {
        CombatPhase(turnCounter);
        turnCounter++;
      }
      return Hero;
    }

    private void CombatPhase(int turn)
    {
		//Navigation.Navigator();
        
		/// I have removed the "switch (userInput)" and instead using the metode "(Skills)" from Navigation
		//int userInput = Utility.ValidateUserInput(Hero.CharacterListOfSkills.Count()); 

       // DMGPhase(Hero, Creature, 0);
        BuffHandler(); 
        Console.WriteLine(Creature.GetStat(StatType.Health));
        Console.ReadLine(); 
    }

    #region Mads

    private void BuffHandler()
    {
        EffectAndDuration(Hero);
        EffectAndDuration(Creature); 
    }

    private void EffectAndDuration(Character target)
    {       
        for (int i = 0; i < target.CharacterListOfBuffs.Count; i++)
        {
            target.CharacterListOfBuffs[i].effect(ref target);
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
            spell.effect(source, enemy);
            source.CharacterListOfBuffs.Add(spell.SkillBuff); 
        }
        else
        {
            spell.effect(enemy,source);
            enemy.CharacterListOfBuffs.Add(spell.SkillBuff); 
        }
    }

    private void Spellwithoutbuff(Skill spell, Character source, Character enemy)
    {
        if (spell.Selfcast)
            spell.effect(source, enemy);
        else
            spell.effect(enemy, source); 
    }

    public void DMGPhase(Character source, Character target, int skillIndex)
    {
      if (source.IsStunned)
        Utility.DoNothing(); 

        if (source.CharacterListOfBuffs.Count() > 0 || target.CharacterListOfBuffs.Count() > 0)
            BuffHandler();
       
        Spellcast(source.CharacterListOfSkills[skillIndex], source,target); 
      
    }
    #endregion
       
  }
}
