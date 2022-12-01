using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Xml.Linq;
using TestAutomationProject02.Pages;

namespace TestAutomationProject02
{
    public class MainTests : MainMethods
    {

        [Test]
        public void InheritanceTest()
        {
            MainPage mainPage = new MainPage();

            WebHostingPage hostPage = new WebHostingPage();


            TestName = "InheritanceTest";

            mainPage.GoToCategory(driver, "Hosting", "Web Hosting");
            hostPage.AddSingleWebHostingPlanToCart(driver);

            //Check something exists
            CheckElementExistsByXpath("//div[contains(@class,'cart-choose-period')]");

            //asdfasdffads
            CheckElementExistsByXpath("//div[@id='create-account']");

            //asdfadsfsadfsdafsdaf
            CheckElementExistsByXpath("//div[contains(@class,'select-payment__container')]");

        }

    }
}