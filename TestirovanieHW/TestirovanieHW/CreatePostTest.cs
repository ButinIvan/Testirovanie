using OpenQA.Selenium;

namespace SeleniumTests;

[TestFixture]
public class CreatePostTest : TestBase
{
    [Test]
    public void TheCreatePostTest()
    {
        AccountData user = new AccountData("321ба", "P+hgL6!uABW8962");
        PostData post = new PostData("Я думаю выиграет Бавария");

        OpenHomePage();
        OpenLoginPage();
        Login(user);

        OpenSection("Спорт");
        OpenTopic("Лига Чемпионов 2025/2026");
        CreateReply(post);

        Assert.That(driver.PageSource.Contains(post.Message), Is.EqualTo(true));
    }
}