using NLog;
using NLog.Config;
using OpenQA.Selenium;
using static WebDriverFactory;

namespace SeleniumTestProject;

public class BaseTestExample : IDisposable
{
    public IWebDriver Driver { get; set; }
    //private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public Logger Logger { get; set; }
    public BaseTestExample()
    {
        try
        {
            // Initialize NLog
            var configPath = "nlog.config";
            if (!System.IO.File.Exists(configPath))
            {
                throw new FileNotFoundException($"NLog configuration file not found: {configPath}");
            }

            LogManager.Setup().LoadConfigurationFromFile(configPath);
            
            // Initialize WebDriver (e.g., ChromeDriver)
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            Logger = LogManager.GetLogger($"TestLogger.{GetType().FullName}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing test: {ex.Message}");
            throw;
        }

    }

    protected void SetTestName(string testName) => Logger.PushScopeProperty("testName", testName);

    public void LogInfo(string message)
    {
        Logger.Info(message);
    }

    public void LogDebug(string message)
    {
        Logger.Debug(message);
    }

    public void LogError(string message)
    {
        Logger.Error(message);
    }

    public void LogWarning(string message)
    {
        Logger.Warn(message);
    }

    public void Dispose()
    {
        try
        {
            // Cleanup WebDriver
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                Logger.Info("WebDriver quit and disposed");
            }
        }
        finally
        {
            Logger.Info("Test finished");
            LogManager.Shutdown();
        }
    }
}