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
    public class LessonX : Fixtures
    {
        [Test]
        public void CheckBox() // jaka jest dobra praktyka, przeklikiwanie sie na podstrony czy wchodzenie bezposrednio pod link. Czy przeklikiwanie sie na podstrony realizowane są w osobnych 'siutach'?
        {
            IList<IWebElement> list_of_elements = driver.FindElements(By.ClassName("glyphicon-chevron-down"));
            Assert.AreEqual(list_of_elements.Count, 1);
            driver.FindElements(By.ClassName("glyphicon-chevron-right"))[0].Click();
            IList<IWebElement> list_of_elements_after = driver.FindElements(By.ClassName("glyphicon-chevron-down"));
            Assert.AreEqual(list_of_elements_after.Count, 2); // czy to jest wystarczajace sprawdzenie na rozwiniecie listy?
            Thread.Sleep(1000);

            //var selectElement = new SelectElement(list_of_elements_after[1]); // co robie nie tak?
            //selectElement.SelectByText("Checkbox");

            //IList<IWebElement> li = driver.FindElements(By.LinkText("Checkbox Demo"));
            //SelectElement select = new SelectElement(li[0]); // co robie nie tak?
            //select.SelectByIndex(1);

            driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[2]/ul/li/ul/li[1]/ul/li[2]/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.IsTrue(driver.FindElement(By.ClassName("cb1-element")).Displayed);
            Assert.IsTrue(driver.Url == "https://www.seleniumeasy.com/test/basic-checkbox-demo.html");

        }
    }
}
