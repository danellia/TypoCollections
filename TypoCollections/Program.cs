using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TypoCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("философ", "фелософ");
            dict.Add("политический", "политичиский");
            dict.Add("чума", "чюма");
            dict.Add("почитаемый", "почетаемый");
            dict.Add("ранние", "рание");
            dict.Add("корреспондент", "кореспондент");
            dict.Add("участник", "учасник");
            dict.Add("экзистенциализм", "экзестенциализм");
            dict.Add("чувства", "чуства");

            string filepath = "/Volumes/Mac HDD/visualstudio/TypoCollections/TypoCollections/bin/Debug/netcoreapp3.1";

            var files = Directory.GetFiles(filepath);
            foreach (var file in files)
            {
                Console.WriteLine(file);
                foreach (KeyValuePair<string, string> entry in dict)
                {
                    Regex regex = new Regex(entry.Value);
                    MatchCollection matches = regex.Matches(entry.Value);
                    foreach (var match in matches)
                    {
                        Console.WriteLine(match);
                    }
                }
            }
        }
    }
}
