using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
     abstract class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public int Cost { get; set; }
        public virtual void DoEffect(Character target, Character source) { }
        public abstract bool CheckSkill(); 

        
        public Skill(string name, string description)
        {
            Name = name;
            Description = description;
        }
         
    }
 
}
