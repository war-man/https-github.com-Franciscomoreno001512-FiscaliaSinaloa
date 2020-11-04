﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Folio_Asignado_de_Usuario
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_Folio_Asignado_de_UsuarioService : IDetalle_de_Folio_Asignado_de_UsuarioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> _Detalle_de_Folio_Asignado_de_UsuarioRepository;
        #endregion

        #region Ctor
        public Detalle_de_Folio_Asignado_de_UsuarioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> Detalle_de_Folio_Asignado_de_UsuarioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_Folio_Asignado_de_UsuarioRepository = Detalle_de_Folio_Asignado_de_UsuarioRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> SelAll(bool ConRelaciones)
        {
            return this._Detalle_de_Folio_Asignado_de_UsuarioRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_de_Folio_Asignado_de_UsuarioRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Folio_Asignado_de_UsuarioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_Folio_Asignado_de_UsuarioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_Folio_Asignado_de_UsuarioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_UsuarioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_de_Folio_Asignado_de_UsuarioPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_Folio_Asignado_de_UsuarioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_de_Folio_Asignado_de_UsuarioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Folio_Asignado_de_UsuarioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Folio_Asignado_de_UsuarioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

