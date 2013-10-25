using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  abstract class Character
  {
    public List<Skill> CharacterListOfSkills = new List<Skill>();
    public List<MyBuff> CharacterListOfBuffs = new List<MyBuff>();

    Inventory inventory;

      

    public bool IsStunned = false;
    
    public List<Stat> Statlist = new List<Stat>()
    {
       new Stat(100, StatType.Health), 
       new Stat(28, StatType.Attack)
    }; 
    public string Name { get; set; }
    public int Health { get; set; }

    public void EditStat(StatType statType, int amount)
    {
        foreach (Stat s in Statlist)
        {
            if (s.Kind == statType)
                s.Amount += amount;  
        }
    }

    public int  GetAttack()
    {
        int k = 0 ;
        foreach (Stat s in Statlist)
        {
            if (s.Kind == StatType.Attack)
               k  = s.Amount; 

        }
        
        return k; 
    }

    public Character(string name, int health, int damage)
    {
      Name = name;
      Health = health;
      
    }
  }
}
