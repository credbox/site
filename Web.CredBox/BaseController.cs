using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Domain;
using System.Xml;
using System.Xml.Linq;

namespace Web.CredBox
{
    public abstract class BaseController : Controller
    {
        private ProjectDomain projectDomain;

        public ProjectDomain ProjectDomain
        { get { return projectDomain ?? (projectDomain = new ProjectDomain()); } }


        public static MvcHtmlString BreadcrumbPath()
        {
            string li = "<li style=text-transform:capitalize><span class='divider'>{0}</span>{1}</li>";
            string path = string.Format(li, string.Empty, "Home");
            string img = Credbox.Url.Conteudo("~/static/img/breadcrumb-arrow.png");

            var urlatual = System.Web.HttpContext.Current.Request.Url.PathAndQuery.TrimEnd('/').ToLower();
            string root = urlatual.Split('/')[1];
            var arrUrlAtual = urlatual.Split('/');
            XElement xml = XElement.Load(System.Web.HttpContext.Current.Server.MapPath("~/static/credbox-config.xml"));
            var query = (from a in xml.Descendants("url")
                         where a.Attribute("src").Value.Contains(root)
                         && (a.Attribute("src").Value.Contains(arrUrlAtual[arrUrlAtual.Length - 1]))
                         select a);

            if (!arrUrlAtual.Contains("home"))
            {
                for (int i = 0; i < arrUrlAtual.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(arrUrlAtual[i]))
                    {
                        var src = query.FirstOrDefault(e => e.Attribute("src").Value.StartsWith("/" + arrUrlAtual[i]));
                        if (src != null)
                        {
                            //RESGATA O NÓ PAI
                            var noPai = xml.Descendants("url").Where(a => a.Attribute("nome").Value == src.Attribute("nome").Value).Ancestors().First();

                            if (noPai.Attribute("nome") != null && noPai.Attribute("nome").Value != "Home" && noPai.Name.ToString() != "sitemap")
                                path += string.Format(li, "<img src=" + img + ">", noPai.Attribute("nome").Value);
                            path += string.Format(li, "<img src=" + img + ">", src.Attribute("nome").Value);
                        }
                    }
                }
            }

            return MvcHtmlString.Create("<ul class='breadcrumb'>" + path.ToLower() + "</ul>");
        }

    }
}