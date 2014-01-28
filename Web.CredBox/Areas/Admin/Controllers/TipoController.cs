using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Areas.Admin.Controllers
{
    public class TipoController : BaseController
    {
        //
        // GET: /Admin/Tipo/

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var idTipo = int.Parse(id.Decrypt());
                var tipo = ProjectDomain.TipoBusiness.GetById(idTipo);
                ViewBag.Tipo = tipo;
                return View();
            }
            else
            {
                return RedirectToAction("List", "Tipo");
            }
        }

        public JsonResult Save(string nome)
        {
            try
            {
                var tipo = new TipoEntity { nome = nome, UsuarioInclusao = new UsuarioEntity { id = 1 } };
                var retorno = ProjectDomain.TipoBusiness.Add(tipo);
                if (retorno)
                    return ViewBag.Message = "Salvo com sucesso.";
                else
                    return ViewBag.Message = "Erro ao tentar inserir o tipo.";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult Update(int idTipo, string nome)
        {
            try
            {
                var tipo = new TipoEntity { id = idTipo, nome = nome, UsuarioInclusao = new UsuarioEntity { id = 1 } };
                var retorno = ProjectDomain.TipoBusiness.Edit(tipo);
                if (retorno)
                    return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                else
                    return Json("Erro ao tentar atualizar o tipo", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult GetAll(string nome)
        {
            try
            {
                var tipos = ProjectDomain.TipoBusiness.GetAll(nome);
                if (tipos.Count() > 0)
                    return View(tipos);
                else
                    return View(tipos = null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
