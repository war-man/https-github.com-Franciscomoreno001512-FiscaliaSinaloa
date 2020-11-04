﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_de_Documentos_de_MPO;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Documentos_de_MPO
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Documentos_de_MPOService : IDetalle_de_Documentos_de_MPOService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> _Detalle_de_Documentos_de_MPORepository;
        #endregion

        #region Ctor
        public Detalle_de_Documentos_de_MPOService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> Detalle_de_Documentos_de_MPORepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Documentos_de_MPORepository = Detalle_de_Documentos_de_MPORepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> SelAll(bool ConRelaciones)
        {
            return this._Detalle_de_Documentos_de_MPORepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_de_Documentos_de_MPORepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Documentos_de_MPORepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Documentos_de_MPORepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Documentos_de_MPORepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPOPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_de_Documentos_de_MPOPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Documentos_de_MPORepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_de_Documentos_de_MPOInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Documentos_de_MPOInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_de_Documentos_de_MPO.Detalle_de_Documentos_de_MPO entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Documentos_de_MPOInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

