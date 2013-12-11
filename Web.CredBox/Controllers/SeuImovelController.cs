using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.CredBox.Controllers
{
    public class SeuImovelController : Controller
    {
        //
        // GET: /SeuImovel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Imovel()
        {
            return View();
        }

    }
}
