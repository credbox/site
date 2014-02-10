﻿using System;
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
            ViewBag.Imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var idusuario = int.Parse(id.Decrypt());
                var usuario = ProjectDomain.UsuarioBusiness.GetById(idusuario);
                ViewBag.Imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);

                return View(usuario);
            }
            else
            {
                return RedirectToAction("List", "Imobiliaria");
            }
        }

        public ActionResult List()
        {
            ViewBag.Imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);
            return View();
        }

        public JsonResult Save(int idImobiliaria, string nome, string email, string login, string senha, bool imobiliaria, bool ativo, bool emailNotificacao, bool administrar)
        {
            var usuario = new UsuarioEntity { nome = nome, email = email, login = login, senha = senha.Encrypt(), imobiliaria = imobiliaria, ativo = ativo, emailNotificacao = emailNotificacao, Administrar = administrar };
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

        public JsonResult Update(int idusuario, int idImobiliaria, string nome, string email, string login, string senha, bool imobiliaria, bool ativo, bool emailNotificacao, bool administrar)
        {
            var usuario = new UsuarioEntity { id = idusuario, nome = nome, email = email, login = login, imobiliaria = imobiliaria, ativo = ativo, emailNotificacao = emailNotificacao, Administrar = administrar };

            if (!string.IsNullOrEmpty(senha))
                usuario.senha = senha.Encrypt();

            if (idImobiliaria > 0)
                usuario.Imobiliaria = new ImobiliariaEntity { id = idImobiliaria };
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
