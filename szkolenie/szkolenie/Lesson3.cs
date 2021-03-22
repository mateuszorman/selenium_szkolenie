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
    class Lesson3 : Fixtures
    {
        [Test]
        [TestCase("https://www.seleniumeasy.com/test/jquery-dropdown-search-demo.html", "false")]
        public void CheckBox(string URL, string startup_popup)
        {
            // arrange
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
        }

        [Test]
        [TestCase("https://www.seleniumeasy.com/test/basic-first-form-demo.html", "false")]
        public void ExplicitWait(string URL, string startup_popup)
        {
            // arrange

            // act
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")));
            var Popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            Assert.IsTrue(Popup.Displayed);
            Popup.Click();

            // assert
            try
            {
                Assert.IsFalse(Popup.Displayed);
            }
            catch (Exception e)
            {
                // How to log.info?
            }
        }

        [Test]
        [TestCase("https://www.globalsqa.com/demo-site/draganddrop/", "false")]
        public void DragAndDrop(string URL, string startup_popup)
        {
            // arrange
            var frame = driver.FindElement(By.ClassName("demo-frame"));
            // act
            driver.SwitchTo().Frame(frame);

            var image1 = driver.FindElements(By.ClassName("ui-draggable")).FirstOrDefault();
            var trash = driver.FindElement(By.Id("trash"));

            var action = new Actions(driver);
            action.DragAndDrop(image1, trash);
            action.Build();
            action.Perform();
            Thread.Sleep(1000);

            var trashAfter = trash.FindElements(By.TagName("img"));

            // assert
            Assert.IsTrue(trashAfter.Count == 1);
            driver.SwitchTo().DefaultContent();
        }

        [Test]
        [TestCase("https://www.seleniumeasy.com/test/table-pagination-demo.html", "false")]
        public void NewWindow(string URL, string startup_popup)
        {
            // arrange
            var image1 = driver.FindElement(By.ClassName("cbt"));
            var windowHandlesBefore = driver.WindowHandles;

            // act
            image1.Click();

            var windowHandlesAfter = driver.WindowHandles;
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("live-testing-icon")));

            // assert
            Assert.AreEqual("Cross Browser Testing Tool: 2050+ Real Browsers & Devices", driver.Title);

            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            Assert.AreEqual("Selenium Easy - Table with Pagination Demo", driver.Title);
        }
    }
}
