using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Robot_Assignment
{
    internal class RobotProcessor
    {
        private readonly List<string> directions = new() { "NORTH", "EAST", "WEST", "SOUTH" };
        public string Result { get; set; } = string.Empty;

        public string ErrorMessage = "Please provide valid instruction";
        public RobotPosition? RobotPosition { get; set; }
        
        public Dimensions Dimensions = new(5,5);

        public void InstructionProcessor(string instruction)
        {
            if (Regex.IsMatch(instruction, "PLACE"))
            {
                RobotPosition = new RobotPosition(Dimensions);
                string[] coordinates = instruction.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (coordinates.Length == 4)
                {
                    bool isValidX = Int32.TryParse(coordinates[1], out int x);
                    bool isValidY = Int32.TryParse(coordinates[2], out int y);

                    if (isValidX && isValidY && directions.Contains(coordinates[3])) 
                    { 
                        RobotPosition.RobotPlace(x, y, coordinates[3]); 
                    }
                    else 
                    { 
                        Result = ErrorMessage; 
                    }
                }
                else if (RobotPosition.Dimensions == null || RobotPosition.RobotInstructions == null)
                {
                    Result = ErrorMessage;
                }
            }
            else if (Regex.IsMatch(instruction, "LEFT") || Regex.IsMatch(instruction, "RIGHT") || Regex.IsMatch(instruction, "MOVE"))
            {
                RobotPosition?.RobotMoves(instruction.ToLower());
            }
            else if (Regex.IsMatch(instruction, "REPORT"))
            {
               Result = RobotPosition?.ViewRobotPosition();
            }
            else
            {
                Result = ErrorMessage;
            }
        }
    }
}
