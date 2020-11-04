﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Sub_Marca_del_Vehiculo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Sub_Marca_del_Vehiculo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Sub_Marca_del_VehiculoService : ISub_Marca_del_VehiculoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> _Sub_Marca_del_VehiculoRepository;
        #endregion

        #region Ctor
        public Sub_Marca_del_VehiculoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> Sub_Marca_del_VehiculoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Sub_Marca_del_VehiculoRepository = Sub_Marca_del_VehiculoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> SelAll(bool ConRelaciones)
        {
            return this._Sub_Marca_del_VehiculoRepository.Table.ToList();
        }

        public IList<Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> SelAllComplete(bool ConRelaciones)
        {
            return this._Sub_Marca_del_VehiculoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Sub_Marca_del_VehiculoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Sub_Marca_del_VehiculoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Sub_Marca_del_VehiculoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_VehiculoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Sub_Marca_del_VehiculoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Sub_Marca_del_VehiculoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Sub_Marca_del_VehiculoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo entity, Spartane.Core.Domain.User.GlobalData Sub_Marca_del_VehiculoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo entity, Spartane.Core.Domain.User.GlobalData Sub_Marca_del_VehiculoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

