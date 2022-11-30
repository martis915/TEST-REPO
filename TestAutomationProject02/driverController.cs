using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject02
{
    internal class driverController
    {
        public IWebDriver driver;

        public driverController()
        {
            driver = new ChromeDriver();
        }

    }
}
