using OpenQA.Selenium;

namespace SeleniumTests;

public class NavigationHelper : HelperBase
{
    private string baseURL;

    public NavigationHelper(AppManager manager, string baseURL)
        : base(manager)
    {
        this.baseURL = baseURL;
    }

    public void OpenHomePage()
    {
        driver.Navigate().GoToUrl(baseURL);
    }

    public void OpenLoginPage()
    {
        if (IsElementPresent(By.CssSelector("a[href*='ucp.php?mode=login']")))
        {
            driver.FindElement(By.CssSelector("a[href*='ucp.php?mode=login']")).Click();
        }
    }

    public void OpenSection(string sectionName)
    {
        driver.FindElement(By.LinkText(sectionName)).Click();
    }

    public void OpenTopic(string topicName)
    {
        driver.FindElement(By.LinkText(topicName)).Click();
    }
}