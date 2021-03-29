using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    class Lesson4 : Fixtures
    {
        [TestCase("https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html", "false")]
        public void ExplicitWaitImage(string URL, string startup_popup)
        {
            // arrange
            var newUser = driver.FindElement(By.ClassName("btn-default"));
            var loader = driver.FindElement(By.Id("loading"));
            
            // act
            newUser.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => loader.Text.Contains("First Name"));

            // assert
            Assert.That(loader.Text.Contains("First Name"));
            Assert.That(loader.Text.Contains("Last Name"));
        }

        [TestCase("https://www.seleniumeasy.com/test/jquery-download-progress-bar-demo.html", "false")]
        public void ExplicitWaitPorgressBar(string URL, string startup_popup)
        {
            // arrange
            var start = driver.FindElement(By.Id("downloadButton"));
            var button = driver.FindElement(By.ClassName("ui-dialog-buttonset"));

            // act
            start.Click();
            //var progressBar = driver.FindElement(By.Id("progressbar")).GetAttribute("aria-valuenow");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => button.Text.Contains("Close"));

            // assert
            Assert.That(button.Text.Contains("Close"));
            //Assert.AreEqual(progressBar, "100");
        }

        [TestCase("http://the-internet.herokuapp.com/upload", "false")]
        public void UploadFile(string URL, string startup_popup)
        {
            // arrange
            var chooseFile = driver.FindElement(By.Id("file-upload"));
            var uploadFile = driver.FindElement(By.Id("file-submit"));
            var fileName = "sample30k.pdf";
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var filePath = path + "\\" + fileName;
            var filePath2 = Path.Combine(path, fileName);

            // act
            chooseFile.SendKeys(filePath2);
            uploadFile.Click();
            Thread.Sleep(1000);
            var uploadedFile = driver.FindElement(By.Id("uploaded-files"));

            // assert
            //Assert.That(uploadedFile.Text.Contains(fileName));
            var test = uploadFile.Text;
            Assert.AreEqual(uploadFile.Text, fileName);
        }

        [TestCase("https://www.seleniumeasy.com/test/javascript-alert-box-demo.html", "false")]
        public void JsAlerts(string URL, string startup_popup)
        {
            // arrange
            var clickMe = driver.FindElements(By.ClassName("btn-default"))[0];
            var clickMeConfirm = driver.FindElements(By.ClassName("btn-default"))[1];
            var clickMePrompt = driver.FindElements(By.ClassName("btn-default"))[2];
            var confirm = driver.FindElement(By.Id("confirm-demo"));
            var prompt = driver.FindElement(By.Id("prompt-demo"));
            string entered = "Elo";

            // act
            clickMe.Click();
            driver.SwitchTo().Alert().Accept();

            clickMeConfirm.Click();
            driver.SwitchTo().Alert().Accept();

            // assert
            Assert.AreEqual(confirm.Text, "You pressed OK!");

            clickMeConfirm.Click();
            driver.SwitchTo().Alert().Dismiss();

            Assert.AreEqual(confirm.Text, "You pressed Cancel!");

            clickMePrompt.Click();
            driver.SwitchTo().Alert().SendKeys(entered);
            driver.SwitchTo().Alert().Accept();

            Assert.That(prompt.Text.Contains(entered));
        }

        [TestCase("https://www.seleniumeasy.com/test/javascript-alert-box-demo.html", "false")]
        public void ScreenShot(string URL, string startup_popup)
        {
            // arrange
            Screenshot screenshot = driver.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\mor\\Desktop\\tst123.png");
            // act

            // assert

        }
    }
}
