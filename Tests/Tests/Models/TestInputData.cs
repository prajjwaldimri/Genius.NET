using Jil;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Tests.Models
{
    public class TestInputData
    {
        [JilDirective("artists")]
        public List<ulong> Artists { get; set; }

        [JilDirective("songs")]
        public List<ulong> Songs { get; set; }

        [JilDirective("searchQueries")]
        public List<string> SearchQueries { get; set; }

        [JilDirective("annotations")]
        public List<ulong> Annotations { get; set; }

        public static TestInputData GetFromJsonFile()
        {
            string executingAssembly = Assembly.GetExecutingAssembly().Location;
            string executingPath = Path.GetDirectoryName(executingAssembly);
            string jsonPath = Path.Combine(executingPath, "TestInputData.json");

            string jsonContent = File.ReadAllText(jsonPath);

            return JSON.Deserialize<TestInputData>(jsonContent);
        }
    }
}
