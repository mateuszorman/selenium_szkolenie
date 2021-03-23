using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace szkolenie
{
    class Lesson3
    {
        ChromeDriver driver;
        [Test]
        public void CheckBox()
        {
            // arrange
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/jquery-dropdown-search-demo.html");
            Thread.Sleep(1000);
            var newZealandString = "New Zealand";

            // act
            var selectCountryDD = driver.FindElement(By.ClassName("selection"));
            selectCountryDD.Click();
            var options = driver.FindElement(By.ClassName("select2-results__options")).FindElements(By.TagName("li"));
            var newZealand = options.Where(d => d.Text == newZealandString).FirstOrDefault();
            newZealand.Click();

            // assert
            Assert.AreEqual(newZealandString, selectCountryDD.Text);
            Assert.IsTrue(selectCountryDD.Text == newZealandString);
            Assert.That(selectCountryDD.Text == newZealandString);
            driver.Quit();
        }

        [Test]
        public void ExplicitWait()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-first-form-demo.html");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")));
            var Popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            Popup.Click();
            driver.Quit();
        }

        [Test]
        public void DragAndDrop()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/demo-site/draganddrop/");

            Thread.Sleep(1000);

            var frame = driver.FindElement(By.ClassName("demo-frame"));

            driver.SwitchTo().Frame(frame);

            var image1 = driver.FindElements(By.ClassName("ui-draggable")).FirstOrDefault();
            var trash = driver.FindElement(By.Id("trash"));

            var action = new Actions(driver);
            action.DragAndDrop(image1, trash);
            action.Build();
            action.Perform();
            Thread.Sleep(1000);

            var trashAfter = trash.FindElements(By.TagName("img"));
            Assert.IsTrue(trashAfter.Count == 1);

            driver.SwitchTo().DefaultContent();

            driver.Quit();
        }



        [Test]
        public void NewWindow()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/table-pagination-demo.html");

            Thread.Sleep(1000);

            var image1 = driver.FindElement(By.ClassName("cbt"));

            var windowHandlesBefore = driver.WindowHandles;

            image1.Click();
            Thread.Sleep(5000);

            var windowHandlesAfter = driver.WindowHandles;

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            Assert.AreEqual("Cross Browser Testing Tool: 2050+ Real Browsers & Devices", driver.Title);

            driver.Close();

            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.AreEqual("Selenium Easy - Table with Pagination Demo", driver.Title);

            driver.Quit();
        }
    }
}
