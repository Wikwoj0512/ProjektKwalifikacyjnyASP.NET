using System.Net;

namespace ProjektKwalifikacyjny.Models;

using static RegEx;

public class WebsiteModel
{
    public string url { get; set; }= null;
    private readonly string website = null;
    private string body = null;

    private List<string> content=null;
    public Dictionary<string, int> headerKeywords { get; } = null;

    public WebsiteModel(string url)
    {
        this.url = url;
        this.website = GetWebsiteContent();
        this.body = ExtractBody(website);
        headerKeywords = ExtractHeader(body);
        headerKeywords = CountKeywords(body, headerKeywords);
        
    }

    private string GetWebsiteContent()
    {
        /*
         * Get the content of the website
         */
        try
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            
            request.Method = "GET";
            
            using var webResponse = request.GetResponse();

            using var webStream = webResponse.GetResponseStream();
            
            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return data;
        }
        catch (WebException exception)
        {
            throw exception;
        }
    }
    
}