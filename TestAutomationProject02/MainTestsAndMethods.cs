using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using TestAutomationProject02.Pages;

namespace TestAutomationProject02
{
    public class MainTestsAndMethods
    {
        driverController controller;

        TopMenu top;
        [SetUp]
        public void setUp()
        {
            controller = new driverController();
            top = new TopMenu(main);

            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.guru99.com/live-agile-testing-project.html";
            main.ClickButtonByXpath("//button[@aria-label='Consent']");

        }


        [Test]
        public void InvalidSignupCredentials()
        {
            MainMethods main = new MainMethods(controller.driver);
            ProjectPage ppage = new ProjectPage(controller.driver);
            main.CheckFooterExists();
            ppage.CheckProjectContentCountCorrect("//div[@class='entry-content single-content']/*");
            ppage.EnterEmail("AAAAA");
            ppage.ClickSubmitButton();
            main.CheckElementExistsByXpath("//h1[@id='error-heading']");


        }



        [Test]
        public void CheckTopMenuCategories()
        {
            MainMethods main = new MainMethods(controller.driver);

            top.CheckAllCategoriesCount(controller.driver);

            main.ClickButtonByXpath("//button[contains(@class,'search-toggle-open')]");

            main.EnterTextByXpath("//input[@type='search']", "!@#$@^$#&$^*");

            main.ClickButtonByXpath("//input[@type='submit']");

            main.CheckElementTextByXpath("//div[contains(@class,'resultsbox')]//div[contains(@class,'snippet')]", "No Results");

        }




    }
}