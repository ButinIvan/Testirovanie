namespace SeleniumTests;

[TestFixture]
public class LoginTest : TestBase
{
    [Test]
    public void TheLoginTest()
    {
        AccountData user = new AccountData("321ба", "P+hgL6!uABW8962");

        OpenHomePage();
        OpenLoginPage();
        Login(user);

        Assert.IsTrue(driver.PageSource.Contains("Выход"));
    }
}