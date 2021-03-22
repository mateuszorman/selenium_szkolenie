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
    public class Lesson2 : Fixtures
    {
        [Test]
        [TestCase("https://www.seleniumeasy.com/test/basic-checkbox-demo.html", "false")]
        public void CheckBox(string URL, string startup_popup)
        {
            // arrange
            var logoText = driver.FindElement(By.LinkText("Selenium Easy"));
            var option = driver.FindElement(By.CssSelector("ul+ .checkbox label"));
            var singleCheckBoxBTN = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/div[1]/label"));

            // act
            singleCheckBoxBTN.Click();
            option.Click();
            logoText.Click();

            // assert
        }

        [Test]
        [TestCase("https://www.seleniumeasy.com/test/table-pagination-demo.html", "false")]
        public void Table(string URL, string startup_popup)
        {
            // arrange
            var table = driver.FindElement(By.ClassName("table-responsive"));
            var rows = table.FindElements(By.TagName("tr"));
            var cellFirstRaw = rows[1].FindElements(By.TagName("td"));

            // act
            var secondCell = cellFirstRaw[1];

            // assert
            Assert.AreEqual("Table cell", secondCell.Text);
        }

        [Test]
        [TestCase("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html", "false")]
        public void DropDown(string URL, string startup_popup)
        {
            // arrange
            var selectADay = new SelectElement(driver.FindElement(By.Id("select-demo")));
            var selectedValue = driver.FindElement(By.ClassName("selected-value"));

            // act
            selectADay.SelectByText("Monday");
            selectADay.SelectByIndex(5);
            selectADay.SelectByValue("Sunday");
            string selectedValueEdited = selectedValue.Text.Substring(16);

            // assert
            Assert.AreEqual("Sunday", selectedValueEdited);
        }
    }
}