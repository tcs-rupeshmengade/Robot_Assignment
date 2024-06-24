namespace Robot_Assignment
{
    internal class RobotPosition
    {
        public RobotInstructions? RobotInstructions { get; set; }
        public Dimensions? Dimensions { get; set; }

        public RobotPosition(Dimensions dimensions)
        { 
            this.Dimensions = dimensions;
        }

        /// <summary>
        /// View robot position - Report
        /// </summary>
        /// <returns></returns>
        public string? ViewRobotPosition()
        {
            return RobotInstructions?.ViewRobotPosition();
        }

        /// <summary>
        /// Robot position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public void RobotPlace(int x, int y, string direction)
        {
            if (Dimensions!=null &&  !Dimensions.IsValidCoOrdinates(x, y))
            {
                return;
            }
            RobotInstructions = new RobotInstructions
            {
                X = x,
                Y = y,
                Direction = direction.ToLower()
            };
        }

        /// <summary>
        /// Robot movement - Left, Right, Move one step
        /// </summary>
        /// <param name="movement"></param>
        public void RobotMoves(string movement)
        {
            switch (movement)
            {
                case "left":
                    RobotInstructions?.MoveToLeft();
                    break;
                case "right":
                    RobotInstructions?.MoveToRight();
                    break;
                case "move":
                    if (Dimensions != null && RobotInstructions!= null && Dimensions.IsValidCoOrdinates(RobotInstructions.X + 1, RobotInstructions.Y + 1)
                        && Dimensions.IsValidCoOrdinates(RobotInstructions.X - 1, RobotInstructions.Y - 1))
                        {
                            RobotInstructions?.MoveOneStep();
                        }
                    break;
            }
        }
    }
}
