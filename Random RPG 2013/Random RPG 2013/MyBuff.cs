using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    class MyBuff
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public virtual void effect(Character target){} 
    }

    class DOT : MyBuff
    {
        int Damage { get; set; }

        public DOT(int damage)
        {
            this.Damage = damage; 
        }

        public override void effect(Character target)
        {
            target.Health =- Damage; 
        }
    }
}
