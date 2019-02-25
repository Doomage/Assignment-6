using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project124125125.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get;set;}
        public HttpPostedFileBase File { get; set; }
    }
}