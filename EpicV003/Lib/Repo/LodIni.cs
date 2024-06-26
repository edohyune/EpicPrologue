using DevExpress.Office.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicV003.Lib.Repo
{
    public class LodIni : MdlBase
    {
        private string _Section;
        public string Section
        {
            get => _Section;
            set => Set(ref _Section, value);
        }
        private string _Key;
        public string Key
        {
            get => _Key;
            set => Set(ref _Key, value);
        }
        private string _Value;
        public string Value
        {
            get => _Value;
            set => Set(ref _Value, value);
        }
    }

    public class LodIniRepo
    {
        private readonly string iniFilePath;

        public LodIniRepo(string iniFilePath)
        {
            this.iniFilePath = iniFilePath;
        }

        public List<LodIni> LoadAll()
        {
            var lodInis = new List<LodIni>();
            if (File.Exists(iniFilePath))
            {
                var lines = File.ReadAllLines(iniFilePath);
                string currentSection = string.Empty;

                foreach (var line in lines)
                {
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        currentSection = line.Trim('[', ']');
                    }
                    else
                    {
                        var keyValue = line.Split(new char[] { '=' }, 2);
                        if (keyValue.Length == 2)
                        {
                            lodInis.Add(new LodIni
                            {
                                Section = currentSection,
                                Key = keyValue[0].Trim(),
                                Value = keyValue[1].Trim()
                            });
                        }
                    }
                }
            }

            return lodInis;
        }

        public void SaveAll(List<LodIni> lodInis)
        {
            var sections = lodInis.GroupBy(li => li.Section)
                                  .ToDictionary(g => g.Key, g => g.ToList());

            using (var writer = new StreamWriter(iniFilePath))
            {
                foreach (var section in sections)
                {
                    writer.WriteLine($"[{section.Key}]");
                    foreach (var item in section.Value)
                    {
                        writer.WriteLine($"{item.Key}={item.Value}");
                    }
                }
            }
        }
    }


}
