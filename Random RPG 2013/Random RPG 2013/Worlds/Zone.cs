using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_RPG_2013
{
    public enum ZoneType { Forest, Dungeon, Cave }
  class Zone
  {
      public string Name { get; set; }
      public int width { get; set; }
      public int height { get; set; }
      public Dictionary<Zone, int[]> ZonesInZone;
      public Dictionary<Town, int[]> Towns = new Dictionary<Town,int[]>(); 

      public Zone(string name, int wi, int hei)
      {
          Name = name;
          width = wi;
          height = hei; 
      }
  }

  class Town
  {
      public string Name { get; set; }
      public List<Merchant> Stores { get; set; }
      public List<NPC> People { get; set; }

      public Town(string name, List<Merchant> store)
      {
          Name = name;
          Stores = store;
         // this.People = peeps; 
      }
  }

  class TownMovement
  {
      Town town;

      public void EnterTown()
      {
          bool x = true; 
          Console.WriteLine("Welcome to " + town.Name);
          while (x)
          {
              Console.WriteLine("1.Merchants");

              if (Console.ReadLine() == "1")
                  DisplayMerchants();
              else
              {
                  Console.WriteLine("Goodbye then u asshole");
                  x = false; 
              }
          }

      }

      private void DisplayMerchants()
      {
          Console.Clear(); 
          foreach (Merchant m in town.Stores)
              Console.WriteLine(m.Name);
          Console.ReadLine();
          Console.Clear(); 
      }

      public TownMovement(Town andeby)
      {
          this.town = andeby; 
      }
  }

  class Movement
  {
      Zone zone;

      // 0 Is East, 1 is West, 2 is North, 3 is South 
      int[] Postition =  new int[4];

      public void Walking()
      {
          while (true)
          {
              Console.WriteLine("East: " + Postition[0] + " West: " + Postition[1] + " North: " + Postition[2] + " South: " + Postition[3]);
              Move();
              Console.ReadLine();
              Console.Clear(); 
          }
      }

      private void Move()
      {
          Console.WriteLine("Where u wanna go bro"); 
          string direction = Console.ReadLine();

          if (direction == "east")
              UpdatePostion(0, 1, zone.width);
          else if (direction == "west")
              UpdatePostion(1, 0, zone.width);
          else if (direction == "north")
              UpdatePostion(2, 3, zone.height);
          else if (direction == "south")
              UpdatePostion(3, 2, zone.height);
          else
              Console.WriteLine("INVALID OPERATION");

          foreach (KeyValuePair<Town, int[]> t in zone.Towns)
          {
              if (Enumerable.SequenceEqual(t.Value, Postition))
              {
                  Console.WriteLine("Do u want to enter " + t.Key.Name);  
                      if(Console.ReadLine() == "yes")
                          EnterTown(t.Key);
              }
          }

      }

      private void EnterTown(Town town)
      {
          TownMovement by = new TownMovement(town);

          by.EnterTown(); 
      }

      private void UpdatePostion(int Towards, int Away, int maxdistance)
      {
          if (Postition[Towards] == maxdistance)
              Console.WriteLine("Can not go that way son");

          else
          {
              Postition[Towards]++;
              Postition[Away]--;
          }
      }

      public Movement(int[] posistion, Zone zoner)
      {
          Postition = posistion;
          zone = zoner; 
      }
  }
}
