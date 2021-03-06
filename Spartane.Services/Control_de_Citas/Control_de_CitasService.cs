﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Control_de_Citas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Control_de_Citas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Control_de_CitasService : IControl_de_CitasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Control_de_Citas.Control_de_Citas> _Control_de_CitasRepository;
        #endregion

        #region Ctor
        public Control_de_CitasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Control_de_Citas.Control_de_Citas> Control_de_CitasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Control_de_CitasRepository = Control_de_CitasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Control_de_Citas.Control_de_Citas> SelAll(bool ConRelaciones)
        {
            return this._Control_de_CitasRepository.Table.ToList();
        }

        public IList<Core.Domain.Control_de_Citas.Control_de_Citas> SelAllComplete(bool ConRelaciones)
        {
            return this._Control_de_CitasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Control_de_Citas.Control_de_Citas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Control_de_CitasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Control_de_Citas.Control_de_Citas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Control_de_CitasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Control_de_Citas.Control_de_Citas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Control_de_CitasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Control_de_Citas.Control_de_CitasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Control_de_CitasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Control_de_Citas.Control_de_Citas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Control_de_CitasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Control_de_Citas.Control_de_Citas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Control_de_Citas.Control_de_Citas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Control_de_CitasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Control_de_Citas.Control_de_Citas entity, Spartane.Core.Domain.User.GlobalData Control_de_CitasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Control_de_Citas.Control_de_Citas entity, Spartane.Core.Domain.User.GlobalData Control_de_CitasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

