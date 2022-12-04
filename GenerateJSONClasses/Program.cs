using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NJsonSchema.CodeGeneration.CSharp;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace GenerateJSONClasses
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string schemaData;
            string jsonSchemaPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"NodeRed_JSON_Schema.json");

            using (StreamReader r = new StreamReader(jsonSchemaPath))
            {
                schemaData = r.ReadToEnd();
            }

            var schema = await NJsonSchema.JsonSchema.FromJsonAsync(schemaData);

            var generator = new CSharpGenerator(schema);
            var file = generator.GenerateFile();

             await File.WriteAllTextAsync("CodeGeneratorOutput.cs", file);
        }
    }
}
