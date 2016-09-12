using DocumentEditor.Models;
using System.Collections.Generic;

namespace DocumentEditor.Controllers.Home
{
    public class Index
    {
        public class FormData
        {
            public string Title { get; set; }
        }

        public class ViewModel
        {
            public List<Document> Documents { get; set; }
        }
    }
}