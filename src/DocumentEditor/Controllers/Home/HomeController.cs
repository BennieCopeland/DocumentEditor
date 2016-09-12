using DocumentEditor.Infrastructure.DataLayer;
using DocumentEditor.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DocumentEditor.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly DocumentContext context;

        public HomeController(DocumentContext context)
        {
            this.context = context;
        }

        // GET: Home
        public ActionResult Index()
        {
            Index.ViewModel model = new Index.ViewModel();

            model.Documents = context.Documents.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Index.FormData data)
        {
            Document document = new Document(Guid.NewGuid(), data.Title);

            context.Documents.Add(document);

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}