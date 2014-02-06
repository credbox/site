using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Web.CredBox
{
    public static class Credbox
    {
        public static class Url
        {
            /// <summary>
            /// Url Principal do sistema
            /// </summary>
            //public static string Principal = " ";//ConfigurationManager.AppSettings["urlprincipal"] != null ? ConfigurationManager.AppSettings["urlprincipal"].ToString() : "http://" + HttpContext.Current.Request.Headers["HOST"];

            public static string Principal
            {
                get
                {
                    string urlAtual = HttpContext.Current.Request.Url.Authority.ToLower();
                    if (!urlAtual.Contains("localhost") && !urlAtual.Contains("homolog."))
                    {
                        return "https://" + urlAtual;
                    }
                    else
                        return " ";
                }
            }

            /// <summary>
            /// Mapeamento de Arquivos Estaticos do sistema
            /// </summary>
            public static string Conteudo(string arquivo)
            {
                string url = "";
                string rootUrl = ConfigurationManager.AppSettings["STORAGE"].ToString();
                if (rootUrl == "LOCAL")
                {
                    rootUrl = Principal;
                }


                if (arquivo.Contains("~/"))
                {
                    url = arquivo.Replace("~/", rootUrl + "/");
                }
                else
                {
                    url = arquivo;
                }
                bool minifica = ConfigurationManager.AppSettings["MINIFY"] != null;
                string versao = ConfigurationManager.AppSettings["VERSAO"];

                if (url.Contains(".css") || url.Contains(".js"))
                {
                    url += string.Format("?v={0}", versao);
                    if (minifica)
                    {
                        if (!url.Contains("min."))
                        {
                            if (url.Contains(".css"))
                            {
                                //Elimina o bootstrap pela quantidade de "hacks" no css
                                if (!url.Contains("bootstrap."))
                                {
                                    url = url.Replace(".css", ".min.css");
                                }
                            }
                            else
                            {
                                url = url.Replace(".js", ".min.js");
                            }
                        }
                    }
                }

                return url.ToLower().TrimStart().TrimEnd();
            }

        }
    }
}