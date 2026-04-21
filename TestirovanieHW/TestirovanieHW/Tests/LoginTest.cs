namespace SeleniumTests;

[TestFixture]
public class LoginTest : TestBase
{
    [Test]
    public void TheLoginTest()
    {
        AccountData user = new AccountData("321ба", "P+hgL6!uABW8962");

        app.Navigation.OpenHomePage();
        app.Navigation.OpenLoginPage();
        app.Auth.Login(user);

        Assert.IsTrue(app.Driver.PageSource.Contains("Выход"));
    }
}