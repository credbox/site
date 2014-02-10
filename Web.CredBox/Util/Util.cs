using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;

namespace Web.CredBox
{
    public abstract class Util
    {
        public static class ConvertValue
        {
            public static string BoolToString(bool value)
            {
                if (value)
                    return "Sim";
                else
                    return "Não";
            }
        }

        public static class PathFile
        {
            public static string CreatePath(int idImovel)
            {
                var caminhoPadrao = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PathUpload"]);

                if (!Directory.Exists(caminhoPadrao))
                {
                    Directory.CreateDirectory(caminhoPadrao);
                }

                var path = string.Format("{0}\\{1}_{2}\\", caminhoPadrao, "Imovel", idImovel);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                return path;
            }

            public static bool ExistePath(string path)
            {
                if (!Directory.Exists(path))
                    return true;
                else
                    return false;
            }

            public static bool DeletePath(string path)
            {
                try
                {
                    Directory.Delete(path);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}