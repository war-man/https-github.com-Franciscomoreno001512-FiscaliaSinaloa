﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Object_Type
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_Object_TypeService : ISpartan_Traduction_Object_TypeService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> _Spartan_Traduction_Object_TypeRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_Object_TypeService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> Spartan_Traduction_Object_TypeRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_Object_TypeRepository = Spartan_Traduction_Object_TypeRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Traduction_Object_TypePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_Object_TypeRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Object_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Object_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Traduction_Object_Type.Spartan_Traduction_Object_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Object_TypeInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

