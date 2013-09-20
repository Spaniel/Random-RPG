using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  abstract class Character
  {
    public List<SkillDamage> CharacterListOfSkills = new List<SkillDamage>();
    public List<Buff> CharacterListOfBuffs = new List<Buff>();

    public string Name { get; set; }
    public int Health { get; set; }

    public Character(string name, int health, int damage)
    {
      Name = name;
      Health = health;
    }
  }
}
