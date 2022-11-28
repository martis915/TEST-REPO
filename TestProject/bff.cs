using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//New Branch code 01
//new code
namespace TestProject
{
    internal class bff
    {
        IWebDriver driver;
        public bff(IWebDriver driver)
        {
            this.driver = driver;
        }



        public void inputText1(string inputText)
        {
            By by = By.XPath("//input[@id='user-message']");
            IWebElement messageInputField = driver.FindElement(by);
            messageInputField.SendKeys(inputText);
        }

        public void clickShowMessageButton(IWebDriver driver)
        {

            By by = By.XPath("//button[@onclick='showInput();']");
            IWebElement elem = driver.FindElement(by);
            elem.Click();
        }

        public void checkEndResultText(string expected)
        {

            By by = By.XPath("//span[@id='display']");
            IWebElement element = driver.FindElement(by);

            Assert.AreEqual(element.Text, expected);
        }



    }
}
