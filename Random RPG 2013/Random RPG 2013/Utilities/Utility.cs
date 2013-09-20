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
    //May not be useful as a generic method.
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
				  #region haX'd
				  //// Print out error text and make sure to clean/overwrite the space on the console on which the text is presented
				  string errorText = "Input not accepted.";
				  Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2);
				  Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
				  Console.SetCursorPosition(((Console.WindowWidth - errorText.Length) / 2), Console.WindowHeight / 2);
				  Console.WriteLine(errorText);

				  //// Center the cursor
				  Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2 - 1);
				  Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
				  Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 1);
				  #endregion haX'd
				  inputAccepted = false;
			  }
		  }
		  else
		  {
			  #region haX'd
			  //// Print out error text and make sure to clean/overwrite the space on the console on which the text is presented
			  string errorText = "Input not accepted.";
			  Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2);
			  Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			  Console.SetCursorPosition(((Console.WindowWidth - errorText.Length) / 2), Console.WindowHeight / 2);
			  Console.WriteLine(errorText);

			  //// Center the cursor
			  Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2 - 1);
			  Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			  Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 1);
			  #endregion haX'd
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
	  #region haX'd
	  //// Print out combat text and make sure to clean/overwrite the space on the console on which the text is presented
	  string combatText = (sourceName + " did " + sourceDamage + " damage to " + targetName + ".");
	  Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
	  Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 2)));
	  Console.SetCursorPosition(((Console.WindowWidth - combatText.Length) / 2), Console.WindowHeight / 2);
      Console.WriteLine(combatText);
	  
      ////  This part is atm hardcode.. will need a fix + Only works for the Hero and NOT creature
	  HealthBarController("Hero", 100, targetHealth);
	  #endregion haX'd
	}

	#region haX'd
	//// Contain a lot of crappy code to control size and posistion of healthbars - Atm only works for 2
	static void HealthBarController(string Target, double HealthMax, double HealthCurrent)
	{
		double procental = 100 / HealthMax * HealthCurrent;
		int healthBar = 0;
		int nr = 0;

		if (Target == "Creature")
		{
			if (procental > 90) { healthBar = 10; nr = 21; }
			if (procental == 90 || procental < 90 && procental > 80) { healthBar = 9; nr = 22; }
			if (procental == 80 || procental < 80 && procental > 70) { healthBar = 8; nr = 23; }
			if (procental == 70 || procental < 70 && procental > 60) { healthBar = 7; nr = 24; }
			if (procental == 60 || procental < 60 && procental > 50) { healthBar = 6; nr = 25; }
			if (procental == 50 || procental < 50 && procental > 40) { healthBar = 5; nr = 26; }
			if (procental == 40 || procental < 40 && procental > 30) { healthBar = 4; nr = 27; }
			if (procental == 30 || procental < 30 && procental > 20) { healthBar = 3; nr = 28; }
			if (procental == 20 || procental < 20 && procental > 10) { healthBar = 2; nr = 29; }
			if (procental == 10 || procental < 10 && procental > 0) { healthBar = 1; nr = 30; }
			if (procental == 0) { healthBar = 0; nr = 31; }

			Console.SetCursorPosition(Console.WindowWidth - (healthBar + nr), 9);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", 15)));
			Console.SetCursorPosition(Console.WindowWidth - (healthBar + nr), 9);
		}

		if (Target == "Hero")
		{
			if (procental > 90) { healthBar = 10; }
			if (procental == 90 || procental < 90 && procental > 80) { healthBar = 9; }
			if (procental == 80 || procental < 80 && procental > 70) { healthBar = 8; }
			if (procental == 70 || procental < 70 && procental > 60) { healthBar = 7; }
			if (procental == 60 || procental < 60 && procental > 50) { healthBar = 6; }
			if (procental == 50 || procental < 50 && procental > 40) { healthBar = 5; }
			if (procental == 40 || procental < 40 && procental > 30) { healthBar = 4; }
			if (procental == 30 || procental < 30 && procental > 20) { healthBar = 3; }
			if (procental == 20 || procental < 20 && procental > 10) { healthBar = 2; }
			if (procental == 10 || procental < 10 && procental > 0) { healthBar = 1; }
			if (procental == 0) { healthBar = 0; }

			Console.SetCursorPosition(6, Console.WindowHeight - 5);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", 15)));
			Console.SetCursorPosition(6, Console.WindowHeight - 5);
		}

		string HealthBarCurrent = (string.Join("", Enumerable.Repeat(" ", healthBar)));

		HealthBarColorController(procental);

		Console.WriteLine(HealthCurrent + HealthBarCurrent);
		Console.ResetColor();
	}

	//// Handles the coloring of the healthbar
	static void HealthBarColorController(double Procental)
	{
		if (Procental >= 66)
			Console.BackgroundColor = ConsoleColor.DarkGreen;
		else if (Procental >= 33)
			Console.BackgroundColor = ConsoleColor.DarkYellow;
		else
			Console.BackgroundColor = ConsoleColor.DarkRed;
	}
	#endregion haX'd
  }
}
