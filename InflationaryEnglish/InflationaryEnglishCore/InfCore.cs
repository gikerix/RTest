using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace InflationaryEnglishCore
{    
    public class PhraseConverter
    {
        //I understand tht using ditionary is overhead because we don't need
        //to get value ny key but i don't have a time for elegant solution
        private Dictionary<string, string> dict;

        public PhraseConverter()
        {
            dict = new Dictionary<string, string>();
            dict.Add("(g|t)en", "eleven");
            dict.Add("(g|n)(ine|ign)", "ten");
            dict.Add("((g|e)ight)|((a)te)", "nine");
            dict.Add("(g|s)even", "eight");
            dict.Add("(g|s)ix", "seven");
            dict.Add("(g|f)ive", "six");
            dict.Add("(g|f)(our|ore|or)", "five");
            dict.Add("(g|t)hree", "four");
            dict.Add("(g|t)(oo|wo|o)", "three");
            dict.Add("((g|o)ne)|[w]on", "two");
            dict.Add("(g|o)nce", "twice");
        }

        public string Convert(string input)
        {            
            var words = input.Split(' ');
            var sb = new StringBuilder();            
            for (int i = 0; i < words.Length; ++i)
            {
                var word = words[i];
                bool found = false;
                foreach (var pair in dict)
                {
                    var lWord = word.ToLower();
                    string result = Regex.Replace(lWord, pair.Key, pair.Value);                    
                    if (result != word.ToLower())
                    {
                        if (word == lWord)
                            sb.Append(i == 0 ? result : " " + result);
                        else
                            sb.Append(i == 0 ? char.ToUpper(result[0]) + result.Substring(1) : " " + char.ToUpper(result[0]) + result.Substring(1));
                        found = true;
                        break;
                    }
                }
                if (!found)
                    sb.Append(i == 0 ? word : " " + word);
            }
            return sb.ToString();
        }
    }
}
