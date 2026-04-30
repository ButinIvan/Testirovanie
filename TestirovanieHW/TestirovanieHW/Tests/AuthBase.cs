namespace SeleniumTests;

public class AuthBase : TestBase
{
    [SetUp]
    public void SetupAuth()
    {
        AccountData user = new AccountData(Settings.Login, Settings.Password);
        app.Auth.Login(user);
    }
}