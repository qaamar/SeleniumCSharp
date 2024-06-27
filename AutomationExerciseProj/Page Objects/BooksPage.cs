
using OpenQA.Selenium;

namespace AutomationExerciseProj;

public class BooksPage : BasePage
{
    public BooksPage(IWebDriver driver) : base(driver)
    {
    }
    //Locators
    private IWebElement BookStoreLogin => Driver.FindElement(By.XPath("//span[contains(text(),'Login')]"));
    private IWebElement LoginBtn => Driver.FindElement(By.XPath("//button[@id='login']"));

    //Methods

    public void ClickOnLoginInBookstoreMenu()
    {
        BookStoreLogin.Click();
    }
    public void ClickOnLogin()
    {
        LoginBtn.Click();
    }
}