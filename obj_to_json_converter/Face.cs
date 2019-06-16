namespace ObjJsonConverter
{
    class Face
    {
        public readonly Data Data;
        public readonly string? Contact;
        public readonly uint Layer;

        public Face(Data data, string contact, uint layer)
        {
            Data = data;
            Contact = contact;
            Layer = layer;
        }
    }
}
