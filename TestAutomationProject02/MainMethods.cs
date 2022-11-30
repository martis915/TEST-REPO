using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject02
{
    internal class MainMethods
    {
        IWebDriver driver;


        public MainMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void CheckElementTextByXpath(string xpath, string expectedText)
        {

            string actualText = driver.FindElement(By.XPath(xpath)).Text;

            if (!actualText.Equals(expectedText))
            {
                Assert.Fail(actualText + " != " + expectedText);
            }
        }

        public void EnterTextByXpath(string xpath, string textToEnter)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(textToEnter);
        }

        public void ClickButtonByXpath(string xpath)
        {
            By by = By.XPath(xpath);
            driver.FindElement(by).Click();
        }

        public void CheckElementExistsByXpath(string xpath)
        {
            By by = By.XPath(xpath);
            driver.FindElement(by);
        }
        public void CheckFooterExists()
        {
            CheckElementExistsByXpath("//footer");
        }

        public int getElementsCountByXpath(string xpath)
        {
            By by = By.XPath(xpath);
            int count = driver.FindElements(by).Count;
            return count;
        }
    }
}
