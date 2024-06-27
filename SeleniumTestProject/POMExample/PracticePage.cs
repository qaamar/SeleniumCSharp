using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class PracticePage
{


    public IWebDriver driver;
    private string value;
    private string vehicle;
    private string car;
    private string tableContento;
    public PracticePage(IWebDriver driver, string value, string vehicle, string car, string tableContento)
    {
        this.driver = driver;
        this.value = value;
        this.vehicle = vehicle;
        this.car = car;
        this.tableContento = tableContento;
    }

    public PracticePage(IWebDriver driver)
    {

        this.driver = driver;
    }
    //Elements
    public IWebElement radioButton => driver.FindElement(By.XPath($"//input[@name='gender'][@value='{value}']"));
    public IWebElement checkBox => driver.FindElement(By.XPath($"//input[@name='vehicle'][@value='{vehicle}']"));
    public IWebElement dropdown => driver.FindElement(By.XPath("//*[@class='et_pb_blurb_content']//following-sibling::select"));

    public IWebElement tabTwo => driver.FindElement(By.XPath("//*[@class='et_pb_tab_1']"));
    public IWebElement tabContent => driver.FindElement(By.XPath("//div[@class='et_pb_all_tabs']"));

    public IWebElement tableContent => driver.FindElements(By.Id("htmlTableId"))[0];
    public IWebElement name => driver.FindElement(By.Id("et_pb_contact_name_1"));
    public IWebElement message => driver.FindElement(By.Id("et_pb_contact_message_1"));
    public IWebElement captchaResult => driver.FindElement(By.Name("et_pb_contact_captcha_1"));
    public IWebElement submit => driver.FindElements(By.XPath("//button[@type='submit']"))[1];
    public IWebElement captcha => driver.FindElement(By.XPath("//span[@class='et_pb_contact_captcha_question']"));


    //Methods


    public void ClickRadioButton(string value)
    {
        radioButton.Click();
    }

    public void SelectCheckbox(string vehicle)
    {
        checkBox.Click();
    }

    public void SelectCarFromTheDropdown(string car)
    {
        SelectElement selectElement = new SelectElement(dropdown);
        selectElement.SelectByText(car);

    }

    public void ClickAOnTab()
    {
        tabTwo.Click();
    }

    public void VerifyTabContent()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        string tabContentText = tabContent.Text;
        string expectedText = "Tab 2 content";
        //wait.Until(driver => tabContent.Displayed && tabContentText == "Tab 2 content");
        int counter = 0;
        while (tabContentText != expectedText && counter < 5)
        {
            ClickAOnTab();
            counter++;
        }
        if (counter == 5)
        {
            throw new Exception("Element is not displayed");
        }
    }
    public void VerifyTableContent(string tableContento)
    {
        var rows = tableContent.FindElements(By.TagName("tr"));
        foreach (var row in rows)
        {
            var cells = row.FindElements(By.TagName("td"));
            foreach (var cell in cells)
            {
                var text = cell.Text;
                if (text == tableContento)
                {
                    Console.WriteLine("Text is matching");
                    break;
                }

            }
        }

    }

    public void VerifyTableContent2() //rezervni nacin
    {
        var newFieldEl = driver.FindElement(By.XPath("//*[@id='htmlTableId']//td[text()='Automation Testing Architect']"));

        Assert.Contains("Automation Testing Architect", newFieldEl.Text);

    }

    #region Captcha solving
    public void EnterNameAndMessage()
    {
        name.Clear();
        name.SendKeys("Test");

        message.Clear();
        message.SendKeys("Testing");
    }

    public void SolveCaptcha()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => captcha.Displayed);
        // this can be done with the straight call to driver.FindElement(By.XPath("//span[@class='et_pb_contact_captcha_question']"))

        var captchaElementsText = captcha.Text;
        string pattern = @"\d+";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(captchaElementsText);
        if (matches.Count == 2)
        {
            int num1 = int.Parse(matches[0].Value);
            int num2 = int.Parse(matches[1].Value);
            int result = num1 + num2;
            captchaResult.SendKeys(result.ToString());
            submit.Click();
        }
        else throw new Exception("Captcha not solved");
    }
    #endregion
}