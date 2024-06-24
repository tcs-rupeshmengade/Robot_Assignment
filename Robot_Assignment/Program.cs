// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using Robot_Assignment;

#region Program initialization
RobotProcessor robotProcessor = new();
repeat_program:
Console.WriteLine("***** Welcome to the Robot movement program *****");

Console.WriteLine("\n-----  PLEASE NOTE  -----");

Console.WriteLine(@"Instructions should be in below format only:
PLACE X,Y,DIRECTION
MOVE
LEFT
RIGHT
REPORT
");
Console.WriteLine(); 
#endregion

#region PLACE INSTRUCTION

repeat_place_instruction:
Console.WriteLine("Please enter PLACE instruction e.g (PLACE 1,1,NORTH)");
var placeInstruction = Console.ReadLine()?.ToString();
if (!string.IsNullOrEmpty(placeInstruction) && Regex.IsMatch(placeInstruction, "PLACE"))
{
    robotProcessor.InstructionProcessor(placeInstruction);
}
else 
{
    Console.WriteLine("\n" + robotProcessor.ErrorMessage);
    goto repeat_place_instruction;
}

if (!string.IsNullOrEmpty(robotProcessor.Result))
{
    Console.WriteLine("\n" + robotProcessor.Result);
    robotProcessor.Result = string.Empty;
    goto repeat_place_instruction;
}

#endregion

#region NEXT INSTRUCTIONS LEFT  |  RIGHT  |  MOVE

repeat_next_instruction:
Console.WriteLine("\nPlease enter NEXT instruction in capital letter e.g. LEFT  |  RIGHT  | MOVE  |  REPORT");
var nextInstruction = Console.ReadLine()?.ToString();
if (!string.IsNullOrEmpty(nextInstruction))
{
    robotProcessor.InstructionProcessor(nextInstruction.Trim());
}
else
{ 
    goto repeat_next_instruction;
}

#endregion

#region VIEW REPORT

Console.WriteLine("\nWould you like to see REPORT? - YES|NO");
var result = Console.ReadLine()?.ToLower().Trim();

if (result == "yes" || result == "y")
{
    robotProcessor.InstructionProcessor("REPORT");
    if (!string.IsNullOrEmpty(robotProcessor.Result))
    {
        Console.WriteLine("\n----- Result ----- \n" + robotProcessor.Result);
    }
    else
    {
        Console.WriteLine("\nTable boundaries / dimensions are exceeded, so no result to show.");
    }
}
else
{
    goto repeat_next_instruction;
}

#endregion

#region Continue  or exit the program.
Console.WriteLine("\nWould you like to continue with program?  YES|NO");
var response = Console.ReadLine()?.ToLower().ToString().Trim();
if (response == "yes" || response == "y")
{
    robotProcessor.Result = string.Empty;
    goto repeat_program;
}
else 
{
    Environment.Exit(0);
}
#endregion