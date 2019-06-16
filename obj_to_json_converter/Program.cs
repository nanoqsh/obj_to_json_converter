using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace ObjJsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();

            string line;
            while ((line = Console.ReadLine()) != null)
                lines.Add(line);

            Model model = Converter.Convert(lines);

            var jsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string result = JsonConvert.SerializeObject(
                model,
                Formatting.Indented,
                jsonSettings
                );

            Console.WriteLine(result);
        }
    }
}
