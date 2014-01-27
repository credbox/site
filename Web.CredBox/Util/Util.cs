using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}