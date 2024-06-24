namespace Robot_Assignment
{
    /// <summary>
    /// Dimensions of the table
    /// </summary>
    internal class Dimensions
    {
        public int Width { get; set; }
        public int Length { get; set; }

        public Dimensions(int width, int length)
        {
            this.Width = width;
            this.Length = length;
        }

        /// <summary>
        /// Return true if the co-ordinates are valid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsValidCoOrdinates(int x, int y)
        { 
            return x >= 0 && x < Width && y >= 0 && y < Length;
        }
    }
}
