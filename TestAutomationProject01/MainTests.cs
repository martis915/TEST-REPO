
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationProject01
{



    public class MainTests
    {

        public IWebDriver driver;
        private DefaultWait<IWebDriver> fluentWait;
        BrowserController brContr;
        Sale sale;

        [SetUp]
        public void buildUp()
        {
            driver = new ChromeDriver();
            fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            brContr = new BrowserController(driver, fluentWait);
            sale = new Sale(driver);
            brContr.Maximize();
            brContr.NavigateURL("https://www.saucedemo.com/");
        }

        [TearDown]
        public void tearDown()
        {
            brContr.driver.Close();
        }

        [Test]
        public void CheckFailedLoginErrorExists()
        {

            brContr.ClickElementByXpath("//input[@id='login-button']");
            brContr.CheckElementExistsByXpath("//h3[@data-test='error']");
            //Console.WriteLine("\n\n\n" + brContr.getTextByXpath("//h3[@data-test='error']"));
            Assert.AreEqual(brContr.getTextByXpath("//h3[@data-test='error']"), "Epic sadface: Username is required");
        }

        [Test]
        public void CheckSuccesLogin()
        {


            brContr.EnterTextByXpath("//input[@placeholder='Username']", "standard_user");
            brContr.EnterTextByXpath("//input[@placeholder='Password']", "secret_sauce");
            brContr.ClickElementByXpath("//input[@id='login-button']");
            Console.WriteLine("TESTAS");
        }


        [Test]
        public void TrySingleInputField()
        {
            brContr.NavigateURL("https://demo.seleniumeasy.com/basic-first-form-demo.html");

            string inputText = "TESTTEST";

            brContr.EnterTextByXpath("//input[@id='user-message']", inputText);
            brContr.ClickElementByXpath("//button[@onclick='showInput();']");

            brContr.CheckElementExistsByXpath("//div[@id='user-message']//span[text()='" + inputText + "']");

        }
        [Test]
        public void TryMultipleInputField()
        {
            brContr.NavigateURL("https://demo.seleniumeasy.com/basic-first-form-demo.html");

            string inputText1 = "1";
            string inputText2 = "5";


            brContr.EnterTextByXpath("//input[@id='sum1']", inputText1);
            brContr.EnterTextByXpath("//input[@id='sum2']", inputText2);

            brContr.ClickElementByXpath("//button[@onclick='return total()']");

            brContr.CheckElementExistsByXpath("//span[@id='displayvalue' and text()='" + 6 + "']");

        }

        [Test]
        public void SelectFromListTest()
        {
            brContr.NavigateURL("https://demo.seleniumeasy.com/basic-select-dropdown-demo.html");

            SelectElement dropDown = new SelectElement(brContr.driver.FindElement(By.Id("select-demo")));
            dropDown.SelectByValue("Sunday");

            brContr.CheckElementExistsByXpath("//div[@class='panel-body']//p[text()='Day selected :- Sunday']");

        }


        [Test]
        public void PiguSalesTest()
        {
            brContr.NavigateURL("https://pigu.lt/lt/isparduotuve");

            brContr.CheckElementExistsByXpath("//div[@class='popular-product-slider-item']");

            sale.CheckAllRecommendationsExist();
        }

        [Test]
        public void WaitingTest()
        {
            brContr.NavigateURL("https://demo.seleniumeasy.com/dynamic-data-loading-demo.html");
            brContr.ClickElementByXpath("//button[@id='save']");
            brContr.CheckElementExistsByXpath("//div[@id='loading' and contains(text(),'First Name')]");
        }




    }
}