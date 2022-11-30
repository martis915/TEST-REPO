using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject02.Pages
{
    internal class TopMenu
    {
        MainMethods main;
        public TopMenu(MainMethods main)
        {
            this.main = main;
        }


        public void CheckAllCategoriesCount(IWebDriver driver)
        {
            IList<IWebElement> elments = driver.FindElements(By.XPath("//ul[@id='primary-menu']//li[contains(@class,'menu-item-has-children')]"));


            int[] expectedCategories =
            {
                21,
                24,
                33,
                30,
                19,
                16,
                7
            };


            for (int i = 0; i < elments.Count; i++)
            {
                elments[i].Click();
                Console.WriteLine(driver.FindElements(By.XPath("//ul[@class='sub-menu show']/li")).Count);

                int actualCategoryCount = driver.FindElements(By.XPath("//ul[@class='sub-menu show']/li")).Count;
                int errorSize = 2;

                if (!((expectedCategories[i] - errorSize) < actualCategoryCount))
                {
                    if (!((expectedCategories[i] + errorSize) > actualCategoryCount))
                    {

                        Assert.Fail((expectedCategories[i] + errorSize) + " < " + actualCategoryCount);
                    }
                    Assert.Fail((expectedCategories[i] - errorSize) + " > " + actualCategoryCount);
                }
            }
        }

        public void EnterSearchText(string Text)
        {

            main.EnterTextByXpath("//input[@type='search']", "!@#$@^$#&$^*");

        }




    }

}
