using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;

namespace Web.CredBox.Domain.BusinessLog
{
    internal class LogAdoNetAppender : AdoNetAppender
    {
        public string ConnectionStringName { get; set; }

        public override void ActivateOptions()
        {
            //ConnectionString = Util.Configurations.ConnectionString;
            base.ActivateOptions();
        }
    }
}
