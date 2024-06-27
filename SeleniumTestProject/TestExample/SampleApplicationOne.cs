using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static WebDriverFactory;




namespace SeleniumTestProject;

public class SampleApplicationOne : BaseTestExample
{

    [Fact]
    public void TestMethod()
    {
        LogInfo("Starting TestMethod");

        // Example test steps
        Driver.Navigate().GoToUrl("https://www.example.com");
        LogInfo("Navigated to example.com");

        // Assert something
        Assert.Equal("Example Domain", Driver.Title);
        LogInfo("Title assertion passed");

        // You can use other logging levels as needed
        LogDebug("Debugging info");
        LogWarning("This is a warning");
        LogError("This is an error message");
    }
    [Fact]
    [Trait("Category", "Sprint 2")]
    public void SubmitFirstNameTests()
    {

        SetTestName("SubmitFirstNameTests");
        TestUser testUser = new TestUser
        {
            FirstName = "Amar",
            LastName = "Lastname"
        };
        var sampleApplicationPage = new SampleApplicationPage(Driver);
        sampleApplicationPage.GoTo();
        LogInfo("User navigated to SampleApplicationPage");
        Assert.True(sampleApplicationPage.isVisible(), "SampleApplicationPage is not visible");
        LogInfo("SampleApplicationPage is visible");
        var ultimateQaPage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
        LogInfo("User filled form and submitted");
        Assert.True(ultimateQaPage.isVisible, "UltimateQaPage is not visible");
        LogInfo("Ultimate QA page is visible");

    }

    [Fact]
    [Trait("Category", "Sprint 2")]
    public void SecondTryTests() //only sprint 2
    {
        SetTestName("SecondTryTests");
        TestUser testUser = new TestUser();
        testUser.FirstName = "Amar";
        testUser.LastName = "Lastname";
        testUser.Gender = Gender.Female;

        var sampleApplicationPage = new SampleApplicationPage(Driver);
        sampleApplicationPage.GoTo();
        Assert.True(!sampleApplicationPage.isVisible());
        var ultimateQaPage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
        Assert.True(ultimateQaPage.isVisible);

    }
    [Fact]
    [Trait("Category", "Sprint 3")]
    public void ThirdTryTests() //only sprint 3 working
    {
        TestUser testUser = new TestUser
        {
            FirstName = "Amar",
            LastName = "Lastname",
            Gender = Gender.Female
        };

        var testUser2 = new TestUser { GenderType = Gender.Female };
        var sampleApplicationPage = new SampleApplicationPage(Driver);
        sampleApplicationPage.GoTo();
        Assert.True(sampleApplicationPage.isVisible(), "SampleApplicationPage is visible");
        sampleApplicationPage.SelectRadioButtonRegularForm(testUser);
        sampleApplicationPage.SelectRadioButtonRegularForm(testUser2);
        var ultimateQaPage = sampleApplicationPage.FillOutFormAndSubmit(testUser);
        Assert.True(ultimateQaPage.isVisible, "UltimateQaPage is not visible");
    }

    [Fact]
    [Trait("Category", "Sprint 4")]
    public void EmergencyFormTests() //only sprint 4 //ne radi fino selekcija na 
    {
        // Firs
        TestUser testUser2 = new TestUser
        {
            FirstName = "John",
            LastName = "Doe",
            GenderTypeEmergency = EmergencyGender.Female
        };
        var sampleApplicationPage = new SampleApplicationPage(Driver);
        sampleApplicationPage.GoToEmergencyForm();
        Assert.True(sampleApplicationPage.isVisible(), "SampleApplicationPage is visible");
        sampleApplicationPage.SelectRadioButtonEmergencyForm(testUser2);
        var ultimateQaPage = sampleApplicationPage.FillOutFormAndSubmitEmergencyForm(testUser2);
        Assert.True(ultimateQaPage.isVisible, "UltimateQaPage is visible");
    }

}
