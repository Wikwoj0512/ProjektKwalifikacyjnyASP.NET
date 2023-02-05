using System.Text.RegularExpressions;

namespace ProjektKwalifikacyjny.Models;

public class RegEx
{
    private const string bodyPattern = @"<body.*?>(.*?)</body>";
    private const string headerPattern = @"<h1.*?>(.*?)</h1>";
    private const string headerContentPattern = @"(<[^>]*>){0,1}([^<]*)";
    private const string contentPattern = @"<(?!script|title|style)[^>]*>([^<]*)";
    private const string wordsPattern = @"[a-zóąłęńść0-9]{2,}";

    public static string ExtractBody(string website)
    {
        /*
         * Match the body tag and extract the content between the opening and closing tag
         */
        var body = Regex.Match(website, bodyPattern, RegexOptions.Singleline).Groups[1].Value;
        return body.ToLower();
    }

    public static List<string> ExtractHeaderKeywords(string body)
    {
        /*
         * Match the header tag and extract all the words between the opening and closing tag
         */
        var header = Regex.Match(body, headerPattern, RegexOptions.Singleline).Groups[1].Value;
        var headerKeywords = new List<string>();
        foreach (Match match in Regex.Matches(header, headerContentPattern))
        {
            foreach (Match wordMatch in Regex.Matches(match.Groups[2].Value, wordsPattern))
            {
                headerKeywords.Add(wordMatch.Value);
            }
        }

        return headerKeywords;
    }

    public static Dictionary<string, int> ExtractHeader(string body)
    {
        /*
         * Extract all the words from the header and add them to a dictionary
         */
        
        Dictionary<string, int> keywords = new Dictionary<string, int>();
        foreach (string keyword in ExtractHeaderKeywords(body))
        {
            keywords.Add(keyword, 0);
        }

        return keywords;
    }

    public static Dictionary<string, int> CountKeywords(string body, Dictionary<string, int> keywords)
    {
        /*
         * Extract all the words from the content and add them to a dictionary
         */
        
        foreach (Match match in Regex.Matches(body, contentPattern, RegexOptions.Singleline))
        {
            foreach (Match wordMatch in Regex.Matches(match.Groups[1].Value, wordsPattern))
            {
                if (keywords.ContainsKey(wordMatch.Value))
                {
                    keywords[wordMatch.Value]++;
                }
            }
        }

        return keywords;
    }
}