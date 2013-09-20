using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
  class Program
  {
    static void Main(string[] args)
    {
      #region haX'd
      //// Sets op the awsome box's for the console window
      ConsoleSettings();
      #endregion

      Program P = new Program();

      Hero spanieL = new Hero("spanieL", 100, 6);
      Creature Rat = new Creature("Rat", 50, 10);

      #region haX'd
      //// Hardcodet atm, shouldn't be, also need to specify hero and creature through classes and not string if possible
      HealthBarController("Hero", spanieL.Health, spanieL.Health);
      HealthBarController("Creature", Rat.Health, Rat.Health);
      #endregion

      //Skills for spanieL
      SkillDamage attack = new SkillDamage("Attack", "", 1, 5);
      SkillDamage awesomeBlow = new SkillDamage("Awesome Blow", "", 2, 10);
      SkillFireballEffect fireball = new SkillFireballEffect("Fireball", "", 1, 2, 3, 5, SkillFireballEffect.EnumTarget.Target, SkillFireballEffect.EnumBuffType.Hp);
      P.AddSkillToCharacter(spanieL, attack);
      P.AddSkillToCharacter(spanieL, awesomeBlow);
      P.AddSkillToCharacter(spanieL, fireball);

      //Skills for Rat
      SkillDamage BasicAttack = new SkillDamage("Basic Attack", "", 1, 2);
      SkillDamage SuperStrike = new SkillDamage("Super Strike", "", 2, 5);
      P.AddSkillToCharacter(Rat, BasicAttack);
      P.AddSkillToCharacter(Rat, SuperStrike);

      //Creates a combat with the hero and a creature. Limited to only two characters per fight atm.
      Combat combat1 = new Combat(spanieL, Rat);
      combat1.CombatStart();

      Console.ReadLine();
    }

    private void AddSkillToCharacter(Character character, SkillDamage skill)
    {
      character.CharacterListOfSkills.Add(skill);
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

    //// Console settings as the name of the methode
    static void ConsoleSettings()
    {
      Console.CursorVisible = false;
      Console.Title = "Random RPG 2013";
      Console.SetWindowSize(65, 33);
      Console.BufferWidth = 65;
      Console.BufferHeight = 33;

      Frames();
    }

    //// Creates the frames semi automatically will need to be fully automatically + Atm only works for 2
    static void Frames()
    {
      //// Frame - Game
      Console.WriteLine("\n  ┌" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth - 6)) + "┐");
      for (int i = 0; i < Console.WindowHeight - 4; i++)
        Console.WriteLine("  │" + string.Join("", Enumerable.Repeat(" ", Console.WindowWidth - 6)) + "│");
      Console.Write("  └" + string.Join("", Enumerable.Repeat("─", Console.WindowWidth - 6)) + "┘");

      //// Frame - Enemy
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

      //// Frame - Hero
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
    #endregion
  }
}
