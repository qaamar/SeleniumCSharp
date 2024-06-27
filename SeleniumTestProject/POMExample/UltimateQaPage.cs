using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class UltimateQaPage : BasePage
{
    public UltimateQaPage(IWebDriver driver) : base(driver) { }

    public IWebElement HomePageLogo => Driver.FindElement(By.XPath("//*[@title='hero-image']"));

    public bool isVisible
    {
        get
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            return wait.Until(driver => HomePageLogo.Displayed);
        }
    }
}

