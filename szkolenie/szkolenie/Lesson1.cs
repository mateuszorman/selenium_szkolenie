using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Szkolenie
{
    public class Lesson1
    {
        ChromeDriver driver;

        [Test]
        public void CheckInput()
        {
            string typed_text = "AAAAAAAAA!!!";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName("at-cm-no-button")).Click();
            driver.FindElement(By.Id("user-message")).SendKeys(typed_text);
            driver.FindElements(By.ClassName("btn-default"))[0].Click();
            string read_text = driver.FindElement(By.Id("display")).Text;
            Assert.AreEqual(read_text, typed_text);
            driver.Quit();
        }

        [Test]
        public void CheckSum()
        {
            int number_1 = 4;
            int number_2 = 3;
            int result = 7;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName("at-cm-no-button")).Click();
            driver.FindElement(By.Id("sum1")).SendKeys(number_1.ToString());
            driver.FindElement(By.Id("sum2")).SendKeys(number_2.ToString());
            driver.FindElements(By.ClassName("btn-default"))[1].Click();
            string read_text = driver.FindElement(By.Id("displayvalue")).Text;
            Assert.AreEqual(Convert.ToInt32(read_text), result);
            driver.Quit();
        }
    }
}
