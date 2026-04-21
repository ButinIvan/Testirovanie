using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests;

[TestFixture]
public class CreatePostTest : TestBase
{
    [Test]
    public void TheCreatePostTest()
    {
        AccountData user = new AccountData("321ба", "P+hgL6!uABW8962");
        PostData post = new PostData("Я думаю выиграет Бавария");

        app.Navigation.OpenHomePage();
        app.Navigation.OpenLoginPage();
        app.Auth.Login(user);

        app.Navigation.OpenSection("Спорт");
        app.Navigation.OpenTopic("Лига Чемпионов 2025/2026");
        app.Post.CreateReply(post);
        
        WebDriverWait wait = new WebDriverWait(app.Driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.PageSource.Contains(post.Message));

        Assert.That(app.Driver.PageSource.Contains(post.Message), Is.EqualTo(true));
    }
}