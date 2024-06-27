using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using static WebDriverFactory;

namespace SeleniumTestProject;
public class PracticeTests
{
    public IWebDriver Driver { get; private set; }



    [Fact]
    public void ImplicitAndExplicitWaitsTest()
    {
        // Setup
        SetupBeforeTest();
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        Driver.Manage().Window.Maximize();

        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
        IWebElement removeButton = Driver.FindElement(By.XPath("//*[@id='checkbox-example']//*[contains(text(),'Remove')]"));
        removeButton.Click();
        wait.Until(Driver => Driver.FindElement(By.XPath("//*[@id='checkbox-example']//*[contains(text(),'Add')]")).Displayed);
        Driver.Close();
    }

    [Fact]
    public void Practice1()
    {
        // Setup
        SetupBeforeTest();
        //Navigation and interaction
        Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");
        Driver.Manage().Window.Maximize();
        string gender = "male";
        string vehicle = "Car"; //case sensitive
        string car = "Audi";
        string tableContento = "$150,000+";
        PracticePage practicePage = new PracticePage(Driver, gender, vehicle, car, tableContento);
        practicePage.ClickRadioButton(gender);
        practicePage.SelectCheckbox(vehicle);

        practicePage.SelectCarFromTheDropdown(car);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        practicePage.ClickAOnTab();
        //Thread.Sleep(10000);
        practicePage.VerifyTabContent();
        //practicePage.VerifyTableContent(tableContento);
        //practicePage.VerifyTableContent2();
        Driver.Close();

    }

    [Fact]
    public void PomPractice()
    {
        // Setup
        SetupBeforeTest();
        //Navigation and interaction
        Driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");
        Driver.Manage().Window.Maximize();


    }

    [Fact]
    public void Practice2()
    {
        // Setup
        SetupBeforeTest();

        //Navigation
        PracticePage practicePage = new PracticePage(Driver);
        Driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms");
        practicePage.EnterNameAndMessage();
        practicePage.SolveCaptcha();
        Driver.Close();

    }

    internal void SetupBeforeTest()
    {
        Driver = new WebDriverFactory().Create(BrowserType.Chrome);

    }
}