using DocumentEditor.Tests.Acceptance;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentEditor.Tests.Acceptance.Pages
{
    class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public NewDocumentForm GotoNewDocumentForm()
        {
            driver.FindElement(By.XPath("//button[@type='button'][text()='New Document']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("newDocumentModal")));

            return new NewDocumentForm(driver);
        }

        public IEnumerable<string> Documents
        {
            get
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Documents")));

                var elements = driver.FindElements(By.XPath("//div[@id='Documents']/ul/li"));

                return elements.Select(el => el.Text);
            }
        }
    }
}
