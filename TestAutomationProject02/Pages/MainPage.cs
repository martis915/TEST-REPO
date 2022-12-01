using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject02.Pages
{
    internal class MainPage
    {
        public void GoToCategory(IWebDriver driver, string baseCat, string secondaryCat)
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

            By by = By.XPath("//span[contains(@class,'menu-item-title') and text()='" + baseCat + "']");


            IWebElement baseCatElement = fluentWait.Until(x => x.FindElement(by));
            baseCatElement.Click();

            by = By.XPath("//nav[@role='navigation']//span[contains(text(),'" + secondaryCat + "')]");
            //-----------------------------------------------
            IWebElement secondaryCatElement = fluentWait.Until(x => x.FindElement(by));
            secondaryCatElement.Click();





        }

    }
}
