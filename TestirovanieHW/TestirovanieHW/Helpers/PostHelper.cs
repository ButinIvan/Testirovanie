using OpenQA.Selenium;

namespace SeleniumTests;

public class PostHelper : HelperBase
{
    public PostHelper(AppManager manager)
        : base(manager)
    {
    }

    public void CreateReply(PostData post)
    {
        FillField(By.Id("message"), post.Message);
        driver.FindElement(By.Name("post")).Click();
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