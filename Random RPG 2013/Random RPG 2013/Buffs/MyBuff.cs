using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    interface IEffect 
    { 
        void effect(Character target, Character source);
        void effect(Character source);           
    }

    abstract class OneTime : IEffect
    {
        internal StatType stat; 
        public virtual void effect(Character target, Character source) {}
        public virtual void effect(Character target){}
    }

    class Offense : OneTime
    {
        int min_damage { get; set; }
        int max_damage { get; set; }

        public override void effect(Character target, Character source)
        {
            target.EditStat(StatType.Health, -min_damage); 
        }

        public Offense(StatType type, int min)
        {
            min_damage = min;
            stat = type; 
        }
    }

    class Defense : OneTime
    {
        int min;
        int max;

        public override void effect(Character source )
        {
            source.Health += min; 
        }
    }

    #region BUFFS
    abstract class MyBuff : IEffect, IEquatable<MyBuff>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private int _startDuration; 
        internal int CurrentDuration { get; set; }

        internal virtual void Revert(Character target){}

        public virtual void effect(Character target) { }
        public virtual void effect(Character source, Character target) { }
     

        internal int duration()
        {
            return CurrentDuration--;
        }

        public void ResestDuration()
        {
            CurrentDuration = _startDuration;
        }      

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

    public enum PositiveOrNegative { Positive, Negative }
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

        public override void effect(Character target)
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
                target.EditStat(_type, Amount);

        }        


    }
    class PercentageBuff : Statbuff
    {
        double Percentage { get; set; }
        public PercentageBuff(string name, int dur, StatType type, double percentage)
            : base(name, dur, 0, type)
        {
            this.Percentage = percentage; 
        }

        private int CalcPercent(Character target)
        {
            int Originalstat = target.GetStat(_type);
            double k = Originalstat * (Percentage / 100); 
            return (int)k; 
        }

        public override void effect(Character source, Character target)
        {
            Amount = CalcPercent(target); 
            base.effect(source, target);
        }
    }



    class StatusEffect : MyBuff
    {
        public StatusEffect(string name, int dur)
            : base(name, dur) { }

        public override void effect( Character target)
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
#endregion 
}

    
   
     


