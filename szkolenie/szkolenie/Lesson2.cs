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

namespace Szkolenie
{
    public class Lesson2
    {
        ChromeDriver driver;
        [Test]
        public void CheckBox()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            Thread.Sleep(1000);

            var logoText = driver.FindElement(By.LinkText("Selenium Easy"));
            var option = driver.FindElement(By.CssSelector("ul+ .checkbox label"));
            var singleCheckBoxBTN = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/div[1]/label"));

            singleCheckBoxBTN.Click();
            option.Click();
            logoText.Click();

            driver.Quit();
        }

        [Test]
        public void Table()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/table-pagination-demo.html");
            Thread.Sleep(1000);

            var table = driver.FindElement(By.ClassName("table-responsive"));
            var rows = table.FindElements(By.TagName("tr"));
            var cellFirstRaw = rows[1].FindElements(By.TagName("td"));
            var secondCell = cellFirstRaw[1];

            Assert.AreEqual("Table cell", secondCell.Text);

            driver.Quit();
        }

        [Test]
        public void DropDown()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
            Thread.Sleep(1000);

            var selectADay = new SelectElement(driver.FindElement(By.Id("select-demo")));
            var selectedValue = driver.FindElement(By.ClassName("selected-value"));

            selectADay.SelectByText("Monday");
            selectADay.SelectByIndex(5);
            selectADay.SelectByValue("Sunday");

            string selectedValueEdited = selectedValue.Text.Substring(16);

            Assert.AreEqual("Sunday", selectedValueEdited);

            Thread.Sleep(1000);

            driver.Quit();
        }
    }
}