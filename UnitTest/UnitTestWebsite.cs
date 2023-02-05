namespace Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        WebsiteModel websiteModel = new WebsiteModel("https://www.google.com");
        Assert.AreEqual("https://www.google.com", websiteModel.url);
        Assert.AreEqual(0, websiteModel.headerKeywords.Keys.Count);
    }

    [Test]
    public void Test2()
    {
        WebsiteModel websiteModel =
            new WebsiteModel(
                "https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer");
        Assert.Greater(websiteModel.headerKeywords.Keys.Count, 0);

        var keywords = new List<string>()
        {
            "how", "to", "initialize", "objects", "by", "using", "an", "object","initializer", "programming", "guide"
        };
        Assert.AreEqual(keywords, websiteModel.headerKeywords.Keys);
    }
}