using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject02.Pages
{
    internal class ProjectPage
    {
        IWebDriver driver;


        public ProjectPage(IWebDriver driver)
        {
            this.driver = driver;
        }



        public void CheckProjectContentCountCorrect(string xpath)
        {
            By by = By.XPath(xpath);
            int count = driver.FindElements(by).Count;

            if (count < 10)
            {
                Assert.Fail("Found " + count + " Elements. Expected more than 10");
            }

        }

        public void EnterEmail(string email)
        {
            driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(email);
        }

        public void ClickSubmitButton()
        {
            By by = By.XPath("//input[@name='submit']");
            driver.FindElement(by).Click();

        }


    }
}
