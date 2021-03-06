﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Diligencias;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Diligencias
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class DiligenciasService : IDiligenciasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Diligencias.Diligencias> _DiligenciasRepository;
        #endregion

        #region Ctor
        public DiligenciasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Diligencias.Diligencias> DiligenciasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._DiligenciasRepository = DiligenciasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Diligencias.Diligencias> SelAll(bool ConRelaciones)
        {
            return this._DiligenciasRepository.Table.ToList();
        }

        public IList<Core.Domain.Diligencias.Diligencias> SelAllComplete(bool ConRelaciones)
        {
            return this._DiligenciasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Diligencias.Diligencias> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._DiligenciasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Diligencias.Diligencias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._DiligenciasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Diligencias.Diligencias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._DiligenciasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Diligencias.DiligenciasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            DiligenciasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Diligencias.Diligencias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._DiligenciasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Diligencias.Diligencias GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Diligencias.Diligencias result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData DiligenciasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Diligencias.Diligencias entity, Spartane.Core.Domain.User.GlobalData DiligenciasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Diligencias.Diligencias entity, Spartane.Core.Domain.User.GlobalData DiligenciasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

