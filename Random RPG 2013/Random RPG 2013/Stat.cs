using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    public enum StatType { Health,Attack, Dex }; 
    class Stat
    {
        public StatType Kind; 
        public  int Amount { get; set; }

     

        public Stat(int amount, StatType type)
        {
            Kind = type; 
            Amount = amount; 
        }

        public void ChangeAmount(int change)
        {
            Amount += change; 
        }

        
    }
}
