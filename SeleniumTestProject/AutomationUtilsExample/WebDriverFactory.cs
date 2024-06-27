using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WebDriverFactory
{
    public IWebDriver Create(BrowserType browserType)
    {
        switch (browserType)
        {
            case BrowserType.Chrome:
                return new ChromeDriver();
            default:
                throw new ArgumentException("Unsupported browser type");
        }
    }
    public enum BrowserType
    {
        Chrome,
        Firefox,
        // Add more browser types as needed
    }
}