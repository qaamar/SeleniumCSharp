using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using static WebDriverFactory;

namespace SeleniumTestProject;

public class UnitTest1 : BaseTestExample
{
    // private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    // public IWebDriver Driver { get; private set; }

    // [Fact]
    // public void Test2()
    // {
    //     // Setup
    //     SetupBeforeTest();

    //     try
    //     {
    //         // Navigation and interaction
    //         Driver.Navigate().GoToUrl("https://automationexercise.com/login");
    //         RegistrationAndLoginPage registrationAndLoginPage = new RegistrationAndLoginPage(Driver);
    //         registrationAndLoginPage.EnterUsername("test");
    //         logger.Info("Username entered");

    //     }
    //     finally
    //     {
    //         // Teardown
    //         if (Driver != null)
    //         {
    //             Driver.Quit();
    //         }
    //     }
    // }

    // internal void SetupBeforeTest()
    // {
    //     Driver = new WebDriverFactory().Create(BrowserType.Chrome);
    // }
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
}
