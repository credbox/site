using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Model.Entity;


namespace Web.CredBox.Areas.Admin.Controllers
{
    public class ImobiliariaController : BaseController
    {
        //
        // GET: /Admin/Imobiliaria/

        public ActionResult List()
        {
            ViewData["Estados"] = this.Estados(0);
            return View();
        }


        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var idImobiliaria = int.Parse(id.Decrypt());
                var imobiliaria = ProjectDomain.ImobiliariaBusiness.GetById(idImobiliaria);
                ViewBag.Estados = this.Estados(imobiliaria.Estado.id);
                ViewBag.Cidades = ProjectDomain.CidadeBusiness.GetByIdEstado(imobiliaria.Estado.id);
                return View(imobiliaria);
            }
            else
            {
                return RedirectToAction("List", "Imobiliaria");
            }
        }

        public ActionResult Add()
        {
            ViewData["Estados"] = this.Estados(0);
            return View();
        }

        public JsonResult Save(int idEstado, int idCidade, string nome, string endereco, string cep, int numero, string bairro, string contato, string telefoneContato, string celularContato,
            string emailContato, string complemento, bool ativo)
        {
            try
            {
                var imobiliaria = new ImobiliariaEntity
                {
                    Estado = new EstadoEntity { id = idEstado },
                    Cidade = new CidadeEntity { id = idCidade },
                    nome = nome,
                    endereco = endereco,
                    cep = cep,
                    numero = numero,
                    bairro = bairro,
                    contato = contato,
                    telefoneContato = telefoneContato,
                    celularContato = celularContato,
                    emailContato = emailContato,
                    complemento = complemento,
                    ativo = ativo,
                    UsuarioInclusao = new UsuarioEntity { id = 1 }
                };
                var retorno = ProjectDomain.ImobiliariaBusiness.Add(imobiliaria);
                if (retorno)
                    return Json("Salvo com sucesso.", JsonRequestBehavior.AllowGet);
                else
                    return Json("Erro ao tentar inserir a imobiliária", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult Update(int idImobiliaria, int idEstado, int idCidade, string nome, string endereco, string cep, int numero, string bairro, string contato, string telefoneContato, string celularContato,
            string emailContato, string complemento, bool ativo)
        {
            try
            {
                var imobiliaria = new ImobiliariaEntity
                {
                    id = idImobiliaria,
                    Estado = new EstadoEntity { id = idEstado },
                    Cidade = new CidadeEntity { id = idCidade },
                    nome = nome,
                    endereco = endereco,
                    cep = cep,
                    numero = numero,
                    bairro = bairro,
                    contato = contato,
                    telefoneContato = telefoneContato,
                    celularContato = celularContato,
                    emailContato = emailContato,
                    complemento = complemento,
                    ativo = ativo,
                    UsuarioInclusao = new UsuarioEntity { id = 1 }
                };
                var retorno = ProjectDomain.ImobiliariaBusiness.Edit(imobiliaria);
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

        [HttpPost]
        public ActionResult GetAll(int idEstado, int idCidade, string nome, bool status)
        {
            try
            {
                var imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(idEstado, idCidade, nome, status);

                if (imobiliarias.Count() > 0)
                    return View(imobiliarias);
                else
                    return View(imobiliarias = null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private IList<SelectListItem> Estados(int id)
        {
            var list = ProjectDomain.EstadoBusiness.GetAll();
            var estados = new List<SelectListItem>();
            estados.Add(new SelectListItem { Value = "0", Text = "Selecione" });
            foreach (var item in list)
            {
                estados.Add(new SelectListItem { Text = item.sigla, Value = item.id.ToString() });
            }
            return estados;
        }

        private IList<SelectListItem> Cidades(int idEstado, int id)
        {
            var list = ProjectDomain.CidadeBusiness.GetByIdEstado(idEstado);
            var cidades = new List<SelectListItem>();
            cidades.Add(new SelectListItem { Value = "0", Text = "Selecione" });
            foreach (var item in list)
            {
                cidades.Add(new SelectListItem { Text = item.nome, Value = item.id.ToString() });
            }
            return cidades;
        }
        public ActionResult GetCidades(int idEstado)
        {
            try
            {
                var cidades = ProjectDomain.CidadeBusiness.GetByIdEstado(idEstado);
                return Json(cidades, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
