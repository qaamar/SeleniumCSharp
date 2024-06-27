
using OpenQA.Selenium;

public class BasePage 
{
    protected IWebDriver Driver { get; set; }

    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }





}