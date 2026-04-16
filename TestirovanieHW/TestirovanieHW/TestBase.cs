using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests;

public class TestBase
{
    protected IWebDriver driver;
    protected string baseURL;

    [SetUp]
    public void SetupTest()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
        baseURL = "https://www.forum-phpbb.ru/";
    }

    [TearDown]
    public void TeardownTest()
    {
        try
        {
            driver.Quit();
            driver.Dispose();
        }
        catch (Exception)
        {
        }
    }

    public void OpenHomePage()
    {
        driver.Navigate().GoToUrl(baseURL);
    }

    public void OpenLoginPage()
    {
        driver.FindElement(By.LinkText("Вход")).Click();
    }

    public void FillField(By by, string text)
    {
        if (text != null)
        {
            driver.FindElement(by).Click();
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(text);
        }
    }

    public void Login(AccountData user)
    {
        FillField(By.Id("username"), user.Username);
        FillField(By.Id("password"), user.Password);
        driver.FindElement(By.Name("login")).Click();
    }
    
    public void OpenSection(string sectionName)
    {
        driver.FindElement(By.LinkText(sectionName)).Click();
    }

    public void OpenTopic(string topicName)
    {
        driver.FindElement(By.LinkText(topicName)).Click();
    }

    public void CreateReply(PostData post)
    {
        FillField(By.Id("message"), post.Message);
        driver.FindElement(By.Name("post")).Click();
    }
}