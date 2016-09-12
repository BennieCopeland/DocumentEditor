using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentEditor.Tests.Acceptance.Pages
{
    class DocumentEditorSite
    {
        private readonly IWebDriver driver;

        public DocumentEditorSite(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage GotoHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:61826/");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(page => page.Title == "Index");

            return new HomePage(driver);
        }
    }
}
