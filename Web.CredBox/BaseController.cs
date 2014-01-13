using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CredBox.Domain;

namespace Web.CredBox
{
    public abstract class BaseController : Controller
    {
        private ProjectDomain projectDomain;

        public ProjectDomain ProjectDomain
        { get { return projectDomain ?? (projectDomain = new ProjectDomain()); } }

    }
}