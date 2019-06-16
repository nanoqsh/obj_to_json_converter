namespace ObjJsonConverter
{
    class Model
    {
        public readonly float[][] Positions;
        public readonly float[][]? Normals;
        public readonly float[][] TextureMap;
        public readonly string? FullSides;
        public readonly Face[] Faces;

        public Model(float[][] positions, float[][] normals, float[][] textureMap, string fullSides, Face[] faces)
        {
            Positions = positions;
            Normals = normals;
            TextureMap = textureMap;
            FullSides = fullSides;
            Faces = faces;
        }
    }
}
