using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSpec;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using DocumentEditor.Tests.Acceptance.Pages;
using DocumentEditor.Tests.Acceptance.Workflows;
using DocumentEditor.Infrastructure.DataLayer;
using System.Activities.Statements;

namespace DocumentEditor.Tests.Acceptance
{
    class DocumentTests : IISServerTest
    {
        IWebDriver driver = null;
        DocumentEditorSite site = null;
        UserWorkflow userWorkflow = null;

        public DocumentTests() : base("DocumentEditor")
        { }

        void before_each()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";

            driver = new FirefoxDriver(service);
            site = new DocumentEditorSite(driver);
            userWorkflow = new UserWorkflow(site);
        }

        void after_each()
        {
            driver.Dispose();
        }

        void when_creating_a_new_document()
        {
            context["given no documents exist"] = () =>
            {
                act = () =>
                {
                    var ctx = new DocumentContext();
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE [Documents]");
                };

                context["when a user creates a document"] = () =>
                {
                    string documentTitle = "New Document";

                    act = () =>
                    {
                        userWorkflow
                            .CreateNewDocument(documentTitle);
                    };

                    it["will appear in the list of documents"] = () =>
                    {
                        IEnumerable<string> documents = userWorkflow
                            .ViewListOfDocuments();

                        documents.Should().Contain("New Document");
                    };
                };
            };
        }
    }
}
