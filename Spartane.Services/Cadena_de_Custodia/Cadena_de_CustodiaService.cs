﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Cadena_de_Custodia;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Cadena_de_Custodia
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Cadena_de_CustodiaService : ICadena_de_CustodiaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> _Cadena_de_CustodiaRepository;
        #endregion

        #region Ctor
        public Cadena_de_CustodiaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> Cadena_de_CustodiaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Cadena_de_CustodiaRepository = Cadena_de_CustodiaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> SelAll(bool ConRelaciones)
        {
            return this._Cadena_de_CustodiaRepository.Table.ToList();
        }

        public IList<Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> SelAllComplete(bool ConRelaciones)
        {
            return this._Cadena_de_CustodiaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cadena_de_CustodiaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Cadena_de_CustodiaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cadena_de_CustodiaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_CustodiaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Cadena_de_CustodiaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Cadena_de_CustodiaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Cadena_de_CustodiaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia entity, Spartane.Core.Domain.User.GlobalData Cadena_de_CustodiaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Cadena_de_Custodia.Cadena_de_Custodia entity, Spartane.Core.Domain.User.GlobalData Cadena_de_CustodiaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

