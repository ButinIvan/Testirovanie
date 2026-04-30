namespace SeleniumTests;

[TestFixture]
public class LoginTest : TestBase
{
    [Test]
    public void LoginWithValidData()
    {
        app.Auth.Logout();

        AccountData user = new AccountData(Settings.Login, Settings.Password);
        app.Auth.Login(user);

        Assert.IsTrue(app.Auth.IsLoggedIn(user.Username));
    }

    [Test]
    public void LoginWithInvalidData()
    {
        app.Auth.Logout();
    
        AccountData user = new AccountData(Settings.Login, "wrong_password");
        app.Auth.Login(user);

        Assert.IsFalse(app.Auth.IsLoggedIn());
    }
}