using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject01
{
    internal class Sale
    {
        IWebDriver driver;

        public Sale(IWebDriver driver)
        {
            this.driver = driver;
        }


        //Make this work without parameters
        public void CheckAllRecommendationsExist()
        {
            var numberOfProductsShown = driver.FindElements(By.XPath("//div[@class='popular-product-slider-item']")).Count;



            if (!(numberOfProductsShown > 100))
            {
                Assert.Fail("Not enough products are shown on Sales page");
            }
        }

    }
}
