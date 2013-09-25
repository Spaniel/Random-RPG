using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
	class Interface
	{
		/// Console settings as the name of the methode
		public static void ConsoleSettings(int Width, int Heigth)
		{
			Console.CursorVisible = false;
			Console.Title = "Random RPG 2013";
			Console.SetWindowSize(Width, Heigth);
			Console.BufferWidth = Width;
			Console.BufferHeight = Heigth;

			Frames();
		}

		/// Creates the frames semi automatically will need to be fully automatically + Atm only works for 2
		static void Frames()
		{
			/// Frame - Game
			Console.WriteLine("\n  ┌" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth - 6)) + "┐");
			for (int i = 0; i < Console.WindowHeight - 4; i++)
				Console.WriteLine("  │" + string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)) + "│");
			Console.Write("  └" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth - 6)) + "┘");

			/// Frame - Creature
			string frameC = "┌" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth / 3)) + "┐";
			Console.SetCursorPosition(Console.WindowWidth - (frameC.Length + 5), 3);
			Console.WriteLine(frameC);
			for (int i = 1; i <= 6; i++)
			{
				Console.SetCursorPosition(Console.WindowWidth - (frameC.Length + 5), 3 + i);
				Console.WriteLine("│" + string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 3)) + "│");
			}
			Console.SetCursorPosition(Console.WindowWidth - (frameC.Length + 5), 10);
			Console.WriteLine("└" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth / 3)) + "┘");

			/// Frame - Hero
			string frameH = "┌" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth / 2)) + "┐";
			Console.SetCursorPosition(5, Console.WindowHeight - 11);
			Console.WriteLine(frameH);
			for (int i = 1; i <= 6; i++)
			{
				Console.SetCursorPosition(5, Console.WindowHeight - (11 - i));
				Console.WriteLine("│" + string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 2)) + "│");
			}
			Console.SetCursorPosition(5, Console.WindowHeight - 4);
			Console.WriteLine("└" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth / 2)) + "┘");
		}
		#region Health
		/// Contain a lot of crappy code to control size and posistion of healthbars - Atm only works for 2
		public static void HealthBarController(string Target, double HealthMax, double HealthCurrent)
		{
			double procental = 100 / HealthMax * HealthCurrent;
			int healthBarNow = 0;

			if (Target == "Hero")
			{
				double healthBarMaxLength = (double)string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 2 - 3)).Length;

				if (procental > 90) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 10); }
				if (procental == 90 || procental < 90 && procental > 80) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 9); }
				if (procental == 80 || procental < 80 && procental > 70) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 8); }
				if (procental == 70 || procental < 70 && procental > 60) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 7); }
				if (procental == 60 || procental < 60 && procental > 50) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 6); }
				if (procental == 50 || procental < 50 && procental > 40) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 5); }
				if (procental == 40 || procental < 40 && procental > 30) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 4); }
				if (procental == 30 || procental < 30 && procental > 20) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 3); }
				if (procental == 20 || procental < 20 && procental > 10) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 2); }
				if (procental == 10 || procental < 10 && procental > 0) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 1); }
				if (procental == 0) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 0); }

				Console.SetCursorPosition(6, Console.WindowHeight - 5);
				Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 2)));
				Console.SetCursorPosition(6, Console.WindowHeight - 5);
			}

			if (Target == "Creature")
			{
				double healthBarMaxLength = (double)string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 3 - 2)).Length;

				if (procental > 90) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 10); }
				if (procental == 90 || procental < 90 && procental > 80) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 9); }
				if (procental == 80 || procental < 80 && procental > 70) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 8); }
				if (procental == 70 || procental < 70 && procental > 60) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 7); }
				if (procental == 60 || procental < 60 && procental > 50) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 6); }
				if (procental == 50 || procental < 50 && procental > 40) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 5); }
				if (procental == 40 || procental < 40 && procental > 30) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 4); }
				if (procental == 30 || procental < 30 && procental > 20) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 3); }
				if (procental == 20 || procental < 20 && procental > 10) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 2); }
				if (procental == 10 || procental < 10 && procental > 0) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 1); }
				if (procental == 0) { healthBarNow = (int)Math.Ceiling(healthBarMaxLength / 10 * 0); }

				Console.SetCursorPosition(Console.WindowWidth / 3 * 2 - 6, 9);
				Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth / 3)));
				Console.SetCursorPosition(Console.WindowWidth / 3 * 2 - 6, 9);
			}

			string HealthBarCurrent = (string.Join("", Enumerable.Repeat(" ", healthBarNow)));

			HealthBarColorController(procental);

			Console.WriteLine(HealthCurrent + HealthBarCurrent);
			Console.ResetColor();
		}

		/// Handles the coloring of the healthbar
		public static void HealthBarColorController(double Procental)
		{
			if (Procental >= 66)
				Console.BackgroundColor = ConsoleColor.DarkGreen;
			else if (Procental >= 33)
				Console.BackgroundColor = ConsoleColor.DarkYellow;
			else
				Console.BackgroundColor = ConsoleColor.DarkRed;
		}
		#endregion

		#region SelectedSkill
		/// Prints the selected skill from Hero and prints it in the console
		public static void SelectedSkill_Hero(int Index)
		{
			//Console.SetCursorPosition(5, Console.WindowHeight - 12);
			Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight - 12);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			Console.SetCursorPosition((Console.WindowWidth - Combat.Hero.CharacterListOfSkills[Index - 1].Name.Length) / 4 + 5, Console.WindowHeight - 12);
			Console.WriteLine(Combat.Hero.CharacterListOfSkills[Index - 1].Name);
		}

		/// Prints the selected skill from Creature and prints it in the console
		public static void SelectedSkill_Creature(int Index)
		{
			Console.SetCursorPosition(Console.WindowLeft + 3, 11);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			Console.SetCursorPosition((Console.WindowWidth - Combat.Creature.CharacterListOfSkills[Index - 1].Name.Length) / 3 * 2 + 8, 11);
			Console.WriteLine(Combat.Creature.CharacterListOfSkills[Index - 1].Name);
		}

		#endregion

		public static void GameOver()
		{
			Console.ReadLine();
			Console.Clear();
			Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2 - 3);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2 - 1);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			string finalText = "GAME OVER";
			Console.SetCursorPosition((Console.WindowWidth - finalText.Length) / 2, Console.WindowHeight / 2);
			Console.WriteLine(finalText);
			Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 1);
		}
	}
}
