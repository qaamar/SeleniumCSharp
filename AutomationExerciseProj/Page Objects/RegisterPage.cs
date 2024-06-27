using System.IO.Compression;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseProj;

public class RegisterPage : BasePage
{
    public RegisterPage(IWebDriver driver) : base(driver)
    {
    }

    private IWebElement UsernameField => Driver.FindElement(By.XPath("//*[@data-qa='signup-name']"));
    private IWebElement EmailField => Driver.FindElement(By.XPath("//*[@data-qa='signup-email']"));
    private IWebElement SignupForm => Driver.FindElement(By.XPath("//*[@class='signup-form']"));
    private IWebElement SignupButton => Driver.FindElement(By.XPath("//*[@data-qa='signup-button']"));
    private IWebElement RegistrationTitle => Driver.FindElement(By.XPath("//*[@class='login-form']/*[@class='title text-center']"));
    // Account Information fields
    private IWebElement PasswordField => Driver.FindElement(By.Id("password"));
    private IWebElement NewsletterCheckbox => Driver.FindElement(By.Id("newsletter"));
    private IWebElement SpecialOfferCheckbox => Driver.FindElement(By.Id("optin"));
    private IWebElement CreateAccountButton => Driver.FindElement(By.XPath("//*[@data-qa='create-account']"));
    private IWebElement DobDay => Driver.FindElement(By.Id("days"));
    private IWebElement DobMonth => Driver.FindElement(By.Id("months"));
    private IWebElement DobYear => Driver.FindElement(By.Id("years"));

    // Address information fields
    private IWebElement FirstNameField => Driver.FindElement(By.Id("first_name"));
    private IWebElement LastNameField => Driver.FindElement(By.Id("last_name"));
    private IWebElement CompanyField => Driver.FindElement(By.Id("company"));
    private IWebElement AddressField => Driver.FindElement(By.Id("address1"));
    private IWebElement Address2Field => Driver.FindElement(By.Id("address2"));
    private IWebElement CountryField => Driver.FindElement(By.Id("country"));
    private IWebElement StateField => Driver.FindElement(By.Id("state"));
    private IWebElement CityField => Driver.FindElement(By.Id("city"));
    private IWebElement ZipCodeField => Driver.FindElement(By.Id("zipcode"));
    private IWebElement MobileField => Driver.FindElement(By.Id("mobile_number"));

    public IWebElement ContinueButton  => Driver.FindElement(By.XPath("//*[@data-qa='continue-button']"));
    public IWebElement AccountCreated => Driver.FindElement(By.XPath("//*[@data-qa='account-created']"));

    public void EnterNameAndEmail(string name, string email)
    {
        EnterTextIntoField(UsernameField, name);
        EnterTextIntoField(EmailField, email);
    }

    public void VerifySignupTitle()
    {
        var title = SignupForm.Text;
        var formatedTitle = Regex.Replace(title, @"\nSignup", string.Empty);
        var expectedTitle = "New User Signup!";
        Assert.Equal(expectedTitle, formatedTitle);
    }

    public void ClickSignup()
    {
        SignupButton.Click();
    }

    public void VerifyEnterAccountInfo()
    {
        var title = RegistrationTitle.Text;
        Assert.Equal("ENTER ACCOUNT INFORMATION", title);
    }

    public void FillAccountInformation(TestUser testUser)
    {
        EnterTextIntoField(PasswordField, testUser.Password);
        SelectDate(testUser.DateOfBirth);
    }

    public void FillAddressInformation(TestUser testUser)
    {
        EnterTextIntoField(FirstNameField, testUser.FirstName);
        EnterTextIntoField(LastNameField, testUser.LastName);
        EnterTextIntoField(CompanyField, testUser.Company);
        EnterTextIntoField(AddressField, testUser.Address);
        EnterTextIntoField(Address2Field, testUser.Address2);
        SelectCountry(testUser);
        EnterTextIntoField(StateField, testUser.State);
        EnterTextIntoField(CityField, testUser.City);
        EnterTextIntoField(ZipCodeField, testUser.ZipCode);
        EnterTextIntoField(MobileField, testUser.MobileNumber);
    }

    public void SelectNewsletter()
    {
        NewsletterCheckbox.Click();
    }

    public void SelectOffers()
    {
        SpecialOfferCheckbox.Click();
    }

    public void ClickCreateAccount()
    {
        CreateAccountButton.Click();
    }

        public void VerifyAccountCreated()
    {
         var title = AccountCreated.Text;
        Assert.Equal("ACCOUNT CREATED!", title);
    }

    public void ClickContinue()
    {
        ContinueButton.Click();
    }
    private void SelectCountry(TestUser testUser)
    {

        switch (testUser.Country)
        {
            case CountryEnum.Australia:
                SelectElement countrySelect = new SelectElement(CountryField);
                countrySelect.SelectByText("Australia");
                break;
            case CountryEnum.Canada:
                SelectElement countrySelect2 = new SelectElement(Driver.FindElement(By.Id("id_country")));
                countrySelect2.SelectByText("Canada");
                break;

            case CountryEnum.India:
                SelectElement countrySelect3 = new SelectElement(Driver.FindElement(By.Id("id_country")));
                countrySelect3.SelectByText("India");
                break;

            case CountryEnum.NewZealand:
                SelectElement countrySelect4 = new SelectElement(Driver.FindElement(By.Id("id_country")));
                countrySelect4.SelectByText("New Zealand");
                break;

            case CountryEnum.Singapore:
                SelectElement countrySelect5 = new SelectElement(Driver.FindElement(By.Id("id_country")));
                countrySelect5.SelectByText("Singapore");
                break;

            case CountryEnum.UnitedKingdom:
                SelectElement countrySelect6 = new SelectElement(Driver.FindElement(By.Id("id_country")));
                countrySelect6.SelectByText("United Kingdom");
                break;
            case CountryEnum.UnitedStates:
                SelectElement countrySelect7 = new SelectElement(Driver.FindElement(By.Id("id_country")));
                countrySelect7.SelectByText("United States");
                break;
            default:
                break;
        }

    }


    private void SelectDate(DateTime date)
    {
        // Select Day
        SelectElement daySelect = new SelectElement(DobDay);
        daySelect.SelectByValue(date.Day.ToString());

        // Select Month
        SelectElement monthSelect = new SelectElement(DobMonth);
        monthSelect.SelectByValue(date.Month.ToString());

        // Select Year
        SelectElement yearSelect = new SelectElement(DobYear);
        yearSelect.SelectByValue(date.Year.ToString());
    }


}