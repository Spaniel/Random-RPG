using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class StatusEffect : Buff
  {
    public enum EnumStatus { Stun, Confuse, Slow }

    public EnumStatus Status { get; set; }

     public StatusEffect(string name, string description, int duration, EnumStatus status, Buff.EnumTargetOfBuff targetOfBuff, Buff.EnumTypeOfBuff typeOfBuff)
      : base(name, description, duration, targetOfBuff, typeOfBuff) 
     {
       Status = status;
     }
  }
}
