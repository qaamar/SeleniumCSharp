using NLog.LayoutRenderers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationExerciseProj;


public class BaseTest : IDisposable
{
    public string url = "https://automationexercise.com/";
    public IWebDriver Driver { get; set; }
    

    public BaseTest() // Default constructor
    {
        SetupBeforeTest();
    }

    public BaseTest(IWebDriver driver)
    {
        Driver = driver;
    }

    public void SetupBeforeTest()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(url);
    }

    public void Dispose()
    {
        if (Driver != null)
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}


