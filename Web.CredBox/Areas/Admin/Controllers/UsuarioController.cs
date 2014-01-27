using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Areas.Admin.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult Add()
        {
            ViewData["Imobiliarias"] = this.Imobiliarias();
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult List()
        {
            ViewData["Imobiliarias"] = this.Imobiliarias();
            return View();
        }

        public JsonResult Save(int idImobiliaria, string nome, string email, string login, string senha, bool imobiliaria, bool ativo, bool emailNotificacao)
        {
            if (ModelState.IsValid)
            {

                var usuario = new UsuarioEntity { nome = nome, email = email, login = login, senha = senha.Encrypt(), imobiliaria = imobiliaria, ativo = ativo, emailNotificacao = emailNotificacao };
                if (idImobiliaria > 0)
                    usuario.Imobiliaria = new ImobiliariaEntity { id = idImobiliaria };
                usuario.UsuarioInclusao = new UsuarioEntity { id = 1 };

                try
                {
                    var retorno = ProjectDomain.UsuarioBusiness.Add(usuario);
                    if (retorno)
                        return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                    else
                        return Json("Erro ao tentar inserir o usuário.", JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return Json("Preencha os campos obrigatórios do usuário.", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Update(int id, int Imobiliaria, string nome, string email, string login, string senha, bool imobiliaria, bool ativo, bool emailNotificacao)
        {
            var usuario = new UsuarioEntity { id = id, nome = nome, email = email, login = login, senha = senha.Encrypt(), imobiliaria = imobiliaria, ativo = ativo, emailNotificacao = emailNotificacao };
            if (Imobiliaria > 0)
                usuario.Imobiliaria = new ImobiliariaEntity { id = Imobiliaria };
            try
            {
                var retorno = ProjectDomain.UsuarioBusiness.Edit(usuario);
                if (retorno)
                    return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                else
                    return Json("Erro ao tentar atualizar o usuário.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<SelectListItem> Imobiliarias()
        {
            var list = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);
            var imobiliarias = new List<SelectListItem>();

            imobiliarias.Add(new SelectListItem { Text = "Selecione", Value = "0", Selected = true });
            foreach (var imobiliaria in list)
            {
                var item = new SelectListItem { Text = imobiliaria.nome, Value = imobiliaria.id.ToString() };
                imobiliarias.Add(item);
            }

            return imobiliarias;
        }

        [HttpPost]
        public ActionResult GetAll(string nome, string email, string login, int idimobiliaria, bool ativo)
        {
            try
            {
                var usuarios = ProjectDomain.UsuarioBusiness.GetAllByStatus(nome, email, login, idimobiliaria, ativo);
                if (usuarios.Count() > 0)
                    return View(usuarios);
                else
                    return View(usuarios = null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
