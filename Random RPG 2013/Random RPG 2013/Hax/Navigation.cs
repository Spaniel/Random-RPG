using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
	class Navigation
	{
		static int index = 0;

		public static void Navigator()
		{
			DrawSkillList();

			while (Combat.Hero.Health > 0 && Combat.Creature.Health > 0)
			{
				GetKeyboardState();
				DrawSkillList();
			}

			Interface.GameOver();
		}

		static void GetKeyboardState()
		{
			ConsoleKeyInfo info = Console.ReadKey(true);
			if (info.Key == ConsoleKey.DownArrow || info.Key == ConsoleKey.RightArrow)
			{
				if (index < Combat.Hero.CharacterListOfSkills.Count() - 1)
				{
					index++;
				}
			}

			if (info.Key == ConsoleKey.UpArrow || info.Key == ConsoleKey.LeftArrow)
			{
				if (index > 0)
				{
					index--;
				}
			}

			if (info.Key == ConsoleKey.Enter)
			{
				Skills(index + 1);
			}
		}

		public static void DrawSkillList()
		{
			Console.SetCursorPosition(Console.WindowWidth / 3 * 2, Console.WindowHeight - 10);

			Console.WriteLine("Choose action:");

			for (int i = 0; i < Combat.Hero.CharacterListOfSkills.Count(); i++)
			{
				Console.SetCursorPosition(Console.WindowWidth / 3 * 2, Console.WindowHeight - (9 - i));
				if (i == index)
				{
					Console.BackgroundColor = ConsoleColor.Blue;
					Console.WriteLine("{0}. {1}", i + 1, Combat.Hero.CharacterListOfSkills[i].Name);
					Console.ResetColor();
				}
				else
				{
					Console.WriteLine("{0}. {1}", i + 1, Combat.Hero.CharacterListOfSkills[i].Name);
				}
			}
			Console.ResetColor();

			Console.SetCursorPosition(Console.WindowLeft + 3, Console.WindowHeight / 2 - 1);
			Console.WriteLine(string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)));
			Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 1);
		}

		public static void Skills(int Index)
		{
			Interface.SelectedSkill_Hero(Index);
			Interface.SelectedSkill_Creature(1);

			Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);

			/// WTF! Dont know whats going on here.. but if you comment either one of the to damagepahases out.. well try run it...
			Combat.DamagePhase(Combat.Hero, Combat.Creature, Index - 1);
			Combat.DamagePhase(Combat.Creature, Combat.Hero, 1);
		}
	}
}
