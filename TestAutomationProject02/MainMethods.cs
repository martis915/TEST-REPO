using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject02
{
    public class MainMethods
    {
        public IWebDriver driver = new ChromeDriver();
        public string TestName = "Default Test Name";


        [SetUp]
        public void setup()
        {
            GoToUrl("https://www.hostinger.com/");
            ClickElementByXpath("//button[contains(text(),'Accept')]");
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void tear()
        {
            try
            {
                Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                //DateTime time = new DateTime();

                string time = "_" + DateTime.Now.ToString("HH:mm");
                Console.WriteLine("_" + time);
                time = time.Replace(':', '_');

                TakeScreenshot.SaveAsFile("C:\\Users\\Martynas\\Documents\\Zoom\\TestName\\" + TestName + time + ".png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            driver.Quit();

        }



        public void ClickElementByXpath(string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            fluentWait.Message = "Element to be searched not found";


            /* Explicit Wait */
            /* IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath))); */
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));
            searchResult.Click();

        }

        public void ClickElementByBy(By element)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            fluentWait.Message = "Element to be searched not found";


            /* Explicit Wait */
            /* IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath))); */
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(element));
            searchResult.Click();

        }

        public void CheckElementExistsByXpath(string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";


            /* Explicit Wait */
            /* IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath))); */
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));
        }




        public void GoToUrl(string url)
        {
            driver.Url = url;
        }

        public void ScrollAndClickElementByXpath(string xpath)
        {
            CheckElementExistsByXpath(xpath);


            By by = By.XPath(xpath);
            IWebElement element = driver.FindElement(by);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            try
            {
                actions.Perform();
            }
            catch (Exception ex) { }

            Thread.Sleep(500);

            ClickElementByBy(by);
        }





    }
}
