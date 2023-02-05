namespace Tests;

public class UnitTestRegEx
{
    [Test]
    public void TestBody()
    {
        string body = "<body class = 'body-content'><h>Hello World</h></body>";
        Assert.AreEqual("<h>hello world</h>", RegEx.ExtractBody(body));
    }

    [Test]
    public void TestHeader()
    {
        string body = "<body class = 'body-content'><h1>hello world</h1></body>";
        Dictionary<string, int> expected = new Dictionary<string, int>() { { "hello", 0 }, { "world", 0 } };
        Assert.AreEqual(expected, RegEx.ExtractHeader(body));
        body = "<body class = 'body-content'><h1><span>hello world</span></h1></body>";
        Assert.AreEqual(expected, RegEx.ExtractHeader(body));
    }

    [Test]
    public void TestCountKeywords()
    {
        string body =
            "<body class = 'body-content'><h1>hello world</h1> <a>hello</a><script>world</script>hello</body>";
        Dictionary<string, int>headerKeywords = new Dictionary<string, int>() { { "hello", 0 }, { "world", 0 } };
        Dictionary<string, int> expected = new Dictionary<string, int>() { { "hello", 3 }, { "world", 1 } };
        Assert.AreEqual(expected, RegEx.CountKeywords(body, headerKeywords));
    }
}