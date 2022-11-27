using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject01
{
    public class BrowserController
    {

        public IWebDriver driver;
        DefaultWait<IWebDriver> fluentWait;
        public BrowserController(IWebDriver driver, DefaultWait<IWebDriver> fluentWait)
        {
            this.driver = driver;
            this.fluentWait = fluentWait;
        }



        //move common methods to another class
        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }
        public void NavigateURL(string newURL)
        {
            driver.Url = newURL;
        }

        public void ClickElementByXpath(string xPath)
        {
            By elementas = By.XPath(xPath);

            driver.FindElement(elementas).Click();
        }

        public void CheckElementExistsByXpath(string xPath)
        {
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xPath)));
        }
        public void EnterTextByXpath(string xpath, string text)
        {
            CheckElementExistsByXpath(xpath);

            By element = By.XPath(xpath);
            driver.FindElement(element).SendKeys(text);
        }


        public string getTextByXpath(string xpath)
        {

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));

            return searchResult.Text;
        }



    }
}
