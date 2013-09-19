using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Utility
  {
    //Could maybe be made generic, so this method could validate ints, floats, doubles etc. 
    //Not sure how to avoid try.parsing or how to try.parse a generic type.
    public static int ValidateUserInput(int upperLimit)
    {
      bool inputAccepted = false;
      string _userInput;
      int userInput = 0;

      while (inputAccepted == false)
      {
        _userInput = Console.ReadLine();

        if (int.TryParse(_userInput, out userInput))
        {
          if (userInput >= 1 && userInput <= upperLimit)
            inputAccepted = true;
          else
          {
            Console.WriteLine("Input not accepted.");
            inputAccepted = false;
          }
        }
        else
        {
          Console.WriteLine("Input not accepted.");
          inputAccepted = false;
        }
      }

      return userInput;
    }

    //Generates a random number between a given lower and upper limit.
    public static int GenerateRandomNumber(int lowerLimit, int upperLimit)
    {
      Random num = new Random();
      int randomNum = num.Next(lowerLimit, upperLimit);

      return randomNum;
    }

    public static void CombatLog(string sourceName, int sourceDamage, string targetName, int targetHealth)
    {
      Console.WriteLine("{0} did {1} damage to {2}. {3} has {4} health left.", sourceName, sourceDamage, targetName, targetName, targetHealth);
    }
  }
}
