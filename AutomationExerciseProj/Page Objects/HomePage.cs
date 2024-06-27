using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseProj;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver) { }



    //locators
    private IWebElement NavigationBar => Driver.FindElement(By.XPath("//ul[@class='nav navbar-nav']"));
    private IWebElement RegisterAndLoginBtn => Driver.FindElement(By.XPath("//a[@href='/login']"));
    private IWebElement DeleteAccountBtn => Driver.FindElement(By.XPath("//a[@href='/delete_account']"));
    private IWebElement LoggedInLabel => Driver.FindElement(By.XPath("//*[contains(text(),' Logged in as ')]"));
    private IWebElement DeletedAccountTitle => Driver.FindElement(By.XPath("//*[@data-qa='account-deleted']"));
    public IWebElement LogOutButton => Driver.FindElement(By.XPath("//a[@href='/logout']"));


    //methods

    public void ClickOnLogin()
    {
        RegisterAndLoginBtn.Click();
    }

    public void DeleteAccount()
    {
        DeleteAccountBtn.Click();
    }

    public void VerifyAccountDeleted()
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        wait.Until(Driver => DeletedAccountTitle.Displayed);
        var title = DeletedAccountTitle.Text;
        Assert.Equal("ACCOUNT DELETED!", title);
    }

    public void VerifyUserIsLoggedIn(string username)
    {
        Assert.Contains(username, LoggedInLabel.Text);
    }

    public void LogOut()
    {
        LogOutButton.Click();
    }

    public void VerifyUserIsLoggedOut(string username)
    {
        string text = NavigationBar.Text;
        Assert.DoesNotContain(username, text);
    }
}