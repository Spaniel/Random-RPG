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
    bool CHECKER = false; // SKAL KUN BRUGES TIL TEST AF SKILLS 

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
        if (!CHECKER)
        {
            DMGPhase(Hero, Creature, 3);
            CHECKER = false; 
        }
        BuffHandler(); 
        Console.WriteLine(Creature.GetStat(StatType.Health));
        Console.WriteLine(Hero.GetStat(StatType.Health)); 
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
        MyBuff b = null; 
        for (int i = 0; i < target.CharacterListOfBuffs.Count; i++)
        {
            b = target.CharacterListOfBuffs[i];
            b.effect(target);
            PrintBuffStuff(b, target); 

        }
    }

    public void SpellCast(Character caster, Character enemy, int skillindex)
    {
        int CasterHealthBefore = caster.GetStat(StatType.Health);
        int EnemyHealthBefore = enemy.GetStat(StatType.Health); 
       Skill s = caster.CharacterListOfSkills[skillindex]; 
       s.DoEffect(enemy,caster);

       if (s.CheckSkill())
       {
           printstuff(s, caster.GetStat(StatType.Health), CasterHealthBefore , caster.Name);
           printstuff(s, enemy.GetStat(StatType.Health), EnemyHealthBefore, enemy.Name); 
       }
             
    }

    public void DMGPhase(Character source, Character target, int skillIndex)
    {
      if (source.IsStunned)
        Utility.DoNothing(); 

        if (source.CharacterListOfBuffs.Count() > 0 || target.CharacterListOfBuffs.Count() > 0)
            BuffHandler();

        SpellCast(source, target, skillIndex); 
        
      
    }
    #endregion

      #region Printing stuff 
    private void printstuff(Skill skill, int current, int previous, string name)
    {
        if (current < previous)
        {
            int HealthLost = previous - current;
            Console.WriteLine(skill.Name + " did " + HealthLost + " damage to " + name);
            
        }
        else if(current > previous)
        {
            int HealthGained = current - previous; 
            Console.WriteLine(name + " gained " + HealthGained + " Health");
            
        }

    }

      private void PrintBuffStuff(MyBuff buff, Character BuffOwner)
      {
          Console.WriteLine(BuffOwner.Name + " is affected by " + buff.Name); 
      }
        
            
        

    }
      #endregion

  }


