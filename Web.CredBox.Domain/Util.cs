using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Web.CredBox.Domain
{
    internal class Util
    {
        internal class Configurations
        {
            private static string connectionString;
            private static string logFileConfiguration;

            public static string ConnectionString
            {
                get
                {
                    if (string.IsNullOrEmpty(connectionString))
                        connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;

                    return connectionString;
                }
            }

            public static string LogFileConfiguration
            {
                get
                {
                    if (string.IsNullOrEmpty(logFileConfiguration))
                        logFileConfiguration = ConfigurationManager.AppSettings["LogFileConfiguration"].ToString();

                    return logFileConfiguration;
                }
            }

        }

        internal class TypeHelper
        {
            public static bool GetAsBoolean(string campo)
            {
                if (!String.IsNullOrEmpty(campo))
                    if (campo == "S")
                        return true;
                    else
                        return false;
                else
                    return false;
            }
        }
    }
}