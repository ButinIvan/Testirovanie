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
        OpenReplyForm();
        FillField(By.Id("message"), post.Message);
        driver.FindElement(By.Name("post")).Click();
    }
    
    public void OpenReplyForm()
    {
        if (!IsElementPresent(By.Id("message")))
        {
            driver.FindElement(By.CssSelector("a[href*='posting.php?mode=reply']")).Click();
        }
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
    
    public void EditPost(PostData post)
    {
        driver.FindElement(By.XPath("//div[@id='post_content120']/ul/li/a/i")).Click();

        driver.FindElement(By.Id("message")).Clear();
        driver.FindElement(By.Id("message")).SendKeys(post.Message);

        driver.FindElement(By.Name("post")).Click();
    }
}