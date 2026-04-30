using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests;

public class TestBase
{
    protected AppManager app;

    [SetUp]
    public void SetupTest()
    {
        app = AppManager.GetInstance();
        app.Navigation.OpenHomePage();
    }
}