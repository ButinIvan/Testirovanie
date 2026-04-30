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
        if (IsLoggedIn())
        {
            if (IsLoggedIn(user.Username))
            {
                return;
            }

            Logout();
        }

        manager.Navigation.OpenLoginPage();
        
        FillField(By.Id("username"), user.Username);
        FillField(By.Id("password"), user.Password);
        driver.FindElement(By.Name("login")).Click();
    }

    public void Logout()
    {
        if (!IsLoggedIn())
        {
            return;
        }

        driver.FindElement(By.CssSelector("a[href*='mode=logout']")).Click();
    }

    public bool IsLoggedIn()
    {
        return IsElementPresent(By.CssSelector("a[href*='mode=logout']"));
    }

    public bool IsLoggedIn(string username)
    {
        return IsLoggedIn() && driver.PageSource.Contains(username);
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