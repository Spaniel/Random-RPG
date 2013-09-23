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
		public static void ConsoleSettings()
		{
			Console.CursorVisible = false;
			Console.Title = "Random RPG 2013";
			Console.SetWindowSize(65, 33);
			Console.BufferWidth = 65;
			Console.BufferHeight = 33;

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

			/// Frame - Enemy
			string frameE = "┌" + string.Join("", Enumerable.Repeat("─", 25)) + "┐";
			Console.SetCursorPosition(Console.WindowWidth - (frameE.Length + 5), 3);
			Console.WriteLine(frameE);
			for (int i = 1; i <= 6; i++)
			{
				Console.SetCursorPosition(Console.WindowWidth - (frameE.Length + 5), 3 + i);
				Console.WriteLine("│" + string.Join("", Enumerable.Repeat(" ", 25)) + "│");
			}
			Console.SetCursorPosition(Console.WindowWidth - (frameE.Length + 5), 10);
			Console.WriteLine("└" + string.Join("", Enumerable.Repeat("─", 25)) + "┘");

			/// Frame - Hero
			string frameH = "┌" + string.Join("", Enumerable.Repeat("─", 25)) + "┐";
			Console.SetCursorPosition(5, Console.WindowHeight - 11);
			Console.WriteLine(frameH);
			for (int i = 1; i <= 6; i++)
			{
				Console.SetCursorPosition(5, Console.WindowHeight - (11 - i));
				Console.WriteLine("│" + string.Join("", Enumerable.Repeat(" ", 25)) + "│");
			}
			Console.SetCursorPosition(5, Console.WindowHeight - 4);
			Console.WriteLine("└" + string.Join("", Enumerable.Repeat("─", 25)) + "┘");
		}
	}
}
