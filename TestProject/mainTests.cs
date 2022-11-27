using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject
{
    public class mainTests
    {
        IWebDriver driver;

        bff bffPage;

        [SetUp]
        public void setUP()
        {
            driver = new ChromeDriver();
            bffPage = new bff(driver);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
        }


        [Test]
        public void Test01()
        {
            string inputText = "Testas";
            bffPage.inputText1(inputText);
            bffPage.clickShowMessageButton(driver);
            bffPage.checkEndResultText(inputText);
        }


        [Test]
        public void Test02()
        {
            string inputText = "!@#$^&*165456=";


            bffPage.inputText1(inputText);
            bffPage.clickShowMessageButton(driver);
            bffPage.checkEndResultText(inputText);

        }


        [TearDown]
        public void NewTest()
        {
            driver.Quit();
        }

    }
}