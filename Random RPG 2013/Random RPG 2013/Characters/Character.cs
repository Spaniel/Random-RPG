using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  abstract class Character
  {
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; } //Probably temp value

    public Character(string name, int health, int damage)
    {
      Name = name;
      Health = health;
      Damage = damage;
    }
  }
}
