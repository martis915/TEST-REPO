using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace _16Paskaita
{
    public class Class1
    {
        [Test]
        public void TestCase01()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.ebay.com/";

            ClickElementByXpath(driver, "//div[@role='navigation']//a[contains(@href,'globaldeals')]");
            if (GetElementsCount(driver, "//header[@role='banner']//div[@role='navigation']//li") < 10)
            {
                Assert.Fail("'//header[@role='banner']//div[@role='navigation']//li' returned too few products");
            }

            ClickElementByXpath(driver, "//div[contains(@class,'topDeals')]//span[@itemprop='name']");

            CheckProductCardGeneral(driver);
        }

        public void CheckElementExistsByXpath(IWebDriver driver, string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            By by = By.XPath(xpath);
            IWebElement element = fluentWait.Until(x => x.FindElement(by));
        }
        public void ClickElementByXpath(IWebDriver driver, string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            By by = By.XPath(xpath);
            IWebElement element = fluentWait.Until(x => x.FindElement(by));

            element.Click();
        }

        public int GetElementsCount(IWebDriver driver, string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
            By by = By.XPath(xpath);
            IWebElement element = fluentWait.Until(x => x.FindElement(by));

            return driver.FindElements(By.XPath(xpath)).Count;

        }
        public void CheckProductCardGeneral(IWebDriver driver)
        {

            //Check right panel exists
            CheckElementExistsByXpath(driver, "//div[@id='RightSummaryPanel']");

            //Check breadcrumbs exist
            CheckElementExistsByXpath(driver, "//li[contains(@class,'breadcrumb')]");


            //Check Buy it, add to watchlist, and add to cart buttons exist
            if (GetElementsCount(driver, "//ul[contains(@class,'buybox')]/li") != 3)
            {
                Assert.Fail();
            }

            if (GetElementsCount(driver, "//section[@class='merch-module']") == 0)
            {
                Assert.Fail();
            }

            if (GetElementsCount(driver, "//footer[@role='contentinfo']//a") < 15)
            {
                Assert.Fail();
            }

        }


    }
}