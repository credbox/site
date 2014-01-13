﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface IImovel : IRepository<ImovelEntity>
    {
        bool Add(ImovelEntity imovel);
        bool Edit(ImovelEntity imovel);
        IList<ImovelEntity> GetAll();
        ImovelEntity GetById(int id);
        IList<ImovelEntity> GetAllDestaque();
    }
}
