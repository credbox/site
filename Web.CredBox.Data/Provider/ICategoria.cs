﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface ICategoria:IRepository<CategoriaEntity>
    {
        bool Add(CategoriaEntity categoria);
        bool Edit(CategoriaEntity categoria);
        IList<CategoriaEntity> GetAll();
        CategoriaEntity GetById(int id);
    }
}
