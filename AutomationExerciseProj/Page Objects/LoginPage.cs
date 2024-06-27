using OpenQA.Selenium;

namespace AutomationExerciseProj;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }
    private IWebElement UsernameField => Driver.FindElement(By.XPath("//*[@data-qa='login-email']"));
    private IWebElement PasswordField => Driver.FindElement(By.XPath("//*[@data-qa='login-password']"));
    private IWebElement LoginButton => Driver.FindElement(By.XPath("//*[@data-qa='login-button']"));
    private IWebElement NewUserBtn => Driver.FindElement(By.Id("newUser"));

    private IWebElement LoginForm => Driver.FindElement(By.XPath("//*[@class='login-form']"));

    public RegisterPage ClickNewUser()
    {
        NewUserBtn.Click();
        return new RegisterPage(Driver);
    }

    public void LoginUser(string username, string password)
    {
        EnterTextIntoField(UsernameField, username);
        EnterTextIntoField(PasswordField, password);
        LoginButton.Click();
    }


    public void VerifyErrorMessageForInvalidLogin()
    {
        var loginError = "Your email or password is incorrect!";
        Assert.Contains(loginError, LoginForm.Text);
    }
}