using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
	/// This is still work in progres and cause of that it still needs to be implemted 
	class Navigation
	{
		static string[] skills;
		static int index = 0;

		public static void Navigator(string[] args)
		{
			Console.CursorVisible = false;

			SkillList();
			DrawSkillList();

			while (true)
			{
				GetKeyboardState();
				DrawSkillList();
			}
		}

		static void SkillList()
		{
			skills = new string[] {"1. Skill", "2. Skill", "3. Skill" };
		}

		static void GetKeyboardState()
		{
			ConsoleKeyInfo info = Console.ReadKey(true);
			if (info.Key == ConsoleKey.DownArrow || info.Key == ConsoleKey.RightArrow)
			{
				if (index < skills.Length - 1)
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
				/// We add one to index because of the skill-switch begin with case 1
				Skills(index + 1);
			}
		}

		public static void DrawSkillList()
		{
			Console.SetCursorPosition(Console.WindowWidth - 30, Console.WindowHeight - 10);
			
			Console.WriteLine("Choose action:");

			for (int i = 0; i < skills.Length; i++)
			{
				Console.SetCursorPosition(Console.WindowWidth - 30, Console.WindowHeight - (9 - i));
				if (i == index)
				{
					Console.BackgroundColor = ConsoleColor.Blue;
					Console.WriteLine(skills[i]);
					Console.ResetColor();
				}
				else
				{
					Console.WriteLine(skills[i]);
				}
			}
			Console.ResetColor();
		}

		static void Skills(int index)
		{
			switch (index)
			{
				case 1:
					Console.SetCursorPosition(Console.WindowHeight / 2, Console.WindowHeight / 2);
					Console.WriteLine("1. Skill used");
					break;

				case 2:
					Console.SetCursorPosition(Console.WindowHeight / 2, Console.WindowHeight / 2);
					Console.WriteLine("2. Skill used");
					break;

				case 3:
					Console.SetCursorPosition(Console.WindowHeight / 2, Console.WindowHeight / 2);
					Console.WriteLine("3. Skill used");
					break;

				default:

					break;
			}
		}
	}
}
