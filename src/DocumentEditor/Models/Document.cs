using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentEditor.Models
{
    public class Document
    {
        // Required for Entity Framework
        private Document()
        {
        }

        public Document(Guid Id, string Title)
        {
            this.Id = Id;
            this.Title = Title;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
    }
}