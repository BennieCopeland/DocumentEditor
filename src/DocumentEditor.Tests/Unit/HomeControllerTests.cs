using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSpec;
using Moq;
using DocumentEditor.Controllers.Home;
using System.Data.Entity;
using DocumentEditor.Models;
using DocumentEditor.Infrastructure.DataLayer;
using System.Web.Mvc;
using FluentAssertions;

namespace DocumentEditor.Tests.Unit
{
    class HomeControllerTests : nspec
    {
        Mock<DbSet<Document>> documentSet = null;
        Mock<DocumentContext> documentContext = null;
        HomeController controller = null;

        void before_each()
        {
            documentSet = new Mock<DbSet<Document>>();
            documentContext = new Mock<DocumentContext>();

            documentContext.Setup(m => m.Documents).Returns(documentSet.Object);
            controller = new HomeController(documentContext.Object);
        }

        void when_getting_the_home_page()
        {
            ViewResult result = null;

            act = () =>
            {
                result = (ViewResult)controller.Index();
            };

            context["given no documents exist"] = () =>
            {
                IQueryable<Document> documents = null;

                beforeEach = () =>
                {
                    documents = new List<Document>().AsQueryable();

                    documentSet.As<IQueryable<Document>>().Setup(m => m.Provider).Returns(documents.Provider);
                    documentSet.As<IQueryable<Document>>().Setup(m => m.Expression).Returns(documents.Expression);
                    documentSet.As<IQueryable<Document>>().Setup(m => m.ElementType).Returns(documents.ElementType);
                    documentSet.As<IQueryable<Document>>().Setup(m => m.GetEnumerator()).Returns(() => documents.GetEnumerator());
                };

                it["there will be no documents"] = () =>
                {
                    Index.ViewModel model = (Index.ViewModel)result.Model;

                    model.Documents.Should().BeEmpty();
                };
            };

            context["given three documents exist"] = () =>
            {
                IQueryable<Document> documents = null; 

                beforeEach = () =>
                {
                    documents = new List<Document>
                    {
                        new Document(Guid.NewGuid(), "Document 1"),
                        new Document(Guid.NewGuid(), "Document 2"),
                        new Document(Guid.NewGuid(), "Document 3")
                    }.AsQueryable();

                    documentSet.As<IQueryable<Document>>().Setup(m => m.Provider).Returns(documents.Provider);
                    documentSet.As<IQueryable<Document>>().Setup(m => m.Expression).Returns(documents.Expression);
                    documentSet.As<IQueryable<Document>>().Setup(m => m.ElementType).Returns(documents.ElementType);
                    documentSet.As<IQueryable<Document>>().Setup(m => m.GetEnumerator()).Returns(() => documents.GetEnumerator());
                };

                it["will return three documents"] = () =>
                {
                    Index.ViewModel model = (Index.ViewModel)result.Model;

                    model.Documents.Count.Should().Be(3);
                };
            };

        }

        void when_creating_a_new_document()
        {
            context["when a valid form is POSTed"] = () =>
            {
                Index.FormData formData = null;
                RedirectToRouteResult result = null;

                beforeEach = () =>
                {
                    formData = new Index.FormData();
                    formData.Title = "New Document";
                };

                act = () =>
                {
                    result = (RedirectToRouteResult)controller.Index(formData);
                };

                it["will save it to the database"] = () =>
                {
                    documentSet.Verify(m => m.Add(It.Is<Document>(doc => doc.Title == "New Document")));
                };

                it["will redirct back to the homepage"] = () =>
                {
                    result.RouteValues["controller"].Should().BeNull();
                    result.RouteValues["action"].Should().Be("Index");
                };
            };
        }
    }
}
