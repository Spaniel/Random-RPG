using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Utility
  {
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
            /// Print out error text and make sure to clean/overwrite the space on the console on which the text is presented
            string errorText = "Input not accepted.";
            Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2);
            Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
            Console.SetCursorPosition(((Console.WindowWidth - errorText.Length) / 2), Console.WindowHeight / 2);
            Console.WriteLine(errorText);

            /// Center the cursor
            Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2 - 1);
            Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 1);

            inputAccepted = false;
          }
        }
        else
        {
          inputAccepted = false;
        }
      }

      return userInput;
    }

    //Generates a random number between a given lower and upper limit.
    public static int GenerateRandomNumber(int lowerLimit, int upperLimit)
    {
      Random num = new Random();
      int randomNum = num.Next(lowerLimit, upperLimit + 1);

      return randomNum;
    }

    public static void CombatLog(string sourceName, int sourceDamage, string targetName, int targetHealth)
    {
      /// Print out combat text and make sure to clean/overwrite the space on the console on which the text is presented
      if (sourceName == Combat.Hero.Name)
      {
        string combatText = (sourceName + " did " + sourceDamage + " damage to " + targetName + ".");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 + 1);
        Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 2)));
        Console.SetCursorPosition(((Console.WindowWidth - combatText.Length) / 2), Console.WindowHeight / 2 + 1);
        Console.WriteLine(combatText);
      }
      if (sourceName == Combat.Creature.Name)
      {
        string combatText = (sourceName + " did " + sourceDamage + " damage to " + targetName + ".");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 2);
        Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 2)));
        Console.SetCursorPosition(((Console.WindowWidth - combatText.Length) / 2), Console.WindowHeight / 2 - 2);
        Console.WriteLine(combatText);
      }

      ///  This part is atm hardcode.. will need a fix.. also wtf targetHealth = Hero while I have to use Combat.Creature.Health for the Creature :S
      Interface.HealthBarController("Hero", 100, targetHealth);
      Interface.HealthBarController("Creature", 50, Combat.Creature.Health);
    }
  }
}
