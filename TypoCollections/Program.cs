using System;
using System.Collections.Generic;
using System.IO;
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
            string fileText = "";
            string findNumber = @".012.";
            string replaceNumber = "+380 12";

            var files = Directory.GetFiles(filepath);
            foreach (var file in files)
            {
                Console.WriteLine(file);
                
                using (StreamReader sr = File.OpenText(file))
                {
                    fileText = sr.ReadToEnd();
                }

                foreach (KeyValuePair<string, string> entry in dict)
                {
                    fileText = fileText.Replace(entry.Value, entry.Key);
                    Regex regex = new Regex(findNumber);
                    MatchCollection matches = regex.Matches(fileText);
                    fileText = regex.Replace(fileText, replaceNumber, 10);

                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        sw.Write(fileText);
                    }
                }
            }
        }
    }
}
