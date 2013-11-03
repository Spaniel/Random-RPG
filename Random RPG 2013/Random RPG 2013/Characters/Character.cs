using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace Random_RPG_2013
{
    public enum StatType { Health, Attack, Dex }; 
  abstract class Character
  {
    public List<Skill> CharacterListOfSkills = new List<Skill>();
    public List<MyBuff> CharacterListOfBuffs = new List<MyBuff>();

    Inventory inventory;
    public bool IsStunned = false;
    public string Name { get; set; }
    public int Health { get; set; }

    private Dictionary<StatType, int> Stats = new Dictionary<StatType, int>
        {
            {StatType.Health, 100 }, 
            {StatType.Attack,28}
        };

    #region StatManipulation
    public void EditStat(StatType stat, int amount)
    {
        List<KeyValuePair<StatType, int>> list = new List<KeyValuePair<StatType, int>>(Stats);

        foreach (KeyValuePair<StatType, int> kvp in list)
        {
            if (stat == kvp.Key)
                Stats[kvp.Key] += amount; 
        }        
    }

    public int  GetStat(StatType stat)
    {
        int k = 0; 
        List<KeyValuePair<StatType, int>> list = new List<KeyValuePair<StatType, int>>(Stats);

        foreach (KeyValuePair<StatType, int> kvp in list)
        {
            if (stat == kvp.Key)
                k = kvp.Value; 
        }
        return k;       
    }
    #endregion
    public Character(string name, int health, int damage)
    {
      Name = name;
      Health = health;
      
    }
  }
}
