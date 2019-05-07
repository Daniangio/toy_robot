using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobot {

  class Controller
  {

    private Robot robot;
    private bool isRobotPlaced = false;

    private static List<string> ParseInputFile(string filename) {
      List<string> instructions = new List<string>();

      if (filename == null) {
          Console.WriteLine("Filename is null");
          return instructions;
      }
      string path = Directory.GetParent(Directory.GetCurrentDirectory()) + "\\InputFiles\\" + filename;

      if (!File.Exists(path)) {
          Console.WriteLine("File does not exist.");
          return instructions;
      }

      // Open the file to read from.
      using (StreamReader sr = File.OpenText(path)) {
        string s;
        // Add one line at a time to the list of instructions
        while ((s = sr.ReadLine()) != null) {
          instructions.Add(s);
        }
      }
      return instructions;
    }

    public void ProvideInstruction(string instr) {
      string[] instruction = instr.Split(new Char[] {' ', ','});

      if (instruction.Length == 4) {
        int X,Y;
        string direction;
        X = int.Parse(instruction[1]);
        Y = int.Parse(instruction[2]);
        direction = instruction[3];
        if (instruction[0] == "PLACE" &&
            X >= Globals.minX && X <= Globals.maxX &&
            Y >= Globals.minX && Y <= Globals.maxX &&
            Globals.possibleDirections.Any(direction.Contains)) {
            if (!isRobotPlaced) {
              this.robot = new Robot(X,Y,direction);
              this.isRobotPlaced = true;
            }
            else {
              robot.Place(X,Y,direction);
            }
        }
      }
      else
        if (instruction.Length == 1 && isRobotPlaced)
          switch (instruction[0]) {
            case "MOVE":
              robot.Move();
              break;
            case "LEFT":
              robot.Left();
              break;
            case "RIGHT":
              robot.Right();
              break;
            case "REPORT":
              robot.Report();
              break;
      }
    }

    static void Main(string[] args) {
        Controller controller = new Controller();
        List<string> instructions = ParseInputFile(args[0]);

        foreach (string instr in instructions) {
          controller.ProvideInstruction(instr);
      }
    }

  }

}
