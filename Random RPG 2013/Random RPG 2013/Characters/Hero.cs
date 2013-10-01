using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Hero : Character
  {
    public List<Item> HeroListEquippedItems = new List<Item>();
    public List<Item> HeroListInventoryItems = new List<Item>();

    public Dictionary<string, int> HeroDictionaryStats = new Dictionary<string, int>();

    public Hero(string name, int heroHealth, int heroDamage, int strength, int dexterity, int intelligence, int vitality)
      : base(name, heroHealth, heroDamage) 
    {
      InitializeStats(strength, dexterity, intelligence, vitality);
    }

    private void InitializeStats(int strength, int dexterity, int intelligence, int vitality)
    {
      HeroDictionaryStats.Add("Strength", strength);
      HeroDictionaryStats.Add("Dexterity", dexterity);
      HeroDictionaryStats.Add("Intelligence", intelligence);
      HeroDictionaryStats.Add("Vitality", vitality);
    }
  }
}
