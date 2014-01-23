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
            var categorias = ProjectDomain.CategoriaBusiness.GetAll();
            if (categorias.Count() > 0)
                ViewBag.Categorias = categorias;
            else
            {
                ViewBag.Categorias = null;
                ViewBag.Message = "Nenhuma categoria foi encontrado";
            }
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var categoria = ProjectDomain.CategoriaBusiness.GetById(id);

            ViewBag.Categoria = categoria;
            return View();
        }

        public JsonResult Save(string nome)
        {
            try
            {
                var categoria = new CategoriaEntity { nome = nome, UsuarioInclusao = new UsuarioEntity { id = 1 } };
                var retorno = ProjectDomain.CategoriaBusiness.Add(categoria);
                if (retorno)
                    return ViewBag.Message = "Salvo com sucesso.";
                else
                    return ViewBag.Message = "Erro ao tentar inserir a categoria.";
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

    }
}
