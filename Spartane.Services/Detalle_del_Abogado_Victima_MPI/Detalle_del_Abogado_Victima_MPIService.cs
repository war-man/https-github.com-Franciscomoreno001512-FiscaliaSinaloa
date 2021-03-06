﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_del_Abogado_Victima_MPI
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_del_Abogado_Victima_MPIService : IDetalle_del_Abogado_Victima_MPIService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> _Detalle_del_Abogado_Victima_MPIRepository;
        #endregion

        #region Ctor
        public Detalle_del_Abogado_Victima_MPIService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> Detalle_del_Abogado_Victima_MPIRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_del_Abogado_Victima_MPIRepository = Detalle_del_Abogado_Victima_MPIRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> SelAll(bool ConRelaciones)
        {
            return this._Detalle_del_Abogado_Victima_MPIRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_del_Abogado_Victima_MPIRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_del_Abogado_Victima_MPIRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_del_Abogado_Victima_MPIRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_del_Abogado_Victima_MPIRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPIPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_del_Abogado_Victima_MPIPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_del_Abogado_Victima_MPIRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_del_Abogado_Victima_MPIInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI entity, Spartane.Core.Domain.User.GlobalData Detalle_del_Abogado_Victima_MPIInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_del_Abogado_Victima_MPI.Detalle_del_Abogado_Victima_MPI entity, Spartane.Core.Domain.User.GlobalData Detalle_del_Abogado_Victima_MPIInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

