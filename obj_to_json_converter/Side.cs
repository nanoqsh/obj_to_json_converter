namespace ObjJsonConverter
{
    enum Side
    {
        None  = 0,
        Up    = 1 << 0,
        Down  = 1 << 1,
        Left  = 1 << 2,
        Right = 1 << 3,
        Front = 1 << 4,
        Back  = 1 << 5
    }

    static class SideMethods
    {
        public static string GetString(this Side side)
        {
            string result = "";

            if (side.Contain(Side.Up)) result += "u";
            if (side.Contain(Side.Down)) result += "d";
            if (side.Contain(Side.Left)) result += "l";
            if (side.Contain(Side.Right)) result += "r";
            if (side.Contain(Side.Front)) result += "f";
            if (side.Contain(Side.Back)) result += "b";

            return result;
        }

        public static bool Contain(this Side side, Side other) =>
            (side & other) == other;
    }
}
