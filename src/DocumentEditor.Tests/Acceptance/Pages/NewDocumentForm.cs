using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentEditor.Tests.Acceptance.Pages
{
    class NewDocumentForm
    {
        private readonly IWebDriver driver;

        public NewDocumentForm(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string Title
        {
            set
            {
                driver.FindElement(By.Name("Title")).SendKeys(value);
            }
        }

        public void Submit()
        {
            driver.FindElement(By.XPath("//button[@type='submit'][text()='Submit']")).Click();
        }
    }
}
