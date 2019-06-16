using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ObjJsonConverter
{
    class Converter
    {
        public static Model Convert(IEnumerable<string> lines)
        {
            List<float[]> positions = new List<float[]>();
            List<Side> sides = new List<Side>();
            List<float[]> textureMap = new List<float[]>();
            List<float[]> normals = new List<float[]>();
            List<Face> faces = new List<Face>();

            foreach (string line in lines)
            {
                string[] words = line.Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                    );

                if (words.Length == 0)
                    continue;

                string token = words[0];
                string[] args = words.Skip(1).ToArray();

                switch (token)
                {
                    case "v":
                        float[] pos = ToFloatArray(args);
                        positions.Add(pos);
                        sides.Add(GetContact(pos));
                        break;

                    case "vt":
                        textureMap.Add(ToFloatArray(args));
                        break;

                    case "vn":
                        normals.Add(ToFloatArray(args));
                        break;

                    case "f":
                        faces.Add(ToFace(args, sides));
                        break;

                    default:
                        break;
                }
            }

            return new Model(
                positions.ToArray(),
                normals.ToArray(),
                textureMap.ToArray(),
                "",
                faces.ToArray()
                );
        }

        private static float ToFloat(string text) =>
            (float)Math.Round(double.Parse(text, CultureInfo.InvariantCulture), 5);

        private static float[] ToFloatArray(IEnumerable<string> args) =>
            args.Select(ToFloat).ToArray();

        private static Side GetContact(float[] position)
        {
            Side side = Side.None;

            if (position[0] >= 0.5f) side |= Side.Left;
            else if (position[0] <= -0.5f) side |= Side.Right;

            if (position[1] >= 0.5f) side |= Side.Up;
            else if (position[1] <= -0.5f) side |= Side.Down;
            
            if (position[2] >= 0.5f) side |= Side.Front;
            else if (position[2] <= -0.5f) side |= Side.Back;

            return side;
        }

        private static Face ToFace(IEnumerable<string> args, List<Side> sides)
        {
            List<int> positions = new List<int>();
            List<int> textureMap = new List<int>();
            int? normal = null;
            bool once = false;
            Side contact =
                  Side.Up
                | Side.Down
                | Side.Left
                | Side.Right
                | Side.Front
                | Side.Back;

            foreach (string unit in args)
            {
                string[] indexes = unit.Split("/");

                int pos = int.Parse(indexes[0]) - 1;
                positions.Add(pos);
                contact &= sides[pos];
                textureMap.Add(int.Parse(indexes[1]) - 1);

                if (indexes.Length == 3 && !once)
                {
                    normal = int.Parse(indexes[2]) - 1;
                    once = true;
                }
            }

            return new Face(
                new Data(positions.ToArray(), textureMap.ToArray(), normal),
                contact.GetString(),
                0
                );
        }
    }
}
