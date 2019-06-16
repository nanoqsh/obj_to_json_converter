namespace ObjJsonConverter
{
    class Data
    {
        public readonly int[] Positions;
        public readonly int[] TextureMap;
        public readonly int? Normal;

        public Data(int[] positions, int[] textureMap, int? normal)
        {
            Positions = positions;
            TextureMap = textureMap;
            Normal = normal;
        }
    }
}
