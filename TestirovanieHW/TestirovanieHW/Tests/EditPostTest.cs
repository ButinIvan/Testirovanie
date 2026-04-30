using OpenQA.Selenium.Support.UI;

namespace SeleniumTests;

[TestFixture]
public class EditPostTest : AuthBase
{
    [Test]
    public void TheEditPostTest()
    {
        PostData editedPost = new PostData("Как думаете кто выиграет ЛЧ в этом году? Я думаю псж");

        app.Navigation.OpenSection("Спорт");
        app.Navigation.OpenTopic("Лига Чемпионов 2025/2026");

        app.Post.EditPost(editedPost);
        
        WebDriverWait wait = new WebDriverWait(app.Driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.PageSource.Contains(editedPost.Message));

        Assert.IsTrue(app.Driver.PageSource.Contains(editedPost.Message));
    }
}