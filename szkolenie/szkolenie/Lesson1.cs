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
    public class Lesson1 : Fixtures
    {
        [TestCase("https://www.seleniumeasy.com/test/basic-first-form-demo.html", "True")]
        public void CheckInput(string URL, string startup_popup)
        {
            // arrange
            string typed_text = "AAAAAAAAA!!!";
            var eneterMessage = driver.FindElement(By.Id("user-message"));
            var textElem = driver.FindElement(By.Id("display"));
            var buttons = driver.FindElements(By.ClassName("btn-default"));

            // act
            eneterMessage.SendKeys(typed_text);
            buttons[0].Click();
            string read_text = textElem.Text;

            //assert
            Assert.AreEqual(read_text, typed_text);
        }

        [TestCase("https://www.seleniumeasy.com/test/basic-first-form-demo.html", "True")]
        public void CheckSum(string URL, string startup_popup)
        {
            // arrange
            int number_1 = 4;
            int number_2 = 3;
            int result = 7;
            var firstNumber = driver.FindElement(By.Id("sum1"));
            var secondNumber = driver.FindElement(By.Id("sum2"));
            var buttons = driver.FindElements(By.ClassName("btn-default"));
            var result_sum = driver.FindElement(By.Id("displayvalue"));

            // act
            firstNumber.SendKeys(number_1.ToString());
            secondNumber.SendKeys(number_2.ToString());
            buttons[1].Click();
            string read_text = result_sum.Text;

            //assert
            Assert.AreEqual(Convert.ToInt32(read_text), result);
        }
    }
}
