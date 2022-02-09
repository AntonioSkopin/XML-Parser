using System.Text.RegularExpressions;

namespace XmlParser.Helpers
{
    public static class SelectorService
    {
        public static string[] GetSelectors(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");
            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select m.Value;
            return words.ToArray();
        }

        public static string TrimSuffix(string word)
        {
            int aposthropheLocation = word.IndexOf('\'');
            if (aposthropheLocation != -1)
                word = word.Substring(0, aposthropheLocation);
            return word;
        }
    }
}
