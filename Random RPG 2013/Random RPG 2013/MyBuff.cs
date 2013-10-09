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
        private int _startDuration; 
        private int CurrentDuration { get; set; }

        public int duration()
        {

            return CurrentDuration--; 
        }

        public void ResestDuration()
        {
            CurrentDuration = _startDuration;
        }

        public virtual void effect(Character target){}

        public MyBuff(string name, int dur)
        {
            Name = name;
            _startDuration = dur;
            CurrentDuration = dur; 
            
        }
    }

    class DOT : MyBuff
    {
        public int Damage { get; set; }

        public DOT(string name, int dur, int damage):
            base(name,dur)
        {
            this.Damage = damage; 
        }

        public override void effect(Character target)
        {
            target.Health = target.Health- Damage; 
        }
    }
/*
    class Healing : MyBuff
    {
        int Heal { get; set; }

        public Healing(int heal)
        {
            this.Heal = heal; 
        }

        public override void effect(Character target)
        {
            target.Health =- Heal; 
        }
    }

    class StatusEffectBuff : MyBuff
    {
        public override void effect(Character target)
        {
            target.IsStunned = true; 
        }
    }
 * */
}
