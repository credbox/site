using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Areas.Admin.Controllers
{
    public class AssuntoController : BaseController
    {
        //
        // GET: /Admin/Assunto/

        public ActionResult List()
        {
            try
            {
                var list = ProjectDomain.AssuntoBusiness.GetAll();
                if (list.Count() > 0)
                    ViewBag.Assuntos = list;
                else
                {
                    ViewBag.Assuntos = null;
                    ViewBag.Message = "Nenhum assunto foi encontrado";
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var assunto = ProjectDomain.AssuntoBusiness.GetById(id);
            ViewBag.Assunto = assunto;
            return View();
        }

        public JsonResult Save(string nome)
        {
            try
            {
                var assunto = new AssuntoEntity { nome = nome, UsuarioInclusao = new UsuarioEntity { id = 1 } };
                var retorno = ProjectDomain.AssuntoBusiness.Add(assunto);
                if (retorno)
                    return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                else
                    return Json("Erro ao tentar inserir o assunto", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult Update(int idAssunto, string nome)
        {
            try
            {
                var assunto = new AssuntoEntity { id = idAssunto, nome = nome, UsuarioInclusao = new UsuarioEntity { id = 1 } };
                var retorno = ProjectDomain.AssuntoBusiness.Edit(assunto);
                if (retorno)
                    return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                else
                    return Json("Erro ao tentar atualizar o assunto", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
