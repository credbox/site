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
            ViewData["Estados"] = this.Estados();
            return View();
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public JsonResult Save(int idEstado, int idCidade, string nome, string endereco, string cep, int numero, string bairro, string contato, string telefoneContato, string celularContato,
            string emailContato, string complemento)
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
            string emailContato, string complemento)
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

        public ActionResult GetEstados()
        {
            try
            {
                var estados = ProjectDomain.EstadoBusiness.GetAll();
                return Json(estados, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<SelectListItem> Estados()
        {
            var list = ProjectDomain.EstadoBusiness.GetAll();
            var estados = new List<SelectListItem>();

            estados.Add(new SelectListItem { Text = "Selecione", Value = "0", Selected = true });
            foreach (var estado in list)
            {
                var item = new SelectListItem { Text = estado.nome, Value = estado.id.ToString() };
                estados.Add(item);
            }
            return estados;
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
