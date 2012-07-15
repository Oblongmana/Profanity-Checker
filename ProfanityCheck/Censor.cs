using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfanityCheck
{
    //Adapted roughly from http://james.newtonking.com/archive/2009/07/03/simple-net-profanity-filter.aspx
    public class Censor
    {
        public IList<string> CensoredWords { get; private set; }

        public Censor(IEnumerable<string> censoredWords)
        {
            if (censoredWords == null)
                throw new ArgumentNullException("censoredWords");

            CensoredWords = new List<string>(censoredWords);
        }

        public bool ContainsProfanity(string text, ref string theProfanity)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            string censoredText = text;
            bool isMatch = false;

            foreach (string censoredWord in CensoredWords)
            {
                string regularExpression = ToRegexPattern(censoredWord);

                Match profanityMatch = Regex.Match(censoredText, regularExpression, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                isMatch = profanityMatch.Success;

                if (isMatch)
                {
                    theProfanity = profanityMatch.Value;
                    break;
                }
            }

            return isMatch;
        }

        private static string StarCensoredMatch(Match m)
        {
            string word = m.Captures[0].Value;

            return new string('*', word.Length);
        }

        private string ToRegexPattern(string wildcardSearch)
        {
            string regexPattern = Regex.Escape(wildcardSearch);

            regexPattern = regexPattern.Replace(@"\*", ".*?");
            regexPattern = regexPattern.Replace(@"\?", ".");

            if (regexPattern.StartsWith(".*?"))
            {
                regexPattern = regexPattern.Substring(3);
                regexPattern = @"(^\b)*?" + regexPattern;
            }

            regexPattern = @"\b" + regexPattern + @"\b";

            return regexPattern;
        }
    }
}
