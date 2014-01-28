using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Areas.Admin.Controllers
{
    public class ImovelController : BaseController
    {
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                return RedirectToAction("List", "Imovel");
            }
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            return View();
        }
    }
}
