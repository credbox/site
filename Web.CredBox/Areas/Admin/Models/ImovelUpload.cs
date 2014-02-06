using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.CredBox.Areas.Admin.Models
{
    public class ImovelUpload
    {
        public int idImovel { get; set; }
        public HttpPostedFileBase foto1 { get; set; }
        public HttpPostedFileBase foto2 { get; set; }
        public HttpPostedFileBase foto3 { get; set; }
        public HttpPostedFileBase foto4 { get; set; }
        public HttpPostedFileBase foto5 { get; set; }
    }
}