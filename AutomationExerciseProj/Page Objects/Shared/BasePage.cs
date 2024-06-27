using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseProj;

public class BasePage
{
    protected IWebDriver Driver { get; set; }


    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }


    public void Click(IWebElement element)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        try
        {
            wait.Until(driver =>
            {
                try
                {
                    return element.Displayed && element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            });

            element.Click();
        }
        catch (ElementClickInterceptedException)
        {
            // Scroll to the bottom of the page and try again
            ScrollToBottom();
            wait.Until(driver => element.Displayed && element.Enabled);
            element.Click();
        }
    }
    public void ScrollToBottom()
    {
        ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
    }
    
    public void ScrollToTop()
    {
        ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, 0);");
    }

    public void EnterTextIntoField(IWebElement element, string text)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        wait.Until(driver =>
        {
            try
            {
                return element.Displayed && element.Enabled;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        });
        element.Clear();
        element.SendKeys(text);
    }

}
