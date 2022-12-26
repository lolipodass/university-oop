namespace RunProgram
{
    public class Vector
    {
        public int x
        { get; private set; }
        public int y
        { get; private set; }

        public int z
        { get; private set; }

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return $"x: {x},y: {y},z:{z}";
        }
    }
}