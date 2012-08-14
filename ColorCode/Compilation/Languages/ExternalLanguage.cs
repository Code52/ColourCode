using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ColorCode.Compilation.Languages
{
    public class ExternalLanguage : ILanguage
    {
        public ExternalLanguage(FileInfo file)
        {
            string contents = "";
            using (var reader = new StreamReader(file.OpenRead()))
            {
                contents = reader.ReadToEnd();
            }

            Parse(contents);
        }

        public ExternalLanguage(string filecontents)
        {
            Parse(filecontents);
        }

        private void Parse(string contents)
        {
            var data = JObject.Parse(contents);
            Id = (string)data["id"];
            Name = (string)data["Name"];
            CssClassName = (string)data["CssClassName"];
            FirstLinePattern = (string)data["FirstLinePattern"];

            var rules = new List<LanguageRule>();
            foreach (var r in data["Rules"])
            {
                var captures = new Dictionary<int, string>();
                foreach (var c in r["Captures"])
                {
                    captures.Add((int)c["index"], (string)c["name"]);
                }

                rules.Add(new LanguageRule((string)r["Regex"], captures));
            }

            Rules = rules;
        }

        public string Id { get; private set; }
        public string FirstLinePattern { get; private set; }
        public string Name { get; private set; }
        public IList<LanguageRule> Rules { get; private set; }
        public string CssClassName { get; private set; }
    }
}