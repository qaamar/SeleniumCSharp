using System.Globalization;
using System.Text.Json;
using Bogus;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.VirtualAuth;

namespace AutomationExerciseProj;

public class LoginAndRegisterUserTests : BaseTest
{


    [Fact]
    public void RegisterUserTest()
    {

        Assert.Equal("https://automationexercise.com/", Driver.Url);
        new HomePage(Driver).ClickOnLogin();

        new RegisterPage(Driver).VerifySignupTitle();
        string username = new Faker("en").Internet.UserName();
        string email = new Faker("en").Internet.Email();
        new RegisterPage(Driver).EnterNameAndEmail(username, email);
        new RegisterPage(Driver).ClickSignup();

        new RegisterPage(Driver).VerifyEnterAccountInfo();
        TestUser accountInformation = new TestUser { Password = "test123", DateOfBirth = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day) };
        new RegisterPage(Driver).FillAccountInformation(accountInformation);
        new RegisterPage(Driver).SelectNewsletter();
        new RegisterPage(Driver).SelectOffers();

        TestUser addressInformation = new TestUser { FirstName = new Faker("en").Name.FirstName(), LastName = new Faker("en").Name.LastName(), Company = new Faker("en").Company.CompanyName(), Address = new Faker("en").Address.StreetAddress(), Address2 = new Faker("en").Address.SecondaryAddress(), Country = CountryEnum.Australia, State = new Faker("en").Address.State(), City = new Faker("en").Address.City(), ZipCode = new Faker("en").Address.ZipCode(), MobileNumber = new Faker("en").Phone.PhoneNumber() };
        new RegisterPage(Driver).FillAddressInformation(addressInformation);
        new RegisterPage(Driver).ClickCreateAccount();
        new RegisterPage(Driver).VerifyAccountCreated();
        new RegisterPage(Driver).ClickContinue();

        new HomePage(Driver).VerifyUserIsLoggedIn(username);
        new HomePage(Driver).DeleteAccount();
        new HomePage(Driver).VerifyAccountDeleted();

    }

    [Fact]
    public void LoginUserTest()
    {
       // Assert.Equal("https://automationexercise.com/", Driver.Url);
        new HomePage(Driver).ClickOnLogin();
        var username = "admin@1secmail.com";
        var password = "Test123!";
        new LoginPage(Driver).LoginUser(username, password);
        new HomePage(Driver).VerifyUserIsLoggedIn("test_admin");
    }

    [Fact]
    public void InvalidUserLogin()
    {
        Assert.Equal("https://automationexercise.com/", Driver.Url);
        new HomePage(Driver).ClickOnLogin();
        var invalidUsername = "invalid@1secmail.com";
        var password = "Test123!";
        new LoginPage(Driver).LoginUser(invalidUsername, password);
        new LoginPage(Driver).VerifyErrorMessageForInvalidLogin();

        var validUsername = "admin@1secmail.com";
        var invalidPassword = "invalidPassword";
        new LoginPage(Driver).LoginUser(validUsername, invalidPassword);
        new LoginPage(Driver).VerifyErrorMessageForInvalidLogin();
    }
    [Fact]
    public void LogOutUserTest()
    {
        new HomePage(Driver).ClickOnLogin();
        var username = "admin@1secmail.com";
        var password = "Test123!";
        new LoginPage(Driver).LoginUser(username, password);
        new HomePage(Driver).VerifyUserIsLoggedIn("test_admin");
        new HomePage(Driver).LogOut();
        new HomePage(Driver).VerifyUserIsLoggedOut(username);
    }
    


}