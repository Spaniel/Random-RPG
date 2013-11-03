using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    abstract class MyBuff : IEquatable<MyBuff>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private int _startDuration; 
        internal int CurrentDuration { get; set; }

        internal virtual void Revert(Character target){}

        internal int duration()
        {
            return CurrentDuration--;
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
        #region EqualsStuff
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            return Equals((MyBuff)obj);          
        }

        public bool Equals(MyBuff buff)
        {
            if ((object)buff == null)
                return false; 

            if(ReferenceEquals(this, buff))
                return true; 

            if(GetHashCode() != buff.GetHashCode())
                return false;

            return Name.Equals(buff.Name); 
            
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode(); 
        }

        public static bool operator ==(MyBuff a, MyBuff c)
        {
            if (System.Object.ReferenceEquals(a, c))
                return true;

            if ((object)a == null || (object)c == null)
                return false;

            return a.Name == c.Name; 
        }

        public static bool operator !=(MyBuff a, MyBuff c)
        {
            return !(a == c); 
        }
#endregion
    }

    abstract class Statbuff : MyBuff
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

        public override void effect(ref Character target)
        {
            if (!EffectOn)
            {
                target.EditStat(_type, -Amount);
                if(_type != StatType.Health)
                    EffectOn = true;
            }

            if (duration() == 1)
                Revert(target);
        }

        internal override void Revert(Character target)
        {
            target.CharacterListOfBuffs.Remove(this);
            if (_type != StatType.Health)
                target.EditStat(_type, Amount); 

        }        
    }
    
    class PositiveBuff : Statbuff
    {
        public PositiveBuff(string name, int dur, int statbuffer, StatType type)
            : base(name, dur, statbuffer,type) { }
      
      public override void effect( ref Character target)
      {
          if (!EffectOn)
          {
              target.EditStat(_type, Amount);
              if (_type != StatType.Health) 
                EffectOn = true;
          }
          if (duration() == 1)
              Revert(target); 
      }

      internal override void Revert(Character target)
      {
          target.CharacterListOfBuffs.Remove(this);
          if (_type != StatType.Health)
              target.EditStat(_type, -Amount); 
      }
   }

    class StatusEffect : MyBuff
    {
        public StatusEffect(string name, int dur)
            : base(name, dur) { }

        public override void effect(ref Character target)
        {
            target.IsStunned = true;
            if (duration() == 0)
                Revert(target); 
            
        }

        internal override void Revert(Character target)
        {
            target.CharacterListOfBuffs.Remove(this);
            target.IsStunned = false; 
        } 
    }
   
}

    
   
     


