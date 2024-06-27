using OpenQA.Selenium;

public class RegistrationAndLoginPage : BasePage
{
    public RegistrationAndLoginPage(IWebDriver driver) : base(driver) { }

    //Elements
    public IWebElement Username => Driver.FindElement(By.XPath("//input[@type='email'][@data-qa='login-email']"));

    //Methods

    public void EnterUsername(string username)
    {
        Username.SendKeys(username);
        Driver.Close();
    }
}