using System.Xml.Serialization;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests;

[TestFixture]
public class CreatePostTest : AuthBase
{
    public static IEnumerable<PostData> PostDataFromXmlFile()
    {
        return (List<PostData>)new XmlSerializer(typeof(List<PostData>))
            .Deserialize(new StreamReader("posts.xml"))!;
    }

    [Test, TestCaseSource(nameof(PostDataFromXmlFile))]
    public void TheCreatePostTest(PostData post)
    {
        app.Navigation.OpenSection("Спорт");
        app.Navigation.OpenTopic("Лига Чемпионов 2025/2026");
        
        Thread.Sleep(15000);
        
        app.Post.CreateReply(post);
        
        WebDriverWait wait = new WebDriverWait(app.Driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.PageSource.Contains(post.Message));

        Assert.That(app.Driver.PageSource.Contains(post.Message), Is.EqualTo(true));
    }
}