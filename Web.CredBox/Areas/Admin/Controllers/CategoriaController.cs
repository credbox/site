using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Areas.Admin.Controllers
{
    public class CategoriaController : BaseController
    {
        //
        // GET: /Admin/Categoria/

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
                var idCategoria = int.Parse(id.Decrypt());
                var categoria = ProjectDomain.CategoriaBusiness.GetById(idCategoria);

                ViewBag.Categoria = categoria;
                return View();
            }
            else
            {
                return RedirectToAction("List", "Categoria");
            }
        }

        public JsonResult Save(string nome)
        {
            try
            {
                var categoria = new CategoriaEntity { nome = nome, UsuarioInclusao = new UsuarioEntity { id = 1 } };
                var retorno = ProjectDomain.CategoriaBusiness.Add(categoria);
                if (retorno)
                    return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                else
                    return Json("Erro ao tentar inserir a categoria.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult Update(int idCategoria, string nome)
        {
            try
            {
                var categoria = new CategoriaEntity { id = idCategoria, nome = nome, UsuarioInclusao = new UsuarioEntity { id = 1 } };
                var retorno = ProjectDomain.CategoriaBusiness.Edit(categoria);
                if (retorno)
                    return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                else
                    return Json("Erro ao tentar atualizar a categoria", JsonRequestBehavior.AllowGet);
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
                var categorias = ProjectDomain.CategoriaBusiness.GetAll(nome);
                if (categorias.Count() > 0)
                    return View(categorias);
                else
                    return View(categorias = null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
