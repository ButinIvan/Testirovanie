using OpenQA.Selenium;

namespace SeleniumTests;

public class LoginHelper : HelperBase
{
    public LoginHelper(AppManager manager)
        : base(manager)
    {
    }

    public void Login(AccountData user)
    {
        FillField(By.Id("username"), user.Username);
        FillField(By.Id("password"), user.Password);
        driver.FindElement(By.Name("login")).Click();
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
}