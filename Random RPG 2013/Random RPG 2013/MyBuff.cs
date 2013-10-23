using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    abstract class MyBuff
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

    class Statbuff : MyBuff
    {
       internal int Statbuffer { get; set; }
       internal Stat Statter; 

        public Statbuff(string name, int dur, int statbuffer, Stat statter)
            : base(name, dur)
        {
            Statbuffer = statbuffer;
            Statter = statter; 
        }
    }

    class NegativeBuff : Statbuff
    {
        public NegativeBuff(string name, int dur, int damage, int statbuffer, Stat statter) :
            base(name, dur, statbuffer,statter) { }
      
        public override void effect(Character target)
        {
            foreach (Stat s in target.Statlist)
                if (s == Statter)
                    s.ChangeAmount(-Statbuffer); 
        }
    }

    class PositiveBuff : Statbuff
    {
        public PositiveBuff(string name, int dur, int heal, int statbuffer, Stat statter)
            : base(name, dur, statbuffer,statter) { }
      
      public override void effect(Character target)
      {
          foreach (Stat s in target.Statlist)
              if (s == Statter)
                  s.ChangeAmount(Statbuffer); 
      }
    }
    /*
    class StatusEffectBuff : MyBuff
    {
        public override void effect(Character target)
        {
            target.IsStunned = true; 
        }
    }
     * */

}
