using DocumentEditor.Tests.Acceptance.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentEditor.Tests.Acceptance.Workflows
{
    class UserWorkflow
    {
        private readonly DocumentEditorSite documentEditorSite;

        public UserWorkflow(DocumentEditorSite documentEditorSite)
        {
            this.documentEditorSite = documentEditorSite;
        }

        public void CreateNewDocument(string documentTitle)
        {
            var newDocumentForm = documentEditorSite
                .GotoHomePage()
                .GotoNewDocumentForm();

            newDocumentForm.Title = documentTitle;
            newDocumentForm.Submit();

            documentEditorSite
                .GotoHomePage();
        }

        public IEnumerable<string> ViewListOfDocuments()
        {
            return documentEditorSite
                .GotoHomePage()
                .Documents;
        }
    }
}
