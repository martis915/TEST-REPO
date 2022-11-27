using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace TestAutomationProject02
{
    public class Calculator
    {
        IWebDriver driver;
        public Calculator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void enterNumber1(string number1)
        {

            driver.FindElement(By.XPath("//div[@class='form-label']/input[@id='number1']")).SendKeys(number1);
        }

        public void enterNumber2(string number2)
        {

            driver.FindElement(By.XPath("//div[@class='form-label']/input[@id='number2']")).SendKeys(number2);
        }
        public void ClickCalculateButton()
        {
            driver.FindElement(By.XPath("//input[@id='calculate']")).Click();
        }
        public void CheckResult(string expectedRez)
        {
            string s = driver.FindElement(By.XPath("//p//span[@id='answer']")).GetAttribute(expectedRez);
        }

    }

    public class Class1
    {
        IWebDriver driver = new ChromeDriver();

        Calculator calc;
        [SetUp]
        public void Initialize()
        {
            calc = new Calculator(driver);
            //navigate to URL  
            driver.Navigate().GoToUrl("https://testpages.herokuapp.com/styled/calculator");
            //Maximize the browser window  
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }


        [Test]
        public void PirmasTestas()
        {
            //identify the number field  
            calc.enterNumber1("2");
            Console.Write("Skaicius 2 Ivestas \n");

            //enter 2nd number
            calc.enterNumber2("2");
            Console.Write("Skaicius 2 Ivestas \n");

            //click calculate
            calc.ClickCalculateButton();
            calc.CheckResult("4");



        }
        [Test]
        public void AntrasTestas()
        {
            //identify the number field  
            IWebElement skaiciai3 = driver.FindElement(By.XPath("//div[@class='form-label']/input[@id='number1']"));
            //enter the 1st number
            skaiciai3.SendKeys("-5");
            Thread.Sleep(500);
            Console.Write("Skaicius 2 Ivestas \n");

            //enter 2nd number
            IWebElement skaiciai4 = driver.FindElement(By.XPath("//div[@class='form-label']/input[@id='number2']"));
            skaiciai4.SendKeys("3");
            Thread.Sleep(500);
            Console.Write("Skaicius 2 Ivestas \n");

            //click calculate
            driver.FindElement(By.XPath("//input[@id='calculate']")).Click();


            string l = driver.FindElement(By.XPath("//p//span[@id='answer']")).GetAttribute("-2");



        }

        [Test]
        public void TreciasTestas()
        {
            //identify the number field  
            IWebElement raides = driver.FindElement(By.XPath("//div[@class='form-label']/input[@id='number1']"));
            //enter the 1st number
            raides.SendKeys("a");
            Thread.Sleep(500);
            Console.Write("Raide a Ivesta \n");

            //enter 2nd number
            IWebElement raides2 = driver.FindElement(By.XPath("//div[@class='form-label']/input[@id='number2']"));
            raides2.SendKeys("b");
            Thread.Sleep(500);
            Console.Write("Raide b Ivesta \n");

            //click calculate
            driver.FindElement(By.XPath("//input[@id='calculate']")).Click();


            string m = driver.FindElement(By.XPath("//p//span[@id='answer']")).GetAttribute("ERR");




        }
        [TearDown]
        public void tearDw()
        {
            driver.Close();
        }


    }
}