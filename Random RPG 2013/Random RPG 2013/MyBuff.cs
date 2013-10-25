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
        internal int CurrentDuration { get; set; }

        public virtual void duration(ref Character target)
        {
            CurrentDuration--;
            

        }

        public void ResestDuration()
        {
            CurrentDuration = _startDuration;
        }

        public virtual void effect(ref Character target){}

        public MyBuff(string name, int dur)
        {
            Name = name;
            _startDuration = dur;
            CurrentDuration = dur; 
        }
    }

    class Statbuff : MyBuff
    {
       internal int Amount { get; set; }
       internal StatType _type { get; set; } 
       internal bool EffectOn = false; 

        public Statbuff(string name, int dur, int statbuffer, StatType type)
            : base(name, dur)
        {
            Amount = statbuffer;
            _type = type; 
        }

        
    }

    class NegativeBuff : Statbuff
    {
        public NegativeBuff(string name, int dur, int statbuffer, StatType type) :
            base(name, dur, statbuffer,type) { }
      
        public override void effect( ref Character target)
        {
            if(!EffectOn)
            {
                target.EditStat(_type, -Amount);  
             EffectOn = true; 
            }
            duration(ref target); 
        }

        public override void duration(ref Character target)
        {
            base.duration(ref target);
            if (CurrentDuration == -1)
            {
                target.CharacterListOfBuffs.Remove(this);
                if (_type != StatType.Health)
                    target.EditStat(_type, Amount); 
                        
                        
            }
        }

        
    }
    /*
    class PositiveBuff : Statbuff
    {
        public PositiveBuff(string name, int dur, int heal, int statbuffer, Stat statter)
            : base(name, dur, statbuffer,statter) { }
      
      public override void effect(Character target)
      {
          foreach (Stat s in target.Statlist)
              if (s == Statter)
                  s.ChangeAmount(Amount);
          EffectOn = true; 
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
