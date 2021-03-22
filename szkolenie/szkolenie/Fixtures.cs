using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace szkolenie
{
    [TestFixture]
    public class Fixtures
    {
        public ChromeDriver driver;
        [SetUp]
        public void Precondition()
        {
            string URL = TestContext.CurrentContext.Test.Arguments[0] as string;
            string startup_popup = TestContext.CurrentContext.Test.Arguments[1] as string;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000); // must to be, without it couldn't find By.Id("at-cv-lightbox-close")
            if (startup_popup == "True")
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")));
                var Popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
                Popup.Click();
            }
        }

        [TearDown]
        public void Postcondition()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
