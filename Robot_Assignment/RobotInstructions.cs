namespace Robot_Assignment
{
    internal class RobotInstructions
    {
        #region Variables

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public string Direction { get; set; }

        #endregion

        #region Public Methods
        
        public RobotInstructions() { }

        /// <summary>
        /// View robot position
        /// </summary>
        /// <returns></returns>
        public string? ViewRobotPosition()
        { 
            return X + "," + Y + "," + Direction.ToUpper();
        }

        /// <summary>
        /// Move Robot to the Left
        /// </summary>
        public void MoveToLeft()
        {
            switch (Direction)
            {
                case "east":
                    Direction = "north";
                    break;
                case "west":
                    Direction = "south";
                    break;
                case "north":
                    Direction = "west";
                    break;
                case "south":
                    Direction = "east";
                    break;
                default:
                    Direction = "Please enter valid direction";
                    break;
            }
        }

        /// <summary>
        /// Move Robot to the Right
        /// </summary>
        public void MoveToRight()
        {
            switch (Direction)
            {
                case "east":
                    Direction = "south";
                    break;
                case "west":
                    Direction = "north";
                    break;
                case "north":
                    Direction = "east";
                    break;
                case "south":
                    Direction = "west";
                    break;
                default:
                    Direction = "Please enter valid direction";
                    break;
            }
        }

        /// <summary>
        /// Move robot one step
        /// </summary>
        public void MoveOneStep()
        {
            switch (Direction)
            {
                case "east":
                    X += 1;
                    break;
                case "west":
                    X -= 1;
                    break;
                case "north":
                    Y += 1;
                    break;
                case "south":
                    Y -= 1;
                    break;
            }
        }
        #endregion
    }
}
