using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Model.Entity;
using System.IO;

namespace Web.CredBox.Areas.Admin.Controllers
{
    public class ImovelController : BaseController
    {
        public ActionResult Add()
        {
            ViewBag.Imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);
            ViewBag.Categorias = ProjectDomain.CategoriaBusiness.GetAll(string.Empty);
            ViewBag.Tipos = ProjectDomain.TipoBusiness.GetAll(string.Empty);
            ViewBag.Estados = ProjectDomain.EstadoBusiness.GetAll();
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var model = ProjectDomain.ImovelBusiness.GetById(int.Parse(id.Decrypt()));
                ViewBag.Imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);
                ViewBag.Categorias = ProjectDomain.CategoriaBusiness.GetAll(string.Empty);
                ViewBag.Tipos = ProjectDomain.TipoBusiness.GetAll(string.Empty);
                ViewBag.Estados = ProjectDomain.EstadoBusiness.GetAll();
                ViewBag.Cidades = ProjectDomain.CidadeBusiness.GetByIdEstado(model.Estado.id);
                return View(model);
            }
            else
            {
                return RedirectToAction("List", "Imovel");
            }
        }

        public ActionResult List()
        {
            ViewBag.Imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);
            ViewBag.Categorias = ProjectDomain.CategoriaBusiness.GetAll(string.Empty);
            ViewBag.Tipos = ProjectDomain.TipoBusiness.GetAll(string.Empty);
            ViewBag.Estados = ProjectDomain.EstadoBusiness.GetAll();
            return View();
        }

        public ActionResult GetAll(int idimobiliaria, bool publicar, bool vendido, string nome, string codigoimobiliaria, int idCategoria, int idTipo, int idEstado, int idCidade)
        {
            try
            {
                var imoveis = ProjectDomain.ImovelBusiness.GetAll(idimobiliaria, publicar, vendido, nome, codigoimobiliaria, idCategoria, idTipo, idEstado, idCidade);
                if (imoveis.Count() > 0)
                    return View(imoveis);
                else
                    return View(imoveis = null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult Save(int idimobiliaria, int idcategoria, int idtipo, int idestado, int idcidade, string nome, string bairro, string endereco, int numero, string complemento, string cep,
            string codigoimobiliaria, int vagagaragem, int quantidadesuite, int quantidadequarto, decimal areaterreno, decimal areaconstruida, bool aceitafinanciamento, decimal valor, string descricao)
        {
            var imovel = new ImovelEntity
            {
                Imobiliaria = new ImobiliariaEntity { id = idimobiliaria },
                Categoria = new CategoriaEntity { id = idcategoria },
                Tipo = new TipoEntity { id = idtipo },
                Estado = new EstadoEntity { id = idestado },
                Cidade = new CidadeEntity { id = idcidade },
                nome = nome,
                bairro = bairro,
                endereco = endereco,
                numero = numero,
                complemento = complemento,
                cep = cep,
                codigoImobiliaria = codigoimobiliaria,
                vagagaragem = vagagaragem,
                quantidadeSuite = quantidadesuite,
                quantidadeQuarto = quantidadequarto,
                areaTerreno = areaterreno,
                areaConstruida = areaconstruida,
                aceitaFinanciamento = aceitafinanciamento,
                valor = valor,
                UsuarioInclusao = new UsuarioEntity { id = 1 }

            };
            try
            {
                var retorno = ProjectDomain.ImovelBusiness.Add(imovel);

                if (retorno > 0)
                {
                    var model = new Admin.Models.ImovelUpload { idImovel = retorno };
                    return Json(new { id = retorno, message = "Salvo com sucesso, inclua as imagens do imóvel." }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { id = 0, message = "Erro ao tentar inserir o imóvel" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { id = 0, message = "Erro ao tentar inserir o imóvel" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Update(int idimobiliaria, int idcategoria, int idtipo, int idestado, int idcidade, string nome, string bairro, string endereco, int numero, string complemento, string cep,
            string codigoimobiliaria, int vagagaragem, int quantidadesuite, int quantidadequarto, decimal areaterreno, decimal areaconstruida, bool aceitafinanciamento, decimal valor, bool publicar,
            bool vendido, bool destaque, string descricao)
        {
            try
            {
                return Json("Salvo com sucesso", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Erro ao tentar atualizar o imóvel", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Upload(Models.ImovelUpload model)
        {
            try
            {

                if (model.idImovel > 0)
                {
                    var imovel = new ImovelEntity { id = model.idImovel };

                    var path = Util.PathFile.CreatePath(model.idImovel);
                    if (!string.IsNullOrEmpty(model.foto1.FileName))
                    {
                        var nome = string.Format("Imovel_{0}_1{1}", model.idImovel, Path.GetExtension(model.foto1.FileName));
                        imovel.caminhofoto1 = path;
                        imovel.nomefoto1 = nome;
                        imovel.extensaofoto1 = Path.GetExtension(model.foto1.FileName);
                        model.foto1.SaveAs(string.Concat(path, model.foto1.FileName));
                        System.IO.File.Move(string.Concat(path, model.foto1.FileName), string.Concat(path, nome));
                    }

                    if (!string.IsNullOrEmpty(model.foto2.FileName))
                    {
                        var nome = string.Format("Imovel_{0}_2{1}", model.idImovel, Path.GetExtension(model.foto2.FileName));
                        imovel.caminhofoto2 = path;
                        imovel.nomefoto2 = nome;
                        imovel.extensaofoto2 = Path.GetExtension(model.foto2.FileName);
                        model.foto2.SaveAs(string.Concat(path, model.foto2.FileName));
                        System.IO.File.Move(string.Concat(path, model.foto2.FileName), string.Concat(path, nome));
                    }

                    if (!string.IsNullOrEmpty(model.foto3.FileName))
                    {
                        var nome = string.Format("Imovel_{0}_3{1}", model.idImovel, Path.GetExtension(model.foto3.FileName));
                        imovel.caminhofoto3 = path;
                        imovel.nomefoto3 = nome;
                        imovel.extensaofoto3 = Path.GetExtension(model.foto3.FileName);
                        model.foto3.SaveAs(string.Concat(path, model.foto3.FileName));
                        System.IO.File.Move(string.Concat(path, model.foto3.FileName), string.Concat(path, nome));
                    }

                    if (!string.IsNullOrEmpty(model.foto4.FileName))
                    {
                        var nome = string.Format("Imovel_{0}_4{1}", model.idImovel, Path.GetExtension(model.foto4.FileName));
                        imovel.caminhofoto4 = path;
                        imovel.nomefoto4 = nome;
                        imovel.extensaofoto4 = Path.GetExtension(model.foto4.FileName);
                        model.foto4.SaveAs(string.Concat(path, model.foto4.FileName));
                        System.IO.File.Move(string.Concat(path, model.foto4.FileName), string.Concat(path, nome));
                    }

                    if (!string.IsNullOrEmpty(model.foto5.FileName))
                    {
                        var nome = string.Format("Imovel_{0}_5{1}", model.idImovel, Path.GetExtension(model.foto5.FileName));
                        imovel.caminhofoto5 = path;
                        imovel.nomefoto5 = nome;
                        imovel.extensaofoto5 = Path.GetExtension(model.foto5.FileName);
                        model.foto5.SaveAs(string.Concat(path, model.foto5.FileName));
                        System.IO.File.Move(string.Concat(path, model.foto5.FileName), string.Concat(path, nome));
                    }
                    imovel.UsuarioAtualizacao = new UsuarioEntity { id = 1 };


                    var resultado = ProjectDomain.ImovelBusiness.AddImages(imovel);
                    ViewBag.Imobiliarias = ProjectDomain.ImobiliariaBusiness.GetAllByStatus(0, 0, string.Empty, true);
                    ViewBag.Categorias = ProjectDomain.CategoriaBusiness.GetAll(string.Empty);
                    ViewBag.Tipos = ProjectDomain.TipoBusiness.GetAll(string.Empty);
                    ViewBag.Estados = ProjectDomain.EstadoBusiness.GetAll();

                    ViewBag.Images = imovel;

                    if (resultado)
                    {
                        var modelImge = new Admin.Models.ImovelUpload { idImovel = imovel.id };
                        ViewBag.Resutlado = true;
                        return View("Add");
                    }
                    else
                    {
                        ViewBag.Resutlado = false;
                        return View("Add");
                    }
                }
                else
                {
                    ViewBag.Resutlado = false;
                    return View("Add");
                }
            }

            catch
            {
                ViewBag.Resutlado = false;
                return View("Add");
            }

        }
    }
}