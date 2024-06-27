using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;

public class SampleApplicationPage : BasePage
{

    public SampleApplicationPage(IWebDriver driver) : base(driver) { } //koristenje base pagea 

    //Locators
    public IWebElement FirstName => Driver.FindElement(By.XPath("//*[@name='firstname']"));
    public IWebElement SubmittButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
    public IWebElement SubmittButton2 => Driver.FindElement(By.Id("submit2"));
    public IWebElement MainTitle => Driver.FindElement(By.XPath("//*[@class='entry-title main_title']"));

    public IWebElement LastName => Driver.FindElement(By.Name("lastname"));

    public IWebElement FirstNameEmergency => Driver.FindElement(By.Id("f2"));
    public IWebElement LastNameEmergency => Driver.FindElement(By.Id("l2"));

    public UltimateQaPage FillOutFormAndSubmit(TestUser testUser)
    {
        FirstName.SendKeys(testUser.FirstName);
        LastName.SendKeys(testUser.LastName);
        SubmittButton.Click();
        return new UltimateQaPage(Driver);
    }

    public void GoTo()
    {
        var url = "https://ultimateqa.com/sample-application-lifecycle-sprint-3";
        Driver.Navigate().GoToUrl(url);
    }

    public bool isVisible()
    {
        try
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            return wait.Until(driver => MainTitle.Displayed);

        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public void SelectRadioButtonRegularForm(TestUser testUser)
    {
        switch (testUser.GenderType)
        {
            case Gender.Male:
                Driver.FindElement(By.XPath("//*[@value='male']")).Click();
                break;
            case Gender.Female:
                Driver.FindElement(By.XPath("//*[@value='female']")).Click();
                break;
            case Gender.Other:
                Driver.FindElement(By.XPath("//*[@value='other']")).Click();
                break;
            default:
                break;
        }
    }
    public void SelectRadioButtonEmergencyForm(TestUser testUser)
    {
        switch (testUser.GenderTypeEmergency)
        {
            case EmergencyGender.Male:
                Driver.FindElement(By.XPath("//*[@id='radio2-m'][@value='male']")).Click();
                break;
            case EmergencyGender.Female:
                Driver.FindElement(By.XPath("//*[@id='radio2-f'][@value='female']")).Click();
                break;
            case EmergencyGender.Other:
                Driver.FindElement(By.XPath("//*[@id='radio2s-f'][@value='female']")).Click();
                break;
            default:
                break;
        }
    }

    public void GoToEmergencyForm()
    {
        Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-4");

    }

    public UltimateQaPage FillOutFormAndSubmitEmergencyForm(TestUser testUser)
    {
        FirstNameEmergency.SendKeys(testUser.FirstName);
        LastNameEmergency.SendKeys(testUser.LastName);
        SubmittButton2.Click();
        return new UltimateQaPage(Driver);
    }
    
}
