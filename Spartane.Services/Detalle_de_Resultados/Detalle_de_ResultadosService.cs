﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_de_Resultados;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Resultados
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_ResultadosService : IDetalle_de_ResultadosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> _Detalle_de_ResultadosRepository;
        #endregion

        #region Ctor
        public Detalle_de_ResultadosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> Detalle_de_ResultadosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_ResultadosRepository = Detalle_de_ResultadosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> SelAll(bool ConRelaciones)
        {
            return this._Detalle_de_ResultadosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_de_ResultadosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_ResultadosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_ResultadosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_ResultadosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_ResultadosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_de_ResultadosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_ResultadosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_de_ResultadosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados entity, Spartane.Core.Domain.User.GlobalData Detalle_de_ResultadosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_de_Resultados.Detalle_de_Resultados entity, Spartane.Core.Domain.User.GlobalData Detalle_de_ResultadosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

