using System;
using System.IO;

namespace ToyRobot {
  public class Robot
  {
      private int X,Y;
      private string direction;

      public Robot(int X, int Y, string direction) {
        this.X = X;
        this.Y = Y;
        this.direction = direction;
      }

      public void Move() {
        switch(direction) {
          case "NORTH":
            if (this.Y < Globals.maxY)
              this.Y++;
            break;
          case "EAST":
            if (this.X < Globals.maxX)
              this.X++;
            break;
          case "SOUTH":
            if (this.Y > Globals.minY)
              this.Y--;
            break;
          case "WEST":
            if (this.X > Globals.minX)
              this.X--;
            break;
          default:
            break;
        }
      }

      public void Place(int X, int Y, string direction) {
        this.X = X;
        this.Y = Y;
        this.direction = direction;
      }

      public void Left() {
        var index = Array.FindIndex(Globals.possibleDirections, row => row.Contains(direction));
        if (index == 0)
          this.direction = Globals.possibleDirections[Globals.possibleDirections.Length - 1];
        else
          this.direction = Globals.possibleDirections[index - 1];
      }

      public void Right() {
        var index = Array.FindIndex(Globals.possibleDirections, row => row.Contains(direction));
        if (index == Globals.possibleDirections.Length - 1)
          this.direction = Globals.possibleDirections[0];
        else
          this.direction = Globals.possibleDirections[index + 1];
      }

      public void Report() {
        Console.WriteLine(this.X + "," + this.Y + "," + this.direction);
      }
  }
}
