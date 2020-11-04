﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Lugares_Frecuentes_Probable_Responsable
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Lugares_Frecuentes_Probable_ResponsableService : ILugares_Frecuentes_Probable_ResponsableService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> _Lugares_Frecuentes_Probable_ResponsableRepository;
        #endregion

        #region Ctor
        public Lugares_Frecuentes_Probable_ResponsableService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> Lugares_Frecuentes_Probable_ResponsableRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Lugares_Frecuentes_Probable_ResponsableRepository = Lugares_Frecuentes_Probable_ResponsableRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> SelAll(bool ConRelaciones)
        {
            return this._Lugares_Frecuentes_Probable_ResponsableRepository.Table.ToList();
        }

        public IList<Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> SelAllComplete(bool ConRelaciones)
        {
            return this._Lugares_Frecuentes_Probable_ResponsableRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Lugares_Frecuentes_Probable_ResponsableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Lugares_Frecuentes_Probable_ResponsableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Lugares_Frecuentes_Probable_ResponsableRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_ResponsablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Lugares_Frecuentes_Probable_ResponsablePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Lugares_Frecuentes_Probable_ResponsableRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Lugares_Frecuentes_Probable_ResponsableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable entity, Spartane.Core.Domain.User.GlobalData Lugares_Frecuentes_Probable_ResponsableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Lugares_Frecuentes_Probable_Responsable.Lugares_Frecuentes_Probable_Responsable entity, Spartane.Core.Domain.User.GlobalData Lugares_Frecuentes_Probable_ResponsableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

