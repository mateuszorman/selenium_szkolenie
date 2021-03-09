using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace szkolenie
{
    [TestFixture]
    public class Fixtures
    {
        public ChromeDriver driver;
        [SetUp]
        public void Precondition()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName("at-cm-no-button")).Click();
        }

        [TearDown]
        public void Postcondition()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
